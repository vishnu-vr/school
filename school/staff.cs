using System;

namespace school
{
    public enum Type
    {
        teacher,
        support,
        administrator
    };

    public class Staff
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int EmpCode { get; set; }
        public Type StaffType { get; set; }

        public Staff(String name, String email, int empCode, Type staffType)
        {
            this.Name = name;
            this.Email = email;
            this.EmpCode = empCode;
            this.StaffType = staffType;
        }
    }
}
