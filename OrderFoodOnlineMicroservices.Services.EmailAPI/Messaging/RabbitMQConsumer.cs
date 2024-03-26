
using Newtonsoft.Json;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Dto;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Service;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Service.IService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OrderFoodOnlineMicroservices.Services.EmailAPI.Messaging
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private readonly string _queueName;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQConsumer(IConfiguration configuration, EmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;
            _hostname = _configuration.GetValue<string>("RabbitMQ:HostName");
            _username = _configuration.GetValue<string>("RabbitMQ:Username");
            _password = _configuration.GetValue<string>("RabbitMQ:Password");
            _queueName = _configuration.GetValue<string>("QueueNames:EmailShoppingCartQueue");

            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var condumer = new EventingBasicConsumer(_channel);

            condumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(content);

                HandleMessage(objMessage).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueName, false, condumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CartDto objMessage)
        {
            try
            {
                await _emailService.EmailCartAndLog(objMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
