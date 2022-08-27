using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Advertisements
{
    [Route("api/Advertiesements/Mine")]
    [Authorize]
    [ApiController]
    public class AdvertiesementDashboardController : ControllerBase
    {
        private readonly IAdvertiesementService _advertiesementService;
        private readonly IAdvertiesementManagementService _advertiesementManagementService;

        public AdvertiesementDashboardController(IAdvertiesementService advertiesementService, IAdvertiesementManagementService advertiesementManagementService)
        {
            _advertiesementService = advertiesementService;
            _advertiesementManagementService = advertiesementManagementService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdvertiesementListDetailViewModel>>
            GetAdvertiesementList([FromQuery] AdvertiesementManagementFilterDTO filter,
                                  [FromQuery] PaginationFilterDTO pagination)
        {
            var userId = int.Parse(User.Identity.Name);
            return Ok(_advertiesementManagementService
                .GetAdvertiesementListDetail(filter, pagination, userId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMyAdvertiesement(int id)
        {

            var advertiesement = _advertiesementService.FindAdvertiesement(id);
            if (advertiesement == null) return NotFound();

            var userId = int.Parse(User.Identity.Name);
            if (advertiesement.UserId != userId) return Forbid();

            if (advertiesement.IsDeleted)
            {
                ModelState.AddModelError(nameof(id), "این آگهی حذف شده است");
                return ValidationProblem(ModelState);
            }

            _advertiesementService.DeleteAdvertiesement(advertiesement);
            return NoContent();
        }
    }
}
