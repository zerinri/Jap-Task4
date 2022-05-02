using AutoMapper;
using Jap_Task4.Core.Dtos.Products;
using Jap_Task4.Core.Entities;
using Jap_Task4.Database.Data;
using Jap_Task4.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jap_Task4.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();

            Product product = _mapper.Map<Product>(newProduct);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Products
                .Select(c => _mapper.Map<GetProductsDto>(c)).ToListAsync();
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductsDto>(c)).ToList();
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductByIdDto>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductByIdDto>();
            var dbProducts = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetProductByIdDto>(dbProducts);
            serviceResponse.Count = 1;
            return serviceResponse;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(b => b.Id == id);
        }
    }
}