using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Infra.Data.Seeds.DefaultDatas
{
    public class DefaultRolePermissions
    {
        /// <summary>
        /// Creates list of role permissions for a role id 
        /// </summary>
        /// <param name="roleId">role id that used for every 'RolePermission'</param>
        /// <param name="excludePerms">list of permission ids to exclude</param>
        /// <param name="excludeGroups">list of permission group ids to exclude</param>
        /// <param name="onlyPerms">List of permission ids for creating(if not null, excludes doesn't matter anymore)</param>
        /// <returns>List of created 'RolePermission's</returns>
        private static List<RolePermission> _GetAllRolePermissions(int roleId, int[]? excludePerms = null, int[]? excludeGroups = null, int[]? onlyPerms = null)
        {
            List<RolePermission> rolePermissions = new List<RolePermission>();
            List<Permission> permissions = DefaultPermissions.Permissions.ToList();

            if (excludeGroups != null)
            {
                permissions = permissions.Where(p => !excludeGroups.Contains(p.PermissionGroupId)).ToList();
            }

            if (excludePerms != null)
            {
                permissions = permissions.Where(p => !excludePerms.Contains(p.Id)).ToList();
            }

            if (onlyPerms != null)
            {
                permissions = DefaultPermissions.Permissions.ToList()
                                .Where(p => onlyPerms.Contains(p.Id)).ToList();
            }

            permissions.ForEach(p => rolePermissions.Add(
                new RolePermission { RoleId = roleId, PermissionId = p.Id }
            ));

            return rolePermissions;
        }

        private static List<RolePermission> _OwnerRPs = _GetAllRolePermissions(DefaultRoles.Owner.Id);

        private static List<RolePermission> _AdminRPs = _GetAllRolePermissions(DefaultRoles.Admin.Id,
                excludePerms: new int[]
                {
                    DefaultPermissions.UpdateUserRolesId,
                });

        private static List<RolePermission> _OperatorRPs = _GetAllRolePermissions(DefaultRoles.Operator.Id,
                onlyPerms: new int[]
                {
                    DefaultPermissions.CreateUserId,
                    DefaultPermissions.UpdateUserId,
                    DefaultPermissions.GetUserDetailId,
                });

        private static List<RolePermission> _NormalUserRPs = _GetAllRolePermissions(DefaultRoles.NormalUser.Id,
                onlyPerms: new int[]
                {
                    DefaultPermissions.CreateAdvertisementId,
                });


        /// <summary>
        /// List of Default RolePermissions(THEY MAY BE CHANGED!)
        /// </summary>
        public static List<RolePermission> RolePermissions
        {
            get
            {

                List<RolePermission> rolePermissions = new List<RolePermission>();

                rolePermissions.AddRange(_OwnerRPs);
                rolePermissions.AddRange(_AdminRPs);
                rolePermissions.AddRange(_OperatorRPs);
                rolePermissions.AddRange(_NormalUserRPs);

                return rolePermissions;
            }
        }
    }
}
