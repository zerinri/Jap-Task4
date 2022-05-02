using AutoMapper;
using Jap_Task4.Core.Dtos.Coupons;
using Jap_Task4.Core.Entities;
using Jap_Task4.Database.Data;
using Jap_Task4.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jap_Task4.Services.Services
{
    public class CouponService : ICouponService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CouponService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<GetCouponDto>>> GetCouponBySearch(CouponSearch couponSearch)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCouponDto>>();
            var dbCoupon = new List<Coupon>();

            if (couponSearch.CouponSerialKey != Guid.Empty)
            {
                dbCoupon = await _context.Coupons
                .Include(r => r.Offer)
                .ThenInclude(i => i.Product)
                .Where(r => r.SerialKey == couponSearch.CouponSerialKey)
                .Skip(couponSearch.Skip)
                .Take(couponSearch.PageSize)
                .ToListAsync();
            }
            else if (couponSearch.ProductName != null)
            {
                couponSearch.ProductName = couponSearch.ProductName.Trim();

                dbCoupon = await _context.Coupons
               .Include(r => r.Offer)
               .ThenInclude(i => i.Product)
               .Where(r => r.Offer.Product.Name.Contains(couponSearch.ProductName))
               .Skip(couponSearch.Skip)
               .Take(couponSearch.PageSize)
               .ToListAsync();
            }
            else if (couponSearch.OfferName != null)
            {
                couponSearch.OfferName = couponSearch.OfferName.Trim();

                dbCoupon = await _context.Coupons
               .Include(r => r.Offer)
               .ThenInclude(i => i.Product)
               .Where(r => r.Offer.Name.Contains(couponSearch.OfferName))
               .Skip(couponSearch.Skip)
               .Take(couponSearch.PageSize)
               .ToListAsync();
            }
            else
            {
                dbCoupon = await _context.Coupons
               .Include(r => r.Offer)
               .ThenInclude(i => i.Product)
               .Skip(couponSearch.Skip)
               .Take(couponSearch.PageSize)
               .ToListAsync();
            }

            serviceResponse.Data = dbCoupon.Select(c => _mapper.Map<GetCouponDto>(c));
            serviceResponse.Count = dbCoupon.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCouponDto>>> TakeSingleCoupon(int? offerId)
        {
            var serviceResponse = new ServiceResponse<List<GetCouponDto>>();
            var offer = _context.Offers.FirstOrDefault(o => o.Id == offerId);

            if (offer.NumOfCoupons > 0)
            {
                if (offer.NumOfCoupons == 1)
                {
                    offer.OfferActive = false;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "No coupons left.";
                }
                _context.Coupons.Remove(_context.Coupons.Where(o => o.OfferId == offerId).First());
                offer.NumOfCoupons = offer.NumOfCoupons - 1;
            }
            else
            {
                offer.OfferActive = false;
                serviceResponse.Success = false;
                serviceResponse.Message = "No coupons left.";
            }
            _context.Offers.Update(offer);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Coupons
                    .Select(c => _mapper.Map<GetCouponDto>(c)).ToList();
            return serviceResponse;
        }
    }
}