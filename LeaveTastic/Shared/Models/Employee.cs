namespace LeaveTastic.Shared.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ManagerId { get; set; }

    public int? RoleId { get; set; }

    public int LeaveDays { get; set; }

    public virtual ICollection<Employee> InverseManager { get; } = new List<Employee>();

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();

    public virtual Employee? Manager { get; set; }

    public virtual Role? Role { get; set; }

    public Employee() { }

    public Employee(Employee employee)
    {
        Name = employee.Name;
        ManagerId = employee.ManagerId;
        RoleId = employee.RoleId;
        LeaveDays = employee.LeaveDays;
    }
}
