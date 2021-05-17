using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        IAttendanceService _attendanceService;
        ICourseService _courseService;
        public AttendancesController(IAttendanceService attendanceService, ICourseService courseService)
        {
            _attendanceService = attendanceService;
            _courseService = courseService;
        }

        [HttpPost("add")]
        public IActionResult Add(Attendance entity)
        {
            var course = _courseService.GetById(entity.CourseId).Data;
            var result = _attendanceService.Add(entity, course.CourseFee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycourse")]
        public IActionResult GetByCourseId(int id)
        {
            var result = _attendanceService.GetByCourseId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
