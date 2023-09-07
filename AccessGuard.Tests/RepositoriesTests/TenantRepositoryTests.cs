using AccessGuard_API.Repositories.Tenants;

namespace AccessGuard.Tests.RepositoriesTests
{
    public class TenantRepositoryTests : IDisposable
    {
        private readonly AccessGuardDBContext _dbContext;
        private readonly TenantRepository _tenantRepository;

        private readonly DbConnection _connection;

        public TenantRepositoryTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            var options = new DbContextOptionsBuilder<AccessGuardDBContext>()
                .UseSqlite(_connection)
                .Options;

            _dbContext = new AccessGuardDBContext(options);
            _dbContext.Database.EnsureCreated();

            var tenant0 = new Tenant()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),

                TenantName = "TestTenant1",
            };

            _dbContext.AddRange(
                tenant0,
                new Tenant()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),

                    TenantName = "TestTenant2",
                },
                new TenantUser()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Email = "test@test.com",
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,
                    DateLastLogin = DateTimeOffset.Now,
                    Password = "123",
                    Name = "Alberto",
                    Tenant = tenant0
                });
            _dbContext.SaveChanges();
            _tenantRepository = new TenantRepository(_dbContext);
        }

        [Fact]
        public void GetTenantByID()
        {
            var tenant = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000001"))!;
            Assert.Equal("TestTenant1", tenant.TenantName);
        }

        [Fact]
        public void GetMissingTenantByID()
        {
            var tenant = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000000"))!;
            Assert.Null(tenant);
        }

        [Fact]
        public async Task GetAllTenants()
        {
            var tenants = await _tenantRepository.GetAll();
            Assert.Equal(2, tenants.Count);
        }

        [Fact]
        public void AddTenant()
        {
            // Arrange
            var tenant = new Tenant()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),

                TenantName = "TestTenant3",
            };

            //Act
            _tenantRepository.Add(tenant);
            _tenantRepository.SaveChanges();

            //Assert
            var tenantFromDb = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000003"))!;
            Assert.Equal("TestTenant3", tenantFromDb.TenantName);
        }

        [Fact]
        public void UpdateTenant()
        {
            // Arrange
            var tenant = new Tenant()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),

                TenantName = "TestTenant3",
            };

            //Act
            _tenantRepository.Add(tenant);
            _tenantRepository.SaveChanges();

            var tenantFromDb = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000003"))!;
            tenantFromDb.TenantName = "TestTenant3Updated";
            _tenantRepository.Update(tenantFromDb);
            _tenantRepository.SaveChanges();

            //Assert
            var tenantFromDbUpdated = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000003"))!;
            Assert.Equal("TestTenant3Updated", tenantFromDbUpdated.TenantName);
        }

        [Fact]
        public void DeleteTenant()
        {
            // Arrange
            var tenant = new Tenant()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),

                TenantName = "TestTenant3",
            };

            //Act
            _tenantRepository.Add(tenant);
            _tenantRepository.SaveChanges();

            var tenantFromDb = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000003"))!;
            _tenantRepository.Delete(tenantFromDb);
            _tenantRepository.SaveChanges();

            //Assert
            var tenantFromDbUpdated = _tenantRepository.Get(Guid.Parse("00000000-0000-0000-0000-000000000003"));
            Assert.Null(tenantFromDbUpdated);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}