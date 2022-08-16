using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces
{
    public interface IRepositories
    {
        IGenericRepository<Permission> Permissions { get; set; }
        IGenericRepository<PermissionGroup> PermissionGroups { get; set; }
        IGenericRepository<User> Users { get; set; }
        IGenericRepository<UserRole> UserRoles { get; set; }
        IGenericRepository<ActiveCode> ActiveCodes { get; set; }
        IGenericRepository<Role> Roles { get; set; }
        IGenericRepository<RolePermission> RolePermissions { get; set; }
        IGenericRepository<City> Cities { get; set; }
        IGenericRepository<Feature> Features { get; set; }
        IGenericRepository<FeatureEnum> FeatureEnums { get; set; }
        IGenericRepository<FeatureEnumValue> FeatureEnumValues { get; set; }
        IGenericRepository<FeatureInteger> FeatureIntegers { get; set; }
        IGenericRepository<Category> Categories { get; set; }
        IGenericRepository<CategoryFeature> CategoryFeatures { get; set; }
        IGenericRepository<Advertiesement> Advertiesements { get; set; }
        IGenericRepository<AdvertiesementFeatureValue> AdvertiesementFeatureValues { get; set; }
        IGenericRepository<AdvertiesementPicture> AdvertiesementPictures { get; set; }
        IGenericRepository<AdvertiesementPrice> AdvertiesementPrices { get; set; }
    }
}
