using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFoodOnlineMicroservices.Web.Models.Dto;
using OrderFoodOnlineMicroservices.Web.Service.IService;

namespace OrderFoodOnlineMicroservices.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? coupons = new();
            ResponseDto? response = await _couponService.GetAllCouponsAsync();
            if (response != null && response.IsSuccess)
            {
                coupons = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }

            return View(coupons);
        }
    }
}
