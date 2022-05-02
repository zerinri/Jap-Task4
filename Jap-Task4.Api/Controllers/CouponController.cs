using Jap_Task4.Core.Dtos.Coupons;
using Jap_Task4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jap_Task4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetSearch([FromQuery] CouponSearch couponSearch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _couponService.GetCouponBySearch(couponSearch));
        }

        [HttpDelete("{offerId}")]
        public async Task<IActionResult> TakeSingleCoupon(int offerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _couponService.TakeSingleCoupon(offerId));
        }
    }
}