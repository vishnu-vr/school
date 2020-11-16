using System;

namespace school
{
    public class Staff
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int EmpCode { get; set; }
        public StaffType Type { get; set; }

        public Staff() { }

        public Staff(String name, String email, int empCode, StaffType type)
        {
            this.Name = name;
            this.Email = email;
            this.EmpCode = empCode;
            this.Type = type;
        }
    }
}
