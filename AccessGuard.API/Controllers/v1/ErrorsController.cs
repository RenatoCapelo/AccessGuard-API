using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Repositories.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessGuard_API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly IErrorRepository _errorRepository;
        public ErrorsController(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Error>>> GetAll()
        {
            return Ok(await _errorRepository.GetErrors());
        }

        [HttpGet("{Id}")]
        public ActionResult<Error> GetById(string Id)
        {
            Error? errorDb = _errorRepository.GetError(Id);
            if (errorDb == null)
            {
                throw new AccessGuardException("errors-404");
            }
            return Ok(errorDb!);
        }

        [HttpPost]
        public IActionResult Post(Error error)
        {
            _errorRepository.CreateError(error);
            _errorRepository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {error.Id}, error);
        }

        [HttpDelete]
        public IActionResult DeleteById(string Id)
        {
            Error? errorDb = _errorRepository.GetError(Id);
            if(errorDb == null)
            {
                throw new AccessGuardException("errors-404");
            }
            _errorRepository.DeleteError(errorDb);
            return NoContent();
        }
    }
}
