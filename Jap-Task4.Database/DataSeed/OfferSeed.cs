using Jap_Task4.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jap_Task4.Database.DataSeed
{
    public static class OfferSeed
    {
        public static void Offers(this ModelBuilder modelBuilder)
        {
            modelBuilder
           .Entity<Offer>()
           .HasData(
           new Offer
           {
               Id = 1,
               Name = "BAJADERA 1+1",
               Description = "Dvije po cijeni jedne",
               Saving = 2,
               ProductId = 1,
               NumOfCoupons = 2,
               OfferActive = true,
               OfferStarted = new DateTime(2022, 1, 1),
               OfferEnds = new DateTime(2022, 5, 5),
           },
            new Offer
            {
                Id = 2,
                Name = "COKOLADNA 1+1",
                Description = "Dvije po cijeni jedne",
                Saving = 3,
                ProductId = 3,
                NumOfCoupons = 2,
                OfferActive = true,
                OfferStarted = new DateTime(2022, 3, 3),
                OfferEnds = new DateTime(2022, 7, 7),
            }
           );
        }
    }
}