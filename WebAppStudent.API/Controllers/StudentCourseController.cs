using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAppStudent.API.DTOs.Request;
using WebAppStudent.API.Services.Interfaces;
using WebAppStudent.Data.Models;
using WebAppStundent.Models;

namespace WebAppStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;
        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }
        [HttpPost("EnrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest enrollStudentRequest)
        {
            try 
            {
                if (enrollStudentRequest.StudentId == 0 || enrollStudentRequest.CourseId == 0) 
                {
                    return BadRequest();
                }
                
                var result = _studentCourseService.EnrollStudent(enrollStudentRequest.StudentId, enrollStudentRequest.CourseId);
                
                if (result == false) 
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok();
            }
            catch  
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }
        [HttpDelete("UnenrollStudent")]
        public IActionResult UnenrollStudent(UnenrollStudentRequest unenrollStudentRequest)
        {
            try
            {
                if (unenrollStudentRequest.StudentId == 0 || unenrollStudentRequest.CourseId == 0)
                {
                    return BadRequest();
                }

                var result = _studentCourseService.UnenrollStudent(unenrollStudentRequest.StudentId, unenrollStudentRequest.CourseId);

                if (result == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
