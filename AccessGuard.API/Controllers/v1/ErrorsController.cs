using AccessGuard_API.Exceptions;
using AccessGuard_API.Models.Dto.Error;
using AccessGuard_API.Models.Dto.Other;
using AccessGuard_API.Models.Entity;
using AccessGuard_API.Repositories.Errors;
using AccessGuard_API.Services.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessGuard_API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly IErrorsService _errorsService;
        public ErrorsController(IErrorsService errorsService)
        {
            _errorsService = errorsService;
        }

        [HttpGet]
        public ActionResult<Paginator<ErrorDto>> GetAll([FromQuery] int page=1, [FromQuery]int pageSize=25)
        {
            return Ok(_errorsService.GetAll(page,pageSize));
        }

        [HttpGet("{Id}")]
        public ActionResult<Error> GetById(string Id)
        {
            return Ok(_errorsService.Get("Id"));
        }

        [HttpPost]
        public IActionResult Post(ErrorDto error)
        {
            _errorsService.Create(error);
            return CreatedAtAction(nameof(GetById), new {error.Id}, error);
        }

        [HttpPut]
        public IActionResult Put(ErrorDto error)
        {
            ErrorDto updatedError = _errorsService.Update(error);
            return Ok(updatedError);
        }
        
        [HttpDelete]
        public IActionResult DeleteById(string Id)
        {
            _errorsService.Delete(Id);
            return NoContent();
        }
    }
}
