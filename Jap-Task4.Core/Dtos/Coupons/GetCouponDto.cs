using Jap_Task4.Core.Dtos.Products;
using System;

namespace Jap_Task4.Core.Dtos.Coupons
{
    public class GetCouponDto
    {
        public Guid SerialKey { get; set; }
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public GetProductByIdDto Product { get; set; }
    }
}