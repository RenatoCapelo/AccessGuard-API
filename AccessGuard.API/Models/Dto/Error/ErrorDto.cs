namespace AccessGuard_API.Models.Dto.Error
{
    public class ErrorDto
    {
        public string Id { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public int HttpStatusCode { get; set; } = 400;

        public override bool Equals(object? obj)
        {
            if(obj is not  ErrorDto) return false;

            ErrorDto errorDto = (ErrorDto)obj;

            return errorDto.Id == Id && errorDto.ErrorMessage == ErrorMessage && errorDto.HttpStatusCode == HttpStatusCode;
        }
    }
}
