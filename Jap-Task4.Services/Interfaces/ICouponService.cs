using Jap_Task4.Core.Dtos.Coupons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jap_Task4.Services.Interfaces
{
    public interface ICouponService
    {
        Task<ServiceResponse<IEnumerable<GetCouponDto>>> GetCouponBySearch(CouponSearch couponSearch);

        Task<ServiceResponse<List<GetCouponDto>>> TakeSingleCoupon(int? offerId);
    }
}