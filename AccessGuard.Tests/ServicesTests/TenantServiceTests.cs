
using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Dto.Tenant;
using AccessGuard_API.Models.Extensions;
using AccessGuard_API.Repositories.Tenants;
using AccessGuard_API.Services.Tenants;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace AccessGuard.Tests.ServicesTests
{
    public class TenantServiceTests
    {
        [Fact]
        public void CreateTenant()
        {
            ITenantRepository mockRepository = Substitute.For<ITenantRepository>();

            var service = new TenantService(mockRepository);

            var tenantCreate = new TenantToCreateDTO() { TenantName = "Test" };

            TenantDto tenantService = service.Create(tenantCreate);

            //Assert
            mockRepository.ReceivedWithAnyArgs().Add(default!);
            Assert.Equal(tenantService.TenantName, tenantCreate.TenantName);
            Assert.NotEqual(tenantService.Id, Guid.Empty);
        }

        [Fact]
        public void GetNonExistentTenant()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
            var service = new TenantService(mockRepository);

            mockRepository.Get(Arg.Any<Guid>()).ReturnsNullForAnyArgs();

            var ex = Assert.Throws<AccessGuardException>(()=>service.Get(Guid.NewGuid()));
            Assert.Equal("tenant-0404", ex.Message);
        }

        [Fact]
        public void GetTenant()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
            var service = new TenantService(mockRepository);

            Guid tenantID = Guid.NewGuid();

            mockRepository.Get(tenantID)
                .Returns(new Tenant() { 
                    Id = tenantID,
                    TenantName = "Test"
                });

            var tenantService = service.Get(tenantID);
            Assert.NotNull(tenantService);
            Assert.Equal(tenantID, tenantService.Id);
            Assert.Equal("Test", tenantService.TenantName);
        }

        [Fact]
        public void DeleteTenant()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
            var service = new TenantService(mockRepository);

            Tenant tenantToReturn = new() { Id = Guid.NewGuid(), TenantName = "Test" };

            mockRepository.Get(tenantToReturn.Id).Returns(tenantToReturn);

            service.Delete(tenantToReturn.Id);

            mockRepository.Received().Get(tenantToReturn.Id);
            mockRepository.Received().Delete(tenantToReturn);
        }

        [Fact]
        public void UpdateTenantWithValidID()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
            var service = new TenantService(mockRepository);

            Tenant tenantOG = new Tenant() { Id = Guid.NewGuid(), TenantName= "Test" };

            TenantDto tenantDto = tenantOG.ToDto();
            tenantDto.TenantName = "Test Updated";

            mockRepository.Get(tenantOG.Id).Returns(tenantOG);

            var tenantUpdated = service.Update(tenantDto);

            mockRepository.Received().Get(tenantOG.Id);
            mockRepository.Received().Update(tenantOG);
            mockRepository.Received().SaveChanges();

            Assert.Equal(tenantOG.Id, tenantUpdated.Id);
            Assert.Equal(tenantDto.TenantName, tenantUpdated.TenantName);
        }

        [Fact]
        public void UpdateTenantWithInvalidID()
        {
            var mockRepository = Substitute.For<ITenantRepository>();
            var service = new TenantService(mockRepository);

            Tenant tenantOG = new Tenant() { Id = Guid.NewGuid(), TenantName = "Test" };

            TenantDto tenantDto = tenantOG.ToDto();
            tenantDto.TenantName = "Test Updated";

            mockRepository.Get(tenantOG.Id).ReturnsNull();

            var exceptionThrown = Assert.Throws<AccessGuardException>(() => service.Update(tenantDto));
            Assert.Equal("tenant-0404", exceptionThrown.Message);
        }
    }
}
