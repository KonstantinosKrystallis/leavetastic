using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models.Old
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime DateOfLeave { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
