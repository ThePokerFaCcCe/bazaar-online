using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers.Permissions

{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> _logger;
        private readonly IPermissionService _permissionService;

        public PermissionsController(ILogger<PermissionsController> logger, IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet]
        [HasPermission(DefaultPermissions.GetPemissionsId)]
        public ActionResult<IEnumerable<PermissionGroupDetailViewModel>> Get()
        {
            return Ok(_permissionService.GetPermissionGroups());
        }

    }
}
