using LeaveTastic.Server.Data;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTastic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly LeaveTasticDatabaseContext dbContext;
        public LeaveController(LeaveTasticDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("all")]
        public IEnumerable<Leave> GetAll()
        {
            return dbContext.Leaves.ToList();
        }

        [HttpGet("{id}")]
        public Leave? GetLeave(int id)
        {
            return dbContext.Leaves.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("emp/{id}")]
        public IEnumerable<Leave>? GetEmployeeLeaves(int id)
        {
            var t =  dbContext.Leaves.Where(x => x.EmployeeId == id).ToList();
            return t;
        }

        [HttpPost("{id}")]
        public void Post(int id, [FromBody] Leave leave)
        {
            dbContext.Leaves.Add(leave);
            dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Leave leave)
        {
            dbContext.Leaves.Update(leave);
            dbContext.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Leave? leave = dbContext.Leaves.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Leaves.Remove(leave);
            dbContext.SaveChanges();
        }
    }
}
