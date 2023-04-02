using Microsoft.AspNetCore.Mvc;
using WebAppStudent.API.DTOs.Request;
using WebAppStudent.API.Services;
using WebAppStudent.API.Services.Interfaces;
using WebAppStundent.Models;

namespace WebAppStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("{id}")]
        public IActionResult GetCourse([FromRoute] int id)
        {
            try
            {
                var course = _courseService.GetCourse(id);

                if (course is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                    
                return Ok(course);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            try
            {
                var coursets = _courseService.GetAllCourses();

                if (coursets is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                    
                return Ok(coursets);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] AddCourseRequest course)
        {
            try
            {
                if (string.IsNullOrEmpty(course.CourseName))
                {
                    return BadRequest();
                }

                _courseService.AddCourse(course.CourseName);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse([FromRoute] int id, UpdateCourseRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.CourseName) || id == 0)
                {
                    return BadRequest();
                }

                var result = _courseService.UpdateCourse(id, request.CourseName);

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
        public IActionResult DeleteCourse([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var result = _courseService.DeleteCourse(id);

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
