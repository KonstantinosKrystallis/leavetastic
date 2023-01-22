using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models.Old
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<UserRole> Users { get; set; }
    }
}
