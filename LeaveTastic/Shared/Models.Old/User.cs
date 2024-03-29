﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models.Old
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public int LeaveDays { get; set; }


        public virtual UserRole Role { get; set; }
        public virtual IEnumerable<UserLeave> Leaves { get; set; }
    }
}
