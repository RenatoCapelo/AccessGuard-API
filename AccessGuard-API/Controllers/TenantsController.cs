﻿using AccessGuard_API.Models;
using AcessGuard_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcessGuard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly TenantRepository _tenantRepository;

        public TenantsController(TenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tenant>>> Get()
        {
            return Ok(await _tenantRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tenant tenant)
        {
            _tenantRepository.Add(tenant);
            _tenantRepository.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Tenant tenant)
        {
            if(_tenantRepository.Get(tenant.Id) is null)
            {
                return BadRequest();
            }
            _tenantRepository.Update(tenant);
            _tenantRepository.SaveChanges();
            return Ok();
        }
    }
}