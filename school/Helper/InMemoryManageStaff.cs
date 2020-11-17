using System;
using System.Collections.Generic;
using System.Linq;

namespace school
{
    public class InMemoryManageStaff : IManageStaff
    {
        public List<dynamic> Staffs = new List<dynamic>();

        public void AddStaff(StaffType type, string name, string email, int empCode, string extra)
        {
            //teacher
            if (type == StaffType.teacher) Staffs.Add(new Teacher(name, email, empCode, extra));

            //admin
            else if (type == StaffType.administrator) Staffs.Add(new Administrator(name, email, empCode, extra));

            //support
            else if (type == StaffType.support) Staffs.Add(new Support(name, email, empCode, extra));
        }

        public List<dynamic> GetAll()
        {
            return Staffs;
        }

        public dynamic GetOne(int empCode)
        {
            return Staffs.Single(staff => staff.EmpCode == empCode);
        }

        public bool Update(int empCode, string name, string email, string extra)
        {
            try
            {
                dynamic staff = Staffs.Single(staff => staff.EmpCode == empCode);

                staff.Name = name;
                staff.Email = email;
                if (staff.Type == StaffType.teacher) staff.Subject = extra;
                else if (staff.Type == StaffType.administrator) staff.Role = extra;
                if (staff.Type == StaffType.support) staff.Department = extra;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int empCode)
        {
            dynamic staff = Staffs.Single(staff => staff.EmpCode == empCode);

            Staffs.Remove(staff);
            
            return true;
        }
    }
}
