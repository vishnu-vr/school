using System;

namespace school
{
    public class Staff
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private int EmpCode { get; set; }

        public Staff(String name, String email, int empCode)
        {
            this.Name = name;
            this.Email = email;
            this.EmpCode = empCode;
        }
    }
}
