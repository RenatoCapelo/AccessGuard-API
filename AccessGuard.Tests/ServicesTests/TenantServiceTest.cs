
using AccessGuard_API.Repositories.Tenants;

namespace AccessGuard.Tests.ServicesTests
{
    public class TenantServiceTest
    {
        [Fact]
        public void CreateTenant()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
        }
    }
}
