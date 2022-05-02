using Jap_Task4.Core.Dtos.Offers;
using Jap_Task4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jap_Task4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _offerService.GetAllOffers());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOfferDto offerDto)
        {
            await _offerService.AddOffer(offerDto);
            return Ok(offerDto);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetSearch([FromQuery] OfferSearch offerSearch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _offerService.GetOfferBySearch(offerSearch));
        }
    }
}