using System;
using System.Collections.Generic;
using System.Linq;

namespace school
{
    public class ManageStaff : IManageStaff
    {
        private List<dynamic> Staffs = new List<dynamic>();

        public void AddStaff(Type type, string name, string email, int empCode, string extra)
        {
            //teacher
            if (type == Type.teacher) Staffs.Add(new Teacher(name, email, empCode, extra));

            //admin
            else if (type == Type.administrator) Staffs.Add(new Administartor(name, email, empCode, extra));

            //support
            else if (type == Type.support) Staffs.Add(new Support(name, email, empCode, extra));
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
                if (staff.StaffType == Type.teacher) staff.Subject = extra;
                else if (staff.StaffType == Type.administrator) staff.Role = extra;
                if (staff.StaffType == Type.support) staff.Department = extra;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int empCode)
        {
            Staffs = Staffs.Where(staff => staff.EmpCode != empCode).ToList();
            return true;
        }
    }
}
