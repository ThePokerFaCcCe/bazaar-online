using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Filters;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Utils;
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
        private readonly ICategoryHirearchyService _categoryHirearchyService;

        public AdvertiesementService(IRepository repository, ICategoryHirearchyService categoryHirearchyService)
        {
            _repository = repository;
            _categoryHirearchyService = categoryHirearchyService;
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
                AdvertiesementPictures = createDTO.AdvertiesementPictures
                    .Select(p => new AdvertiesementPicture
                    {
                        PictureName = FileHelper.SaveImageWithThumb(
                            p,
                            PathHelper.PAdvertiesementImage,
                            PathHelper.PAdvertiesementThumb
                            )
                    }).ToList(),
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
                            Image = $"/{Path.Combine(PathHelper.PAdvertiesementImage, p.PictureName)}",
                            Thumbnail = $"/{Path.Combine(PathHelper.PAdvertiesementThumb, p.PictureName)}",
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

        public Advertiesement? FindAdvertiesement(int id)
        {
            return _repository.Get<Advertiesement>(id);
        }

        public PaginationResultDTO<AdvertiesementListDetailViewModel>
            GetAdvertiesementListDetail(AdvertiesementGlobalFilterDTO filter, PaginationFilterDTO pagination)
        {
            var ads = _repository.GetAll<Advertiesement>()
                .Include(a => a.City)
                .Include(a => a.Category)
                .Include(a => a.AdvertiesementPictures)
                .Include(a => a.AdvertiesementPrice)
                .AsQueryable();

            #region Filters
            filter.TrimStrings();
            ads = ads.Filter(filter);
            #endregion

            int count = ads.Count();
            #region Pagination
            ads = ads.Paginate(pagination);
            #endregion

            return new PaginationResultDTO<AdvertiesementListDetailViewModel>
            {
                Count = count,
                Content = ads.Select(a => new AdvertiesementListDetailViewModel
                {
                    Category = new AdvertiesementCategoryDetailViewModel()
                        .FillFromObject(a.Category, false),

                    City = new AdvertiesementCityDetailViewModel()
                        .FillFromObject(a.City, false),

                    Price = new AdvertiesementPriceDetailViewModel()
                        .FillFromObject(a.AdvertiesementPrice, false),

                    Picture = a.AdvertiesementPictures.Any() ?
                        new AdvertiesementPictureDetailViewModel()
                            .FillFromObject(a.AdvertiesementPictures.First(), false)
                        : null,
                }.FillFromObject(a, false)).ToList()
            };
        }
    }
}
