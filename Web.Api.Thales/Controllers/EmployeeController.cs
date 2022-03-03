using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Thales.Interfaces;

namespace Web.Api.Thales.Controllers
{
    [ApiController]
    [Route("api/v1/employees")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployees _Employees;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployees Employees)
        {
            _logger = logger;
            _Employees = Employees;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _Employees.GerEmployees();

                if (result == null)
                    return StatusCode(429, "Too many request");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _Employees.GerEmployee(id);

                if (result == null)
                    return StatusCode(429, "Too many request");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Not Found"))
                    return NotFound("Employee not found!!");

                return BadRequest("Internal Error: " + ex.Message);
            }
        }

    }
}
