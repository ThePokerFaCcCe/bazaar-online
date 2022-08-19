using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.ViewModels.Advertiesements;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Advertisements
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertiesementController : ControllerBase
    {
        private readonly IAdvertiesementService _advertiesementService;

        public AdvertiesementController(IAdvertiesementService advertiesementService)
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
        public ActionResult CreateAdvertiesement([FromBody] AdvertiesementCreateDTO createDTO)
        {
            if (!ModelState.IsValid) return BadRequest(createDTO);

            var userId = int.Parse(User.Identity.Name);
            var advertiesement = _advertiesementService.CreateAdvertiesement(createDTO, userId);
            return CreatedAtAction(nameof(GetAdvertiesement), new { Id = advertiesement.Id }, null);
        }

    }
}
