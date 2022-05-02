using Jap_Task4.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jap_Task4.Database.DataSeed
{
    public static class ProductSeed
    {
        public static void Products(this ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Product>()
            .HasData(
            new Product
            {
                Id = 1,
                Name = "BAJADERA",
                Description = "čokolada, puter, orasi, šlag, keks, džus, puding, mlijeko, vanilija",
                Price = 2,
            },
            new Product
            {
                Id = 2,
                Name = "BOHEM TORTA",
                Description = "jaja, šećer, badem, lješnjak, brašno pšenično, puter, orasi, limun, čokolada",
                Price = 5,
            },
            new Product
            {
                Id = 3,
                Name = "COKOLADNA",
                Description = "jaja, puter, lješnjak, čokolada, kakao, brašno pšenično, šećer, orasi",
                Price = 6,
            },
            new Product
            {
                Id = 4,
                Name = "DIPLOMAT",
                Description = "jaja, brašno pšenično, šećer, lješnjak, čokolada, puter, orasi",
                Price = 4,
            },
            new Product
            {
                Id = 5,
                Name = "HAVANA",
                Description = "šećer, badem, lješnjak, jaja, šlag, mlijeko, džem, cimet, vanilija, oblatne, arome",
                Price = 3,
            }
        );
        }
    }
}