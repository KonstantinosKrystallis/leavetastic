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
            var t = dbContext.Leaves.Where(x => x.EmployeeId == id).ToList();
            return t;
        }

        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] Leave leave)
        {
            await dbContext.Leaves.AddAsync(new(leave));
            return new();
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody] Leave leave)
        {
            dbContext.Leaves.Update(leave);
            await dbContext.SaveChangesAsync();
            return new();
        }

        [HttpDelete]
        public async Task<BaseResponse> Delete(int id)
        {
            Leave? leave = dbContext.Leaves.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Leaves.Remove(leave);
            return new();
        }
    }
}
