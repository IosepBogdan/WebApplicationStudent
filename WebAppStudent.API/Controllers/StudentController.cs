using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppStudent.API.DTOs.Request;
using WebAppStudent.API.Services;
using WebAppStudent.API.Services.Interfaces;
using WebAppStundent.Models;

namespace WebApplicationStundent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);

                if (student is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok(student);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();

                if (students is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] AddStudentRequest student)
        {
            try
            {
                if (string.IsNullOrEmpty(student.StudentName))
                {
                    return BadRequest();
                }

                _studentService.AddStudent(student.StudentName);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromRoute] int id, UpdateStudentRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.StudentName) || id == 0)
                {
                    return BadRequest();
                }

                var result = _studentService.UpdateStudent(id, request.StudentName);

                if (result is false) 
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var result = _studentService.DeleteStudent(id);

                if (result is false)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }
    }
}
