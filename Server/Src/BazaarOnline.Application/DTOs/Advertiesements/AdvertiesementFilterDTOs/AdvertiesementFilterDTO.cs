using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs
{
    public class AdvertiesementFilterDTO
    {
        public string? Title { get; set; }

        public List<int>? Categories { get; set; }

        public List<int>? Cities { get; set; }

        public AdvertiesementPriceType? PriceType { get; set; }

        public long StartPrice { get; set; } = 0;

        public long EndPrice { get; set; } = Int64.MaxValue;
    }
}
