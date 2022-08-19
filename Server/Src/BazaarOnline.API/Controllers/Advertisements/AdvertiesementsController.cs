using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Advertisements
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertiesementsController : ControllerBase
    {
        private readonly IAdvertiesementService _advertiesementService;

        public AdvertiesementsController(IAdvertiesementService advertiesementService)
        {
            _advertiesementService = advertiesementService;
        }

        [HttpGet("{id}")]
        public ActionResult<AdvertiesementDetailViewModel> GetAdvertiesement(int id)
        {
            var advertiesement = _advertiesementService.GetAdvertiesementDetail(id);
            if (advertiesement == null) return NotFound();

            return Ok(advertiesement);
        }

        [HttpPost]
        [HasPermission(DefaultPermissions.CreateAdvertisementId)]
        public ActionResult CreateAdvertiesement([FromForm] AdvertiesementCreateDTO createDTO)
        {
            if (!ModelState.IsValid) return BadRequest(createDTO);

            var userId = int.Parse(User.Identity.Name);
            var advertiesement = _advertiesementService.CreateAdvertiesement(createDTO, userId);
            return CreatedAtAction(nameof(GetAdvertiesement), new { Id = advertiesement.Id }, null);
        }
    }
}
