using Jap_Task4.Core.Dtos.Offers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jap_Task4.Services.Interfaces
{
    public interface IOfferService
    {
        Task<ServiceResponse<List<GetOffersDto>>> GetAllOffers();

        Task<ServiceResponse<IEnumerable<GetOffersDto>>> GetOfferBySearch(OfferSearch offerSearch);

        Task AddOffer(AddOfferDto offerDto);
    }
}