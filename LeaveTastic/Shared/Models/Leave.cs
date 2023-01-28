namespace LeaveTastic.Shared.Models;

public partial class Leave
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime FromDate { get; set; } = DateTime.Now;

    public DateTime ToDate { get; set; } = DateTime.Now;

    public bool? IsApproved { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public Leave() { }

    public Leave(Leave leave)
    {
        EmployeeId = leave.EmployeeId;
        FromDate = leave.FromDate;
        ToDate = leave.ToDate;
    }
}
