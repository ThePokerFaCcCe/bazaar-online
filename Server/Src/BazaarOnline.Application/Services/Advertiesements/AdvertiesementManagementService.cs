using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement;
using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Domain.Entities.Advertiesements;
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
    }
}
