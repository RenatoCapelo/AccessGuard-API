using AccessGuard_API.Models.Dto.Tenant;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Repositories.Tenants;
using AccessGuard_API.Services.Tenants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessGuard_API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 25)
        {
            return Ok(_tenantService.GetAll(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(_tenantService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(TenantToCreateDTO tenant)
        {
            _tenantService.Create(tenant);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(TenantDto tenant)
        {
            return Ok(_tenantService.Update(tenant));
        }
    }
}
