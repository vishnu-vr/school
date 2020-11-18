using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApi.Models
{
    public class StaffUpdateObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Extra { get; set; }
    }
}
