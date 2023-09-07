using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Dto.Other;

namespace AccessGuard_API.Services.Errors
{
    public interface IErrorsService
    {
        ErrorDto Get(string Id);
        ErrorDto Create(ErrorDto error);
        Paginator<ErrorDto> GetAll(int page=1, int pageSize=25);
        ErrorDto Update(ErrorDto error);
        void Delete (string Id);
    }
}
