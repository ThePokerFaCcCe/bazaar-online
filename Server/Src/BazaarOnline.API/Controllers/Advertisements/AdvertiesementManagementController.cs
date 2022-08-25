using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.Advertiesements.Management;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Advertisements
{
    [Route("api/Advertiesements")]
    [ApiController]
    public class AdvertiesementManagementController : ControllerBase
    {
        private readonly IAdvertiesementManagementService _advertiesementManagementService;

        public AdvertiesementManagementController(IAdvertiesementManagementService advertiesementManagementService)
        {
            _advertiesementManagementService = advertiesementManagementService;
        }

        [HttpPost("{id}/Management/Accept")]
        [HasPermission(DefaultPermissions.UpdateAdvertisementId)]
        public ActionResult AcceptAdvertiesement(int id)
        {
            var advertiesement = _advertiesementManagementService.FindAdvertiesement(id);
            if (advertiesement == null) return NotFound();
            if (advertiesement.IsDeleted)
            {
                ModelState.AddModelError(nameof(id), "این آگهی حذف شده است");
                return ValidationProblem(ModelState);
            }

            _advertiesementManagementService.AcceptAdvertiesement(advertiesement);
            return Ok();
        }

        [HttpPost("{id}/Management/Deny")]
        [HasPermission(DefaultPermissions.UpdateAdvertisementId)]
        public ActionResult DenyAdvertiesement(int id, [FromBody] AdvertiesementDenyDTO denyDTO)
        {
            var advertiesement = _advertiesementManagementService.FindAdvertiesement(id);
            if (advertiesement == null) return NotFound();
            if (advertiesement.IsDeleted)
            {
                ModelState.AddModelError(nameof(id), "این آگهی حذف شده است");
                return ValidationProblem(ModelState);
            }

            _advertiesementManagementService.DenyAdvertiesement(advertiesement, denyDTO);
            return Ok();
        }

        [HttpPost("{id}/Management/Delete")]
        [HasPermission(DefaultPermissions.DeleteAdvertisementId)]
        public ActionResult DenyAdvertiesement(int id, [FromBody] AdvertiesementDeleteDTO deleteDTO)
        {
            var advertiesement = _advertiesementManagementService.FindAdvertiesement(id);
            if (advertiesement == null) return NotFound();
            if (advertiesement.IsDeleted)
            {
                ModelState.AddModelError(nameof(id), "این آگهی حذف شده است");
                return ValidationProblem(ModelState);
            }

            _advertiesementManagementService.DeleteAdvertiesement(advertiesement, deleteDTO);
            return NoContent();
        }

        [HttpGet("Management/List")]
        public ActionResult<IEnumerable<AdvertiesementManagementListDetailViewModel>>
            GetAdvertiesementList([FromQuery] AdvertiesementManagementFilterDTO filter,
                                  [FromQuery] PaginationFilterDTO pagination)
        {
            return Ok(_advertiesementManagementService.GetAdvertiesementListDetail(filter, pagination));
        }

        [HttpGet("Management/List/Unaccepted")]
        public ActionResult<IEnumerable<AdvertiesementManagementListDetailViewModel>>
            GetAdvertiesementUnacceptedList([FromQuery] PaginationFilterDTO pagination)
        {
            return Ok(_advertiesementManagementService
                .GetAdvertiesementListDetail(new AdvertiesementManagementFilterDTO
                {
                    IsAccepted = false,
                }, pagination));
        }
    }
}
