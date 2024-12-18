using Microsoft.AspNetCore.Mvc;
using NeighborhoodAds.Models;
using NeighborhoodAds.Services;

namespace NeighborhoodAds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController(IAdService adService) : Controller
    {
        private readonly IAdService _adService = adService;

        [HttpGet]
        public IActionResult GetAllAds() => Ok(_adService.GetAllAds());

        [HttpPost]
        public IActionResult CreateAd([FromBody] Ad ad)
        {
            _adService.AddAd(ad);
            return Created("", ad);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAd(int id, [FromBody] Ad ad)
        {
            _adService.UpdateAd(id, ad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAd(int id)
        {
            _adService.DeleteAd(id);
            return NoContent();
        }
    }
}
