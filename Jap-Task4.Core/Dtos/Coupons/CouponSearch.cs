using Jap_Task4.Core.Entities;
using System;

namespace Jap_Task4.Core.Dtos.Coupons
{
    public class CouponSearch : BaseSearch
    {
        public Guid CouponSerialKey { get; set; }
        public string ProductName { get; set; }
        public string OfferName { get; set; }
    }
}