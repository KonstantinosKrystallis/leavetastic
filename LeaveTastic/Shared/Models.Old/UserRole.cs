
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveTastic.Shared.Models.Old
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; } = 1;

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
