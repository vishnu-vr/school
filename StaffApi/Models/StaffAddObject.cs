using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school;

namespace StaffApi.Models
{
    public class StaffAddObject : school.Staff
    {
        public string Extra { get; set; }
    }
}
