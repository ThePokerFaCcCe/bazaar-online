using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs
{
    public class AdvertiesementFilterDTO
    {
        public string? Title { get; set; }

        public IEnumerable<int>? Categories { get; set; }

        public IEnumerable<int>? Cities { get; set; }

        public AdvertiesementPriceType? PriceType { get; set; }

        public long? StartPrice { get; set; }

        public long? EndPrice { get; set; }
    }
}
