using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudAPIController : ControllerBase
    {
        public List<string> students = new List<string>()
    {"Amna",
            "Affan",
            "Ali",
            "ASad"

    };
        [HttpGet]
        public List<string> GetStudents()
        {
            return students;
        }
        [HttpGet("{id}")]
        public List<string> GetStudentsByIndex(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new List<string> { "Invalid student ID." };
            }

            return new List<string> { students[id] };
        }

            [HttpPost]
            public IActionResult AddStudent([FromBody] string student)
            {
                if (string.IsNullOrEmpty(student))
                {
                    return BadRequest("Student name cannot be empty.");
                }

                students.Add(student);
                return Ok("Student added successfully.");
            }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] string newStudentName)
        {
            if (id < 0 || id >= students.Count)
            {
                return NotFound("Student not found.");
            }

            if (string.IsNullOrEmpty(newStudentName))
            {
                return BadRequest("Student name cannot be empty.");
            }

            students[id] = newStudentName;
            return Ok("Student updated successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return NotFound("Student not found.");
            }

            string deletedStudent = students[id];
            students.RemoveAt(id);

            return Ok($"Student '{deletedStudent}' deleted successfully.");
        }



    }


}









