using Jap_Task4.Core.Dtos.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jap_Task4.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts();

        Task<ServiceResponse<GetProductByIdDto>> GetProductById(int id);

        Task<ServiceResponse<List<GetProductsDto>>> AddProduct(AddProductDto newProduct);

        bool ProductExists(int id);
    }
}