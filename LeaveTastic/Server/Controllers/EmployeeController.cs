using LeaveTastic.Server.Data;
using LeaveTastic.Server.Models;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Employee> Get()
        {

            var employees = dbContext.Employees.ToList();
            return employees;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Employee? Get(int id)
        {
            Employee? employee = dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
