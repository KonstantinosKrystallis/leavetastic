using System;
using System.Collections.Generic;

namespace LeaveTastic.Shared.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
