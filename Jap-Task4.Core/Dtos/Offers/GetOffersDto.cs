using System;

namespace Jap_Task4.Core.Dtos.Offers
{
    public class GetOffersDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Saving { get; set; }

        public int NumOfCoupons { get; set; }
        public bool OfferActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OfferStarted { get; set; }
        public DateTime OfferEnds { get; set; }

        public int ProductId { get; set; }
    }
}