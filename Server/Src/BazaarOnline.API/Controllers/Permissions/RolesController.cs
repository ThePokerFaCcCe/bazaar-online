using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers
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
            var result = _roleService.GetRoleDetail(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        [HasPermission(DefaultPermissions.CreateRoleId)]
        public ActionResult<RoleDetailViewModel> CreateRole(RoleCreateDTO roleModel)
        {
            if (!ModelState.IsValid) return BadRequest(roleModel);

            var roleId = _roleService.CreateRole(roleModel);
            return CreatedAtAction(nameof(GetRoleById), new { Id = roleId });
        }

        [HttpPut("{id}")]
        [HasPermission(DefaultPermissions.UpdateRoleId)]
        public ActionResult UpdateRole(int id, [FromBody] RoleUpdateDTO updateDTO)
        {
            if (_roleService.IsRoleUneditable(id))
            {
                ModelState.AddModelError(nameof(id),
                    "شما نمیتوانید این نقش را تغییر دهید");
                return ValidationProblem(ModelState);
            }

            var role = _roleService.FindRole(id);
            if (role == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(updateDTO);

            _roleService.UpdateRole(role, updateDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        [HasPermission(DefaultPermissions.DeleteRoleId)]
        public ActionResult DeleteRole(int id)
        {
            if (_roleService.IsRoleUneditable(id))
            {
                ModelState.AddModelError(nameof(id),
                    "شما نمیتوانید این نقش را حذف کنید");
                return ValidationProblem(ModelState);
            }

            var role = _roleService.FindRole(id);
            if (role == null) return NotFound();

            _roleService.DeleteRole(role);
            return NoContent();
        }

    }
}
