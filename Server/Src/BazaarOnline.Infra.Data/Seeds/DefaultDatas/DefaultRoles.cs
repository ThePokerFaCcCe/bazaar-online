using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Infra.Data.Seeds.DefaultDatas
{
    public class DefaultRoles
    {
        /// <summary>
        /// List of Roles (THEY MAY BE CHANGED!)
        /// </summary>
        public static List<Role> Roles = new List<Role>(){
            new Role
            {
                Id=1,
                Title="مدیر کل",
            },
            new Role
            {
                Id=2,
                Title="ادمین",
            },
            new Role
            {
                Id=3,
                Title="پشتیبان",
            },
            new Role
            {
                Id=4,
                Title="کاربر عادی",
            },
        };


        public static Role Owner = Roles[0];
        public static Role Admin = Roles[1];
        public static Role Operator = Roles[2];
        public static Role NormalUser = Roles[3];

        /// <summary>
        /// List of Roles that shouldn't be changed
        /// </summary>
        public static List<Role> UneditableRoles
            => Roles
            .Where(r => new[] { Owner.Id, NormalUser.Id }
            .Contains(r.Id)).ToList();
    }
}
