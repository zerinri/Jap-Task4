using System;

namespace Jap_Task4.Core.Dtos.Products
{
    public class GetProductsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}