using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Infra.Data.Seeds.DefaultDatas
{
    public class DefaultPermissionGroups
    {
        /// <summary>
        /// List of permission groups that exists in database.
        /// </summary>
        public static List<PermissionGroup> Groups = new List<PermissionGroup>()
        {
            new PermissionGroup
            {
                Id = 1,
                Title = "User Management"
            },
            new PermissionGroup
            {
                Id = 2,
                Title = "Advertisement Management"
            },
            new PermissionGroup
            {
                Id = 3,
                Title = "Category Management"
            },
            new PermissionGroup
            {
                Id = 4,
                Title = "Role Management"
            },
        };

        public static PermissionGroup UserManagment = Groups[0];
        public static PermissionGroup AdvertisementManagment = Groups[1];
        public static PermissionGroup CategoryManagment = Groups[2];
        public static PermissionGroup RoleManagment = Groups[3];


    }
}
