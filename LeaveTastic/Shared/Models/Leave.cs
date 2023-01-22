using System;
using System.Collections.Generic;

namespace LeaveTastic.Shared.Models;

public partial class Leave
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfLeave { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
