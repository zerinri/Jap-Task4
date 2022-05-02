using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jap_Task4.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public List<Offer> Offers { get; set; }
    }
}