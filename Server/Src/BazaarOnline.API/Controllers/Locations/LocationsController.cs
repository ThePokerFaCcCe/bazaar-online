using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.ViewModels.Locations;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Locations
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("Cities")]
        public ActionResult<List<CityListDetailViewModel>>
            GetCitiesList([FromQuery] CityFilterDTO filterDTO)
        {
            return _locationService.GetCitiesListDetail(filterDTO);
        }

        [HttpGet("Cities/{id}")]
        public ActionResult<CityDetailViewModel> GetCityDetail(int id)
        {
            var city = _locationService.GetCityDetail(id);
            if (city == null) return NotFound();

            return Ok(city);
        }

    }
}
