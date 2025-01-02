using ApiDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyController : ControllerBase
    {
        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Amna", Description = "good" },
                new Student { Id = 2, Name = "Tabish", Description = "good" },
                new Student { Id = 3, Name = "Smar", Description = "good" }
            };

            return Ok(students);
        }
    }
}
