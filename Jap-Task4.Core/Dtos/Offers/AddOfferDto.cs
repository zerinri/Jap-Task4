using System;
using System.ComponentModel.DataAnnotations;

namespace Jap_Task4.Core.Dtos.Offers
{
    public class AddOfferDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Saving { get; set; }

        public int NumOfCoupons { get; set; }

        [DataType(DataType.Date)]
        public DateTime OfferStarted { get; set; }

        [DataType(DataType.Date)]
        public DateTime OfferEnds { get; set; }

        public int ProductId { get; set; }
    }
}