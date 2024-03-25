using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private readonly IConfiguration _configuration;
        private IConnection _connection;

        public RabbitMQCartMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _hostname = _configuration.GetValue<string>("RabbitMQ:HostName");
            _username = _configuration.GetValue<string>("RabbitMQ:Username");
            _password = _configuration.GetValue<string>("RabbitMQ:Password");
        }


        public void SendMessage(object message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(jsonMessage);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
}
