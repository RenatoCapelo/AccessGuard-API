namespace AcessGuard_API.Models.Dto.Tenant
{
    public class TenantToCreateDTO
    {
        public string TenantName { get; set; } = null!;

        public TenantDto ConvertToTenantDTO(Guid id)
        {
            return new TenantDto(id, TenantName);
        }
    }
}
