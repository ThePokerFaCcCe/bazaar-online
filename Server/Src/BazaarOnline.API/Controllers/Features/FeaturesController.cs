using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazaarOnline.Application.DTOs.Features;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Interfaces.Features;
using BazaarOnline.Application.ViewModels.Features;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public ActionResult<PaginationResultDTO<FeatureListDetailViewModel>>
            GetFeaturesList([FromQuery] FeatureFilterDTO filterDTO,
                            [FromQuery] PaginationFilterDTO pagination)
        {
            return _featureService.GetFeatureListDetail(filterDTO, pagination);
        }

        [HttpGet("{id}")]
        public ActionResult<FeatureDetailViewModel> GetFeatureDetail(int id)
        {
            var feature = _featureService.GetFeatureDetail(id);
            if (feature == null) return NotFound();

            return Ok(feature);
        }

        [HttpPost]
        public ActionResult Post([FromBody] FeatureCreateDTO createDTO)
        {
            if (!ModelState.IsValid) return BadRequest(createDTO);

            var feature = _featureService.CreateFeature(createDTO);
            return CreatedAtAction(nameof(GetFeatureDetail),
                new { Id = feature.Id }, null);
        }

        [HttpPut("{id}/FeatureEnum")]
        public ActionResult UpdateFeatureEnum(int id, [FromBody] FeatureEnumUpdateDTO updateDTO)
        {
            var feature = _featureService.FindFeature(id, includeType: true);
            if (feature?.FeatureEnum == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(updateDTO);

            _featureService.UpdateFeatureEnum(feature.FeatureEnum, updateDTO);
            return Ok();
        }

        [HttpPut("{id}/FeatureInteger")]
        public ActionResult UpdateFeatureInteger(int id, [FromBody] FeatureIntegerUpdateDTO updateDTO)
        {
            var feature = _featureService.FindFeature(id, includeType: true);
            if (feature?.FeatureInteger == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(updateDTO);

            _featureService.UpdateFeatureInteger(feature.FeatureInteger, updateDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
