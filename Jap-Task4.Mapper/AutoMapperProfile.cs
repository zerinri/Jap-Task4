using AutoMapper;
using Jap_Task4.Core.Dtos.Coupons;
using Jap_Task4.Core.Dtos.Offers;
using Jap_Task4.Core.Dtos.Products;
using Jap_Task4.Core.Entities;

namespace Jap_Task4.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductsDto>();
            CreateMap<Product, GetProductByIdDto>();
            CreateMap<AddProductDto, Product>();

            CreateMap<Offer, GetOffersDto>();
            CreateMap<AddOfferDto, Offer>();

            CreateMap<Coupon, GetCouponDto>()
                .ForPath(dest => dest.Product, opt => opt.MapFrom(src => src.Offer.Product));
        }
    }
}