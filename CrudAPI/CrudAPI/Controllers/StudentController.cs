using CrudAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AmndbContext context;

        public StudentController(AmndbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<CrudAPI.Models.File>> GetMyFile()
        {
            if (context.Files == null)
            {
                return NotFound("No files found in the database.");
            }

            var data = await context.Files.ToListAsync();
            return Ok(data);
        }
    }
}
