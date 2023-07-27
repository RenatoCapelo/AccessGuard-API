﻿using AcessGuard_API.Models.Entity;

namespace AcessGuard_API.Repositories.Tenants
{
    public interface ITenantRepository
    {
        Tenant? Get(Guid id);
        Tenant? GetByIdForUser(Guid tenantId, Guid userId);
        Task<List<Tenant>> GetAll();
        void Add(Tenant entity);
        void Update(Tenant entity);
        void Delete(Tenant entity);
        void SaveChanges();
    }
}