using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Advertiesements
{
    public class AdvertiesementService : IAdvertiesementService
    {
        private readonly IRepository _repository;

        public AdvertiesementService(IRepository repository)
        {
            _repository = repository;
        }

        public Advertiesement CreateAdvertiesement(AdvertiesementCreateDTO createDTO, int userId)
        {
            createDTO.TrimStrings();
            var advertiesement = new Advertiesement
            {
                UserId = userId,
                AdvertiesementPrice = new AdvertiesementPrice()
                    .FillFromObject(createDTO.AdvertiesementPrice),
                AdvertiesementFeatureValues = createDTO.AdvertiesementFeatureValues
                    .Select(af => new AdvertiesementFeatureValue().FillFromObject(af))
                    .ToList(),
            }.FillFromObject(createDTO);

            _repository.Add<Advertiesement>(advertiesement);
            _repository.Save();

            return advertiesement;
        }

        public AdvertiesementDetailViewModel? GetAdvertiesementDetail(int id)
        {
            return _repository.GetAll<Advertiesement>()
                .Where(a => a.Id == id)
                .Include(a => a.City)
                .Include(a => a.Category)
                .Include(a => a.AdvertiesementPictures)
                .Include(a => a.AdvertiesementPrice)
                .Include(a => a.AdvertiesementFeatureValues)
                    .ThenInclude(afv => afv.Feature)
                .AsEnumerable()
                .Select(a =>
                {
                    var model = ModelHelper.CreateAndFillFromObject
                        <AdvertiesementDetailViewModel, Advertiesement>(a);

                    model.Category = ModelHelper.CreateAndFillFromObject
                        <AdvertiesementCategoryDetailViewModel, Category>(a.Category);

                    model.City = ModelHelper.CreateAndFillFromObject
                        <AdvertiesementCityDetailViewModel, City>(a.City);

                    model.Price = ModelHelper.CreateAndFillFromObject
                        <AdvertiesementPriceDetailViewModel, AdvertiesementPrice>
                            (a.AdvertiesementPrice);

                    model.Pictures = a.AdvertiesementPictures
                        .Select(p => new AdvertiesementPictureDetailViewModel
                        {
                            // TODO Add picture urls
                        });

                    model.FeatureValues = a.AdvertiesementFeatureValues
                        .Select(afv => new AdvertiesementFeatureValueDetailViewModel
                        {
                            Title = afv.Feature.Title,
                            Value = afv.Value,
                        });

                    return model;
                })
                .SingleOrDefault();
        }
    }
}
