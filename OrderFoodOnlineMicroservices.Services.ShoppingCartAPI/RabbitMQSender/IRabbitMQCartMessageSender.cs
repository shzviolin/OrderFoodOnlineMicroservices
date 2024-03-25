namespace OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(object message, string topic_queue_Name);
    }
}
 