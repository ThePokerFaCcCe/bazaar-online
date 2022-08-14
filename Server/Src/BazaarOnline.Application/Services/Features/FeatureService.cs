using BazaarOnline.Application.DTOs.Features;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.Interfaces.Features;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Interfaces.Features;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Features
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public Feature CreateFeature(FeatureCreateDTO createDTO)
        {
            createDTO.TrimStrings();
            createDTO.FeatureEnum?.TrimStrings();
            createDTO.FeatureEnum?.FeatureEnumValues?.TrimStrings();
            createDTO.FeatureInteger?.TrimStrings();

            var feature = new Feature
            {
                Title = createDTO.Title,
                FeatureType = createDTO.FeatureType,
                IsRequired = createDTO.IsRequired,
                FeatureEnum = createDTO.FeatureEnum == null ? null :
                    new FeatureEnum
                    {
                        Name = createDTO.FeatureEnum.Name,
                        FeatureEnumValues = createDTO.FeatureEnum.FeatureEnumValues
                        .Select(fe => new FeatureEnumValue
                        {
                            Value = fe.Value,
                        }).ToList(),
                    },
                FeatureInteger = createDTO.FeatureInteger == null ? null :
                    new FeatureInteger
                    {
                        MaximumValue = createDTO.FeatureInteger.MaximumValue,
                        MinimumValue = createDTO.FeatureInteger.MinimumValue,
                        Name = createDTO.FeatureInteger.Name,
                    }
            };

            _featureRepository.AddFeature(feature);
            _featureRepository.Save();
            return feature;
        }

        public void DeleteFeature(Feature feature)
        {
            _featureRepository.DeleteFeature(feature);
            _featureRepository.Save();
        }

        public Feature? FindFeature(int id, bool includeType = false)
        {
            if (!includeType)
                return _featureRepository.FindFeature(id);

            return _featureRepository.GetFeatures()
                .Where(f => f.Id == id)
                .Include(f => f.FeatureInteger)
                .Include(f => f.FeatureEnum)
                .ThenInclude(fe => fe.FeatureEnumValues)
                .SingleOrDefault();
        }

        public FeatureDetailViewModel? GetFeatureDetail(int id)
        {
            return _featureRepository.GetFeatures()
                .Where(f => f.Id == id)
                .Include(f => f.FeatureInteger)
                .Include(f => f.FeatureEnum)
                .ThenInclude(fe => fe.FeatureEnumValues)
                .AsEnumerable()
                .Select(f =>
                {
                    var model = ModelHelper.CreateAndFillFromObject
                        <FeatureDetailViewModel, Feature>(f);

                    if (f.FeatureEnum != null)
                    {
                        model.Enum = ModelHelper.CreateAndFillFromObject
                            <FeatureDetailEnumDetailViewModel, FeatureEnum>(f.FeatureEnum);

                        model.Enum.Values = f.FeatureEnum.FeatureEnumValues
                            .Select(fev =>
                                ModelHelper.CreateAndFillFromObject
                                    <FeatureDetailEnumValueDetailViewModel, FeatureEnumValue>(fev))
                            .ToList();
                    }
                    if (f.FeatureInteger != null)
                    {
                        model.Integer = ModelHelper.CreateAndFillFromObject
                            <FeatureDetailIntegerDetailViewModel, FeatureInteger>(f.FeatureInteger);
                    }

                    return model;
                }).SingleOrDefault();

        }

        public List<int> GetFeatureIds()
        {
            return _featureRepository.GetFeatures()
                .Select(f => f.Id)
                .ToList();
        }

        public PaginationResultDTO<FeatureListDetailViewModel> GetFeatureListDetail(FeatureFilterDTO filter, PaginationFilterDTO pagination)
        {

            var features = _featureRepository.GetFeatures();
            int count = features.Count();

            #region Filters
            filter.TrimStrings();

            if (filter.FeatureType != null)
                features = features.Where(f => f.FeatureType == filter.FeatureType);

            if (filter.Title != null)
                features = features.Where(f => f.Title.ToLower().Contains(filter.Title.ToLower()));

            #endregion

            #region Pagination
            features = features.Paginate(pagination);
            #endregion

            return new PaginationResultDTO<FeatureListDetailViewModel>
            {
                Count = count,
                Content = features.Select(f =>
                    ModelHelper.CreateAndFillFromObject
                        <FeatureListDetailViewModel, Feature>(f, false))
                    .ToList()
            };
        }

        public void UpdateFeatureEnum(FeatureEnum featureEnum, FeatureEnumUpdateDTO updateDTO)
        {
            updateDTO.TrimStrings();
            featureEnum.Name = updateDTO.Name;

            if (updateDTO.FeatureEnumValues != null)
            {
                _featureRepository.DeleteFeatureEnumValueRange(featureEnum.Id);
                _featureRepository.AddFeatureEnumValueRange(
                    updateDTO.FeatureEnumValues
                    .Select(fev => new FeatureEnumValue
                    {
                        FeatureEnumId = featureEnum.Id,
                        Value = fev.Value,
                    }
                ).ToArray());
            }

            _featureRepository.UpdateFeatureEnum(featureEnum);
            _featureRepository.Save();
        }

        public void UpdateFeatureInteger(FeatureInteger featureInteger, FeatureIntegerUpdateDTO updateDTO)
        {
            updateDTO.TrimStrings();
            featureInteger.FillFromObject(updateDTO);

            _featureRepository.UpdateFeatureInteger(featureInteger);
            _featureRepository.Save();
        }
    }
}
