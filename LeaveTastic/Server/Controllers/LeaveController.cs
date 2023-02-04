using LeaveTastic.Server.Data;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                return new() { Data = dbContext.Leaves.Where(x => x.EmployeeId == id && x.ToDate > DateTime.Today).ToList() };
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
                var leavesQuery = from leave in dbContext.Leaves where leave.Employee.ManagerId == id && leave.ToDate > DateTime.Today select leave;
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

        [HttpGet("hr")]
        public DataResponse<IEnumerable<Leave>> GetAllApprovedLeaves()
        {
            try
            {
                var leaves = dbContext.Leaves.Where(x => x.IsApproved == true).ToList();

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
            await dbContext.Leaves.AddAsync(new(leave));
            Employee? employee = await dbContext.Employees.Where(x => x.Id == leave.EmployeeId).FirstOrDefaultAsync();
            if (employee != null)
            {
                employee.LeaveDays -= (leave.ToDate - leave.FromDate).Days + 1;
                dbContext.Employees.Update(employee);
            }
            await dbContext.SaveChangesAsync();
            return new();
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody] Leave leave)
        {
            dbContext.Leaves.Update(leave);
            if (leave.IsDeleted == true)
            {
                Employee? employee = await dbContext.Employees.Where(x => x.Id == leave.EmployeeId).FirstOrDefaultAsync();
                if (employee != null)
                {
                    employee.LeaveDays += (leave.ToDate - leave.FromDate).Days + 1;
                    dbContext.Employees.Update(employee);
                }
            }
            await dbContext.SaveChangesAsync();
            return new();
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            Leave? leave = dbContext.Leaves.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Leaves.Remove(leave);
            Employee? employee = await dbContext.Employees.Where(x => x.Id == leave.EmployeeId).FirstOrDefaultAsync();
            if (employee != null)
            {
                employee.LeaveDays += (leave.ToDate - leave.FromDate).Days + 1;
                dbContext.Employees.Update(employee);
            }
            await dbContext.SaveChangesAsync();
            return new();
        }
    }
}
