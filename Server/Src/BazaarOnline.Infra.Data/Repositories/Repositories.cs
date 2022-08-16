using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;

namespace BazaarOnline.Infra.Data.Repositories
{
    public class Repositories : IRepositories
    {

        public Repositories(IGenericRepository<Permission> permissions, IGenericRepository<PermissionGroup> permissionGroups, IGenericRepository<User> users, IGenericRepository<UserRole> userRoles, IGenericRepository<ActiveCode> activeCodes, IGenericRepository<Role> roles, IGenericRepository<RolePermission> rolePermissions, IGenericRepository<City> cities, IGenericRepository<Feature> features, IGenericRepository<FeatureEnum> featureEnums, IGenericRepository<FeatureEnumValue> featureEnumValues, IGenericRepository<FeatureInteger> featureIntegers, IGenericRepository<Category> categories, IGenericRepository<CategoryFeature> categoryFeatures, IGenericRepository<Advertiesement> advertiesements, IGenericRepository<AdvertiesementFeatureValue> advertiesementFeatureValues, IGenericRepository<AdvertiesementPicture> advertiesementPictures, IGenericRepository<AdvertiesementPrice> advertiesementPrices)
        {
            Permissions = permissions;
            PermissionGroups = permissionGroups;
            Users = users;
            UserRoles = userRoles;
            ActiveCodes = activeCodes;
            Roles = roles;
            RolePermissions = rolePermissions;
            Cities = cities;
            Features = features;
            FeatureEnums = featureEnums;
            FeatureEnumValues = featureEnumValues;
            FeatureIntegers = featureIntegers;
            Categories = categories;
            CategoryFeatures = categoryFeatures;
            Advertiesements = advertiesements;
            AdvertiesementFeatureValues = advertiesementFeatureValues;
            AdvertiesementPictures = advertiesementPictures;
            AdvertiesementPrices = advertiesementPrices;
        }

        public IGenericRepository<Permission> Permissions { get; set; }
        public IGenericRepository<PermissionGroup> PermissionGroups { get; set; }
        public IGenericRepository<User> Users { get; set; }
        public IGenericRepository<UserRole> UserRoles { get; set; }
        public IGenericRepository<ActiveCode> ActiveCodes { get; set; }
        public IGenericRepository<Role> Roles { get; set; }
        public IGenericRepository<RolePermission> RolePermissions { get; set; }
        public IGenericRepository<City> Cities { get; set; }
        public IGenericRepository<Feature> Features { get; set; }
        public IGenericRepository<FeatureEnum> FeatureEnums { get; set; }
        public IGenericRepository<FeatureEnumValue> FeatureEnumValues { get; set; }
        public IGenericRepository<FeatureInteger> FeatureIntegers { get; set; }
        public IGenericRepository<Category> Categories { get; set; }
        public IGenericRepository<CategoryFeature> CategoryFeatures { get; set; }
        public IGenericRepository<Advertiesement> Advertiesements { get; set; }
        public IGenericRepository<AdvertiesementFeatureValue> AdvertiesementFeatureValues { get; set; }
        public IGenericRepository<AdvertiesementPicture> AdvertiesementPictures { get; set; }
        public IGenericRepository<AdvertiesementPrice> AdvertiesementPrices { get; set; }
    }
}
