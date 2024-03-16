namespace OrderFoodOnlineMicroservices.Web.Utility
{
    public class StaticDetails
    {
        public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
