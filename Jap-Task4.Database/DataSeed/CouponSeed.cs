using Jap_Task4.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jap_Task4.Database.DataSeed
{
    public static class CouponSeed
    {
        public static void Coupons(this ModelBuilder modelBuilder)
        {
            modelBuilder
           .Entity<Coupon>()
           .HasData(
                new Coupon
                {
                    Id = 1,
                    OfferId = 1,
                    SerialKey = Guid.Parse("05fcf93a-ed8d-45c9-8652-2a8d45dd5250"),
                },
                   new Coupon
                   {
                       Id = 2,
                       OfferId = 1,
                       SerialKey = Guid.Parse("b25eb7b7-b465-41ec-861f-64fa1d4bf1c1"),
                   },
                    new Coupon
                    {
                        Id = 3,
                        OfferId = 2,
                        SerialKey = Guid.Parse("8b78e8c5-de3f-4c72-bc50-2e7335ea31eb"),
                    },
                   new Coupon
                   {
                       Id = 4,
                       OfferId = 2,
                       SerialKey = Guid.Parse("79501f66-3974-4852-bca2-68a5b7954f6f"),
                   }
                );
        }
    }
}