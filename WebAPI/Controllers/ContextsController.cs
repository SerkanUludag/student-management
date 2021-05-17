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
    public class ContextsController : ControllerBase
    {
        IContextService _contextService;
        public ContextsController(IContextService contextService)
        {
            _contextService = contextService;
        }

        [HttpPost("add")]
        public IActionResult Add(Context context)
        {
            var result = _contextService.Add(context);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _contextService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycourse")]
        public IActionResult GetByCourseId(int id)
        {
            var result = _contextService.GetByCourseId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
