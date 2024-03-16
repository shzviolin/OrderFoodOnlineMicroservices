namespace OrderFoodOnlineMicroservices.Web.Models
{
    public class RequestDto
    {
        public string ApiType { get; set; } = "Get";
        public string Url { get; set; }
        public string Data { get; set; }
        public string AccessToken { get; set; }
    }
}
