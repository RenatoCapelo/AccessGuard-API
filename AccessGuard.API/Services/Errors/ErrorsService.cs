using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Dto.Other;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Models.Extensions;
using AccessGuard_API.Repositories.Errors;

namespace AccessGuard_API.Services.Errors
{
    public class ErrorsService : IErrorsService
    {
        private readonly IErrorRepository _errorsRepository;
        public ErrorsService(IErrorRepository errorsRepository)
        {
            _errorsRepository = errorsRepository;
        }

        public ErrorDto Create(ErrorDto error)
        {
            Error errorEntity = error.ToEntity();
            if(_errorsRepository.GetError(errorEntity.Id) != null)
            {
                throw new AccessGuardException("errors-0001");
            }
            _errorsRepository.CreateError(errorEntity);
            return errorEntity.ToDto();
        }

        public void Delete(string Id)
        {
            ErrorDto error = Get(Id);
            _errorsRepository.DeleteError(error.ToEntity());
        }

        public ErrorDto Get(string Id)
        {
            return _errorsRepository.GetError(Id)?.ToDto() ?? throw new AccessGuardException("errors-0404");
        }

        public Paginator<ErrorDto> GetAll(int page = 1, int pageSize = 25)
        {
            var results = _errorsRepository.GetErrors(page, pageSize).Result;
            int totalCount = _errorsRepository.Count();

            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);


            Paginator<ErrorDto> paginator = new()
            { 
                PageCount = pageCount,
                PageSize = pageSize,
                PageIndex = page,
                TotalCount = totalCount,
                Results = results.Select(x=>x.ToDto())
            };
            
            return paginator;
        }

        public ErrorDto Update(ErrorDto error)
        {
            var errorEntity = Get(error.Id).ToEntity();
            errorEntity.ErrorMessage = error.ErrorMessage;
            errorEntity.HttpStatusCode = error.HttpStatusCode;
            _errorsRepository.UpdateError(errorEntity);

            return errorEntity.ToDto();
        }
    }
}
