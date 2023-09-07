using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Dto.Other;
using AccessGuard_API.Models.Dto.Tenant;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Models.Extensions;
using AccessGuard_API.Repositories.Tenants;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccessGuard_API.Services.Tenants
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
            TenantDto tenantDTO = tenantToCreate.ToDto();
            tenantDTO.Id = Guid.NewGuid();
            Tenant tenantDBO = tenantDTO.ToEntity();
            _tenantRepository.Add(tenantDBO);
            _tenantRepository.SaveChanges();
            return tenantDTO;
        }

        public void Delete(Guid id)
        {
            var tenantDBO = _tenantRepository.Get(id) ?? throw new AccessGuardException("tenant-0404");
            _tenantRepository.Delete(tenantDBO);
            _tenantRepository.SaveChanges();
        }

        public async Task<Paginator<TenantDto>> GetAll(int page = 1, int pageSize = 25)
        {
            var results = _tenantRepository.GetAll(page, pageSize).Result;
            int totalCount = _tenantRepository.Count();

            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);


            Paginator<TenantDto> paginator = new()
            {
                PageCount = pageCount,
                PageSize = pageSize,
                PageIndex = page,
                TotalCount = totalCount,
                Results = results.Select(x => x.ToDto())
            };

            return paginator;
        }

        public TenantDto Get(Guid id)
        {
            var tenantDBO = _tenantRepository.Get(id) ?? throw new AccessGuardException("tenant-0404");
            return tenantDBO.ToDto();
        }

        public TenantDto Update(TenantDto tenantToUpdate)
        {
            var tenantDBO = _tenantRepository.Get(tenantToUpdate.Id) ?? throw new AccessGuardException("tenant-0404");
            tenantDBO.TenantName = tenantToUpdate.TenantName;
            _tenantRepository.Update(tenantDBO);
            _tenantRepository.SaveChanges();            
            return tenantDBO.ToDto();
        }
    }
}
