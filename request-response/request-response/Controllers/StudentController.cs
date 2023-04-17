using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
        }
    }
}