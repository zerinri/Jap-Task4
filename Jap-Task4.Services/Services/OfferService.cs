using AutoMapper;
using Jap_Task4.Core.Dtos.Offers;
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
    public class OfferService : IOfferService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddOffer(AddOfferDto offerDto)
        {
            var newOffer = new Offer()
            {
                Name = offerDto.Name,
                Description = offerDto.Description,
                Saving = offerDto.Saving,
                ProductId = offerDto.ProductId,
                OfferActive = true,
                OfferStarted = offerDto.OfferStarted,
                OfferEnds = offerDto.OfferEnds,
                NumOfCoupons = offerDto.NumOfCoupons,
                CreatedDate = DateTime.Now
            };
            _context.Offers.Add(newOffer);
            _context.SaveChanges();

            var coupons = new List<Coupon>();

            for (int i = 0; i < newOffer.NumOfCoupons; i++)
            {
                coupons.Add(
                      new Coupon()
                      {
                          OfferId = newOffer.Id,
                          SerialKey = Guid.NewGuid(),
                          CreatedDate = DateTime.Now,
                      }
                   );
            }
            _context.Coupons.AddRange(coupons);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<List<GetOffersDto>>> GetAllOffers()
        {
            var serviceResponse = new ServiceResponse<List<GetOffersDto>>();
            var dbOffers = await _context.Offers.ToListAsync();
            serviceResponse.Data = dbOffers.Select(c => _mapper.Map<GetOffersDto>(c)).ToList();
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetOffersDto>>> GetOfferBySearch(OfferSearch offerSearch)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetOffersDto>>();
            var dbOffers = new List<Offer>();

            if (offerSearch.Name != null)
            {
                offerSearch.Name = offerSearch.Name.Trim();
                dbOffers = await _context.Offers
               .Where(c => c.Name.Contains(offerSearch.Name))
               .Where(a => a.OfferActive.Equals(offerSearch.IsAvailable))
               .Skip(offerSearch.Skip)
               .Take(offerSearch.PageSize)
               .ToListAsync();
            }
            else if (offerSearch.IsAvailable == false || offerSearch.IsAvailable == true)
            {
                dbOffers = await _context.Offers
                .Where(a => a.OfferActive.Equals(offerSearch.IsAvailable))
                .Skip(offerSearch.Skip)
                .Take(offerSearch.PageSize)
               .ToListAsync();
            }
            else
            {
                dbOffers = await _context.Offers
                 .ToListAsync();
            }
            serviceResponse.Data = dbOffers.Select(c => _mapper.Map<GetOffersDto>(c));
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }
    }
}