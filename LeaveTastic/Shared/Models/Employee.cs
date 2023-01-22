using System;
using System.Collections.Generic;

namespace LeaveTastic.Shared.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ManagerId { get; set; }

    public int? RoleId { get; set; }

    public int LeaveDays { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();

    public virtual Role? Role { get; set; }
}
