using Jap_Task4.Core.Entities;

namespace Jap_Task4.Core.Dtos.Offers
{
    public class OfferSearch : BaseSearch
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}