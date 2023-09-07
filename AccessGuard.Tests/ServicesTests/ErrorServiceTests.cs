using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Extensions;
using AccessGuard_API.Repositories.Errors;
using AccessGuard_API.Services.Errors;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessGuard.Tests.ServicesTests
{
    public class ErrorServiceTests
    {
        private readonly IErrorRepository mockRepository;
        private readonly ErrorsService errorsService;

        public ErrorServiceTests() { 
            mockRepository = Substitute.For<IErrorRepository>();
            errorsService = new ErrorsService(mockRepository);
        }

        [Fact]
        public void CreateError_RepeatedID_Error()
        {
            ErrorDto errorDto = new ErrorDto();
            errorDto.Id = "usedID";

            mockRepository.GetError("usedID").Returns(new Error());

            AccessGuardException exceptionThrown = Assert.Throws<AccessGuardException>(()=>errorsService.Create(errorDto));

            Assert.Equal("errors-0001", exceptionThrown.Message);
        }

        [Fact]
        public void CreateError_Valid()
        {
            ErrorDto errorDto = new ErrorDto() { Id = "newID", ErrorMessage = "ErrorMessage", HttpStatusCode = 400 };

            ErrorDto errorDtoFromService = errorsService.Create(errorDto);
            mockRepository.Received().GetError(errorDto.Id);
            mockRepository.Received().CreateError(Arg.Is<Error>(x => x.Id == errorDto.Id && x.ErrorMessage == errorDto.ErrorMessage && x.HttpStatusCode==errorDto.HttpStatusCode));

            Assert.Equal(errorDto.Id, errorDtoFromService.Id);
            Assert.Equal(errorDto.ErrorMessage, errorDtoFromService.ErrorMessage);
            Assert.Equal(errorDto.HttpStatusCode, errorDtoFromService.HttpStatusCode);
        }

        [Fact]
        public void GetError_Valid()
        {
            ErrorDto errorToTest = new() { HttpStatusCode = 200, ErrorMessage = "TestMessage", Id = "TestID" };

            mockRepository.GetError(errorToTest.Id).Returns(errorToTest.ToEntity());

            ErrorDto errorReceivedFromService = errorsService.Get(errorToTest.Id);
            Assert.Equal(errorToTest.HttpStatusCode, errorReceivedFromService.HttpStatusCode);
            Assert.Equal(errorToTest.Id, errorReceivedFromService.Id);
            Assert.Equal(errorToTest.ErrorMessage, errorReceivedFromService.ErrorMessage);
            mockRepository.Received().GetError(errorToTest.Id);
        }

        [Fact]
        public void GetError_Invalid()
        {
            mockRepository.GetError(Arg.Any<string>()).ReturnsNullForAnyArgs();

            AccessGuardException exception = Assert.Throws<AccessGuardException>(() => errorsService.Get("test"));
            Assert.Equal("errors-0404", exception.Message);
        }

        [Fact]
        public void GetErrors_FromPaginator()
        {
            var page = 2;
            var pageSize = 10;
            var totalCount = 6;

            var expectedErrors = new List<Error>()
            {
                new Error()
                {
                    Id= "test1",
                    ErrorMessage = "test1Message",
                    HttpStatusCode = 200,
                },
                new Error()
                {
                    Id= "test2",
                    ErrorMessage = "test2Message",
                    HttpStatusCode = 201,
                },
                new Error()
                {
                    Id= "test3",
                    ErrorMessage = "test3Message",
                    HttpStatusCode = 202,
                },
                new Error()
                {
                    Id= "test4",
                    ErrorMessage = "test4Message",
                    HttpStatusCode = 203,
                },
                new Error()
                {
                    Id= "test5",
                    ErrorMessage = "test5Message",
                    HttpStatusCode = 204,
                },
                new Error()
                {
                    Id= "test6",
                    ErrorMessage = "test6Message",
                    HttpStatusCode = 205,
                },
                new Error()
                {
                    Id= "test7",
                    ErrorMessage = "test7Message",
                    HttpStatusCode = 206,
                },
                new Error()
                {
                    Id= "test8",
                    ErrorMessage = "test8Message",
                    HttpStatusCode = 207,
                },
                new Error()
                {
                    Id= "test9",
                    ErrorMessage = "test9Message",
                    HttpStatusCode = 208,
                },
                new Error()
                {
                    Id= "test0",
                    ErrorMessage = "test0Message",
                    HttpStatusCode = 209,
                },
            };

            mockRepository.GetErrors(page, pageSize).Returns(Task.FromResult<IEnumerable<Error>>(expectedErrors));
            mockRepository.Count().Returns(totalCount);

            var result = errorsService.GetAll(page, pageSize);
            Assert.Equal(page, result.PageIndex);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(totalCount, result.TotalCount);
            Assert.Equal((int)Math.Ceiling((double)totalCount / pageSize), result.PageCount);
            Assert.True(expectedErrors.Select(e => e.ToDto()).SequenceEqual(result.Results));
        }

        [Fact]
        public void UpdateError_InvalidID()
        {
            mockRepository.GetError(Arg.Any<string>()).ReturnsNullForAnyArgs();

            AccessGuardException exceptionThrown = Assert.Throws<AccessGuardException>(()=> errorsService.Get("id"));
            Assert.Equal("errors-0404", exceptionThrown.Message);
            mockRepository.Received().GetError("id");
            mockRepository.DidNotReceiveWithAnyArgs().UpdateError(Arg.Any<Error>());
        }

        [Fact]
        public void UpdateError_WithValidID()
        {
            ErrorDto errorDto = new ErrorDto() { ErrorMessage = "Test", HttpStatusCode = 400,Id = "testID"};

            mockRepository.GetError(errorDto.Id).Returns(errorDto.ToEntity());

            errorDto.ErrorMessage = "TestModified";
            errorDto.HttpStatusCode = 200;

            var errorUpdated = errorsService.Update(errorDto);
            mockRepository.Received().GetError(errorDto.Id);
            mockRepository.Received().UpdateError(Arg.Is<Error>(x=>x.ToDto().Equals(errorDto)));

            Assert.Equal(errorDto.ErrorMessage, errorUpdated.ErrorMessage);
            Assert.Equal(errorDto.HttpStatusCode, errorUpdated.HttpStatusCode);
        }

        [Fact]
        public void DeleteError_WithInvalidID()
        {
            mockRepository.GetError(Arg.Any<string>()).ReturnsNullForAnyArgs();

            AccessGuardException exceptionThrown = Assert.Throws<AccessGuardException>(() => errorsService.Delete("Id"));
            Assert.Equal("errors-0404", exceptionThrown.Message);
        }

        [Fact]
        public void DeleteError_WithValidID()
        {
            ErrorDto errorDto = new ErrorDto()
            {
                Id = "testId",
                ErrorMessage = "testMessage",
                HttpStatusCode = 200
            };

            mockRepository.GetError(errorDto.Id).Returns(errorDto.ToEntity());

            errorsService.Delete(errorDto.Id);

            mockRepository.Received().GetError(errorDto.Id);
            mockRepository.Received().DeleteError(Arg.Is<Error>(x => x.ToDto().Equals(errorDto)));
        }
    }
}
