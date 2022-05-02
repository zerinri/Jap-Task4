using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jap_Task4.Core.Entities
{
    public class Offer : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public float Saving { get; set; }

        [Required]
        public int NumOfCoupons { get; set; }

        public bool OfferActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime OfferStarted { get; set; }

        [DataType(DataType.Date)]
        public DateTime OfferEnds { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<Coupon> Coupons { get; set; }
    }
}