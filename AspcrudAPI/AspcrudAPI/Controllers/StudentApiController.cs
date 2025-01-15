using AspcrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AspcrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly ApidatabaseContext context;

        public StudentApiController(ApidatabaseContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetSubject()
        {
            var data=await context.Employees.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSubjectById(int id)
        {
            var subj = await context.Employees.FindAsync(id); // FindAsync expects the primary key

            if (subj == null)
            {
                return NotFound(); // Return 404 if the subject is not found
            }

            return subj; // Return the subject if found
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Createstd(Employee std)
        {
             await context.Employees.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Employee>> Updatestd(int Id, Employee std)
        {
            if (Id != std.Id)
            {
                return BadRequest();
            }


            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Employee>> Detetestd(int Id)
        {var st=await context.Employees.FindAsync(Id);
            if (st== null)
            {
                return NotFound();
            }


            context.Employees.Remove(st);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
