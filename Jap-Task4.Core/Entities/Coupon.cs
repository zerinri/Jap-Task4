using System;

namespace Jap_Task4.Core.Entities
{
    public class Coupon : BaseEntity
    {
        public Guid SerialKey { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}