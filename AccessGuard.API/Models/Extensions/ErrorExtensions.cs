using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Entity;

namespace AccessGuard_API.Models.Extensions
{
    public static class ErrorExtensions
    {
        public static Error ToEntity(this ErrorDto errorDto)
        {
            return new() { Id = errorDto.Id, ErrorMessage = errorDto.ErrorMessage, HttpStatusCode = errorDto.HttpStatusCode };
        }

        public static ErrorDto ToDto(this Error errorDto) { 
            return new () { Id = errorDto.Id, HttpStatusCode = errorDto.HttpStatusCode, ErrorMessage = errorDto.ErrorMessage };
        }
        
    }
}
