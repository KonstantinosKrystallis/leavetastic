using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models
{
    public class UserLeave
    {
        public int UserId { get; set; }
        public int LeaveId { get; set; }

        public virtual User User { get; set; }
        public virtual Leave Leave { get; set; }

    }
}
