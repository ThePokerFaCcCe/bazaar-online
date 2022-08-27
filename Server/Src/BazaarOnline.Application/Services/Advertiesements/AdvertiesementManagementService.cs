using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Filters;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Utils;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Application.ViewModels.Advertiesements.Management;
using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Advertiesements
{
    public class AdvertiesementManagementService : IAdvertiesementManagementService
    {
        private readonly IRepository _repository;

        public AdvertiesementManagementService(IRepository repository)
        {
            _repository = repository;
        }

        public void DenyAdvertiesement(Advertiesement advertiesement, AdvertiesementDenyDTO denyDTO)
        {
            denyDTO.TrimStrings();
            advertiesement.IsDeniedByAdmin = true;
            advertiesement.DeniedByAdminReason = denyDTO.Reason;
            advertiesement.IsAccepted = false;

            _repository.Update(advertiesement);
            _repository.Save();
        }

        public void AcceptAdvertiesement(Advertiesement advertiesement)
        {
            advertiesement.IsAccepted = true;
            advertiesement.IsDeniedByAdmin = false;
            advertiesement.DeniedByAdminReason = null;

            _repository.Update(advertiesement);
            _repository.Save();
        }

        public Advertiesement? FindAdvertiesement(int id)
        {
            return _repository.GetAll<Advertiesement>()
                .IgnoreQueryFilters()
                .SingleOrDefault(a => a.Id == id);
        }

        public void DeleteAdvertiesement(Advertiesement advertiesement, AdvertiesementDeleteDTO deleteDTO)
        {
            deleteDTO.TrimStrings();
            advertiesement.IsDeleted = true;
            advertiesement.IsDeletedByAdmin = true;
            advertiesement.DeniedByAdminReason = deleteDTO.Reason;

            _repository.Update(advertiesement);
            _repository.Save();
        }

        public AdvertiesementManagementDetailViewModel? GetAdvertiesementDetail(int id)
        {
            return _repository.GetAll<Advertiesement>()
                .IgnoreQueryFilters()
                .Where(a => a.Id == id)
                .Include(a => a.City)
                .Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.AdvertiesementPictures)
                .Include(a => a.AdvertiesementPrice)
                .Include(a => a.AdvertiesementFeatureValues)
                    .ThenInclude(afv => afv.Feature)
                .AsEnumerable()
                .Select(a =>
                {
                    var model = ModelHelper.CreateAndFillFromObject
                        <AdvertiesementManagementDetailViewModel, Advertiesement>(a);

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

                    model.Contact = new AdvertiesementContactDetailViewModel()
                        .FillFromObject(a.User);

                    return model;
                })
                .SingleOrDefault();
        }

        public PaginationResultDTO<AdvertiesementManagementListDetailViewModel>
            GetAdvertiesementListDetail(AdvertiesementManagementFilterDTO filter,
                                        PaginationFilterDTO pagination,
                                        int? userId = null)
        {
            var ads = _repository.GetAll<Advertiesement>()
                .IgnoreQueryFilters()
                .Include(a => a.City)
                .Include(a => a.Category)
                .Include(a => a.AdvertiesementPictures)
                .Include(a => a.AdvertiesementPrice)
                .AsQueryable();

            #region Filters
            if (userId != null)
                ads = ads.Where(a => a.UserId == userId);

            filter.TrimStrings();

            ads = ads.Filter(filter);
            #endregion

            #region Pagination
            int count = ads.Count();
            ads = ads.Paginate(pagination);
            #endregion

            return new PaginationResultDTO<AdvertiesementManagementListDetailViewModel>
            {
                Count = count,
                Content = ads.Select(a => new AdvertiesementManagementListDetailViewModel
                {
                    Category = new AdvertiesementCategoryDetailViewModel()
                        .FillFromObject(a.Category, false),

                    City = new AdvertiesementCityDetailViewModel()
                        .FillFromObject(a.City, false),

                    Price = new AdvertiesementPriceDetailViewModel()
                        .FillFromObject(a.AdvertiesementPrice, false),

                    Picture = a.AdvertiesementPictures.Take(1)
                        .Select(p => new AdvertiesementPictureDetailViewModel
                        {
                            Image = $"/{Path.Combine(PathHelper.PAdvertiesementImage, p.PictureName)}",
                            Thumbnail = $"/{Path.Combine(PathHelper.PAdvertiesementThumb, p.PictureName)}",
                        }).FirstOrDefault(),
                }.FillFromObject(a, false)).ToList()
            };
        }

    }
}
