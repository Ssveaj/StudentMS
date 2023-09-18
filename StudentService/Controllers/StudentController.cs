using Microsoft.AspNetCore.Mvc;
using StudentService.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
    public class StudentController : Controller
    {

        [HttpGet]
        public Task<IActionResult> GetStudents(
           [FromServices] StudentCommand s) => s.ExecuteAsync();

    }
}