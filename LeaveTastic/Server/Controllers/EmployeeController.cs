using LeaveTastic.Server.Data;
using LeaveTastic.Server.Models;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveTastic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly LeaveTasticDatabaseContext dbContext;
        public EmployeeController(LeaveTasticDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // GET: api/<UserController>
        [HttpGet]
        public DataResponse<IEnumerable<Employee>> Get()
        {
            return new() { Data = dbContext.Employees.ToList() };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public DataResponse<Employee> Get(int id)
        {
            return new() { Data = dbContext.Employees.Where(x => x.Id == id).FirstOrDefault() };
        }

        // POST api/<UserController>
        [HttpPost]
        public BaseResponse Post([FromBody] string value)
        {
            return new();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public BaseResponse Put(int id, [FromBody] string value)
        {
            return new();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public BaseResponse Delete(int id)
        {
            return new();
        }
    }
}
