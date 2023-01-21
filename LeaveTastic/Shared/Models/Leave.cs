using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime DateOfLeave { get; set; }

        public virtual User User { get; set; }
    }
}
