using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Securities.Attributes;
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
        public ActionResult DenyAdvertiesement(int id, [FromBody] string? reason)
        {
            var advertiesement = _advertiesementManagementService.FindAdvertiesement(id);
            if (advertiesement == null) return NotFound();
            if (advertiesement.IsDeleted)
            {
                ModelState.AddModelError(nameof(id), "این آگهی حذف شده است");
                return ValidationProblem(ModelState);
            }

            _advertiesementManagementService.DenyAdvertiesement(advertiesement, reason);
            return Ok();
        }
    }
}
