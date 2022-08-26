using System.ComponentModel.Design.Serialization;
using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Locations;

namespace BazaarOnline.Application.ViewModels.Locations
{
    public class CityListDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AdvertiesementsCount { get; set; }
    }
}
