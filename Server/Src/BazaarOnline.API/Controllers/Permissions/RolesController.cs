using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace Testing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService _roleService;

        public RolesController(ILogger<RolesController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet("")]
        [HasPermission(DefaultPermissions.GetRolesId)]
        public ActionResult<IEnumerable<RoleDetailListViewModel>> GetRoles()
        {
            return Ok(_roleService.GetRoles());
        }

        [HttpGet("{id}")]
        [HasPermission(DefaultPermissions.GetRolesId)]
        public ActionResult<RoleDetailViewModel> GetRoleById(int id)
        {
            var result = _roleService.FindRole(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        [HasPermission(DefaultPermissions.CreateRoleId)]
        public ActionResult<RoleDetailViewModel> CreateRole(RoleCreateViewModel roleModel)
        {
            var role = _roleService.CreateRole(roleModel);
            return CreatedAtAction(nameof(GetRoleById), new { Id = role.Id }, role);
        }

    }
}
