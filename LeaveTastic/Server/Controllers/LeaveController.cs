using LeaveTastic.Server.Data;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LeaveTastic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public LeaveController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("all")]
        public IEnumerable<Leave> GetAll()
        {
            return dbContext.Leaves.ToList();
        }

        [HttpGet("{id}")]
        public DataResponse<Leave> GetLeave(int id)
        {
            return new() { Data = dbContext.Leaves.Where(x => x.Id == id).FirstOrDefault() };
        }

        [HttpGet("emp/{id}")]
        public DataResponse<IEnumerable<Leave>> GetEmployeeLeaves(int id)
        {
            try
            {
                return new() { Data = dbContext.Leaves.Where(x => x.EmployeeId == id).ToList() };
            }
            catch (Exception e)
            {
                return new() { Exception = e, HasError = true, Message = "Error while getting employ's leaves.", StatusCode = HttpStatusCode.InternalServerError };
            }
        }

        [HttpGet("mng/{id}")]
        public DataResponse<IEnumerable<Leave>> GetSubordinatesLeaves(int id)
        {
            try
            {
                var leavesQuery = from leave in dbContext.Leaves where leave.Employee.ManagerId == id select leave;
                var leaves = leavesQuery.Include(x => x.Employee).ToList();

                //var employeesQuery = from emp in dbContext.Employees where emp.ManagerId == id select emp.Id;
                //var leaves = dbContext.Leaves.Where(x => employeesQuery.Contains(x.EmployeeId)).ToList();

                return new() { Data = leaves };
            }
            catch (Exception e)
            {
                return new() { Exception = e, HasError = true, Message = "Error while getting surbordinates' leaves.", StatusCode = HttpStatusCode.InternalServerError };
            }
        }

        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] Leave leave)
        {
            //await dbContext.Leaves.AddAsync(new(leave));
            await dbContext.SaveChangesAsync();
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
            await dbContext.SaveChangesAsync();
            return new();
        }
    }
}
