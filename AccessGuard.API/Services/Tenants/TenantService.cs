using AcessGuard_API.Exceptions;
using AcessGuard_API.Models.Dto.Tenant;
using AcessGuard_API.Repositories.Tenants;

namespace AcessGuard_API.Services.Tenants
{
    public class TenantService: ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public TenantDto Create(TenantToCreateDTO tenantToCreate)
        {
            var tenantDTO = tenantToCreate.ConvertToTenantDTO(Guid.NewGuid());
            _tenantRepository.Add(tenantDTO.ConvertToEntity());
            _tenantRepository.SaveChanges();
            return tenantDTO;
        }

        public void Delete(Guid id)
        {
            var tenantDBO = _tenantRepository.Get(id) ?? throw new AccessGuardException("tenant-404");
            _tenantRepository.Delete(tenantDBO);
            _tenantRepository.SaveChanges();
        }

        public async Task<IEnumerable<TenantDto>> GetAll()
        {
            return (await _tenantRepository.GetAll()).Select(x=> new TenantDto(x.Id,x.TenantName));
        }

        public TenantDto GetById(Guid id, Guid userID)
        {
            // TODO: Implement userVerification when tenant_users repository exists.

            var tenantDBO = _tenantRepository.Get(id) ?? throw new AccessGuardException("tenant-404");
            return new TenantDto(tenantDBO);
        }

        public TenantDto Update(TenantDto tenantToUpdate)
        {
            var tenantDBO = _tenantRepository.Get(tenantToUpdate.Id) ?? throw new AccessGuardException("tenant-404");
            tenantDBO.TenantName = tenantToUpdate.TenantName;
            _tenantRepository.Update(tenantDBO);
            _tenantRepository.SaveChanges();
            return new TenantDto(tenantDBO);
        }
    }
}
