using AccessGuard_API.Repositories.Errors;

namespace AccessGuard.Tests.RepositoriesTests
{
    public class ErrorRepositoryTests : IDisposable
    {
        private readonly AccessGuardDBContext _dbContext;
        private readonly ErrorRepository _errorRepository;
        private readonly DbConnection _connection;
        public ErrorRepositoryTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<AccessGuardDBContext>()
                .UseSqlite(_connection)
                .Options;

            _dbContext = new AccessGuardDBContext(options);
            _dbContext.Database.EnsureCreated();

            _errorRepository = new ErrorRepository(_dbContext);
        }

        [Fact]
        public void GetExistingError()
        {
            // Arrange
            Error errorToCreate = new Error { Id = "error-0001", ErrorMessage = "Error 1" };
            _errorRepository.CreateError(errorToCreate);
            _errorRepository.SaveChanges();

            //Act
            var errorDb = _errorRepository.GetError("error-0001");

            // Assert
            Assert.NotNull(errorDb);
            Assert.Equal("Error 1", errorDb!.ErrorMessage);
            Assert.Equal(400, errorDb!.HttpStatusCode);
        }

        [Fact]
        public void GetMissingError()
        {
            // Arrange

            // Act
            var error = _errorRepository.GetError("non-existing");

            // Assert
            Assert.Null(error);
        }

        [Fact]
        public async Task GetErrors()
        {
            // Arrange
            Error errorToCreate = new Error { Id = "error-0001", ErrorMessage = "Error 1" };
            _errorRepository.CreateError(errorToCreate);
            _errorRepository.SaveChanges();

            // Act
            var errors = await _errorRepository.GetErrors();

            // Assert
            Assert.NotNull(errors);
            Assert.Single(errors);
        }

        [Fact]
        public void CreateError()
        {
            Error newError = new Error() { Id="new-error", ErrorMessage="new-error"};
            _errorRepository.CreateError(newError);
            _errorRepository.SaveChanges();

            Error? errorFromDb = _errorRepository.GetError("new-error");
            Assert.NotNull(errorFromDb);
            Assert.Equal("new-error", errorFromDb!.ErrorMessage);
        }

        [Fact]
        public void UpdateError()
        {
            // Arrange
            Error errorToUpdate = new Error()
            {
                Id = "error-to-update",
                ErrorMessage = "error-to-update-message"
            };
            _errorRepository.CreateError(errorToUpdate);
            _errorRepository.SaveChanges();

            // Act

            errorToUpdate.ErrorMessage = "Error";
            _errorRepository.UpdateError(errorToUpdate);
            _errorRepository.SaveChanges();


            // Assert

            var errorFromDb = _errorRepository.GetError("error-to-update");
            Assert.NotNull(errorFromDb);
            Assert.Equal("Error",errorFromDb!.ErrorMessage);
        }

        [Fact]
        public async Task DeleteErrorAsync()
        {
            // Arrange
            Error errorToDelete = new Error() { Id="delete-error", ErrorMessage = "Error" };
            _errorRepository.CreateError(errorToDelete);
            _errorRepository.SaveChanges();

            // Act
            _errorRepository.DeleteError(errorToDelete);
            _errorRepository.SaveChanges();

            // Assert

            var errorsDb = await _errorRepository.GetErrors();
            Assert.NotNull(errorsDb);
            Assert.Empty(errorsDb);
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
