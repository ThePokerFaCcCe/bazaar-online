using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Infra.Data.Seeds.DefaultDatas
{
    public class DefaultPermissions
    {

        #region UserManagementIds

        public const int CreateUserId = 1;
        public const int UpdateUserId = 2;
        public const int UpdateUserRolesId = 7;
        public const int GetUserDetailId = 8;
        public const int DeleteUserId = 16;

        #endregion

        #region CategoryManagementIds

        public const int CreateCategoryId = 3;
        public const int UpdateCategoryId = 4;
        public const int DeleteCategoryId = 15;

        #endregion

        #region AdvertisementManagementIds

        public const int CreateAdvertisementId = 5;
        public const int UpdateAdvertisementId = 6;
        public const int DeleteAdvertisementId = 14;

        #endregion

        #region PermissionManagementIds

        public const int GetPemissionsId = 9;
        public const int GetRolesId = 10;
        public const int CreateRoleId = 11;
        public const int UpdateRoleId = 12;
        public const int DeleteRoleId = 13;

        #endregion

        /// <summary>
        /// List of permissions that exists in database
        /// </summary>
        public static List<Permission> Permissions = new List<Permission>(){
            new Permission{
                Id=CreateUserId,
                PermissionGroupId=DefaultPermissionGroups.UserManagment.Id,
                Title="ساخت کاربر",
            },
            new Permission{
                Id=UpdateUserId,
                PermissionGroupId=DefaultPermissionGroups.UserManagment.Id,
                Title="ویرایش کاربر",
            },
            new Permission{
                Id=CreateCategoryId,
                PermissionGroupId=DefaultPermissionGroups.CategoryManagment.Id,
                Title="ساخت دسته بندی",
            },
            new Permission{
                Id=UpdateCategoryId,
                PermissionGroupId=DefaultPermissionGroups.CategoryManagment.Id,
                Title="ویرایش دسته بندی",
            },

            new Permission{
                Id=CreateAdvertisementId,
                PermissionGroupId=DefaultPermissionGroups.AdvertisementManagment.Id,
                Title="ساخت آگهی",
            },
            new Permission{
                Id=UpdateAdvertisementId,
                PermissionGroupId=DefaultPermissionGroups.AdvertisementManagment.Id,
                Title="ویرایش آگهی",
            },
            new Permission{
                Id=UpdateUserRolesId,
                PermissionGroupId=DefaultPermissionGroups.UserManagment.Id,
                Title="ویرایش نقش های کاربر",
            },
            new Permission{
                Id=GetUserDetailId,
                PermissionGroupId=DefaultPermissionGroups.UserManagment.Id,
                Title="مشاهده مشخصات کاربران",
            },
            new Permission{
                Id=GetPemissionsId,
                PermissionGroupId=DefaultPermissionGroups.RoleManagment.Id,
                Title="مشاهده دسترسی ها",
            },
            new Permission{
                Id=GetRolesId,
                PermissionGroupId=DefaultPermissionGroups.RoleManagment.Id,
                Title="مشاهده اطلاعات نقس",
            },
            new Permission{
                Id=CreateRoleId,
                PermissionGroupId=DefaultPermissionGroups.RoleManagment.Id,
                Title="ساخت نقش",
            },
            new Permission{
                Id=UpdateRoleId,
                PermissionGroupId=DefaultPermissionGroups.RoleManagment.Id,
                Title="ویرایش نقش",
            },
            new Permission{
                Id=DeleteRoleId,
                PermissionGroupId=DefaultPermissionGroups.RoleManagment.Id,
                Title="حذف نقش",
            },
            new Permission{
                Id=DeleteAdvertisementId,
                PermissionGroupId=DefaultPermissionGroups.AdvertisementManagment.Id,
                Title="حذف آگهی",
            },
            new Permission{
                Id=DeleteCategoryId,
                PermissionGroupId=DefaultPermissionGroups.CategoryManagment.Id,
                Title="حذف دسته بندی",
            },
            new Permission{
                Id=DeleteUserId,
                PermissionGroupId=DefaultPermissionGroups.UserManagment.Id,
                Title="حذف کاربر",
            },


        };

    }
}
