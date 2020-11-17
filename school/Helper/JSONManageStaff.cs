using System;
using System.Collections.Generic;
using System.Linq;

namespace school
{
    public class JSONManageStaff : IManageStaff
    {
        readonly JSONStorageManager storageManager;

        public JSONManageStaff()
        {
            this.storageManager = new JSONStorageManager();
        }

        public void AddStaff(StaffType type, string name, string email, int empCode, string extra)
        {
            //getting the entire info from json
            var staffs = (List<dynamic>)this.storageManager.Deserialize();

            //teacher
            if (type == StaffType.teacher) staffs.Add(new Teacher(name, email, empCode, extra));

            //admin
            else if (type == StaffType.administrator) staffs.Add(new Administrator(name, email, empCode, extra));

            //support
            else if (type == StaffType.support) staffs.Add(new Support(name, email, empCode, extra));

            //saving it back to json
            this.storageManager.Serialize(staffs);
        }

        public bool Delete(int empCode)
        {
            var staffs = (List<dynamic>)this.storageManager.Deserialize();

            dynamic staff = staffs.Single(stf => stf.EmpCode == empCode);

            staffs.Remove(staff);

            this.storageManager.Serialize(staffs);

            return true;
        }

        public List<dynamic> GetAll()
        {
            var staffs = (List<dynamic>)this.storageManager.Deserialize();

            return staffs;
        }

        public dynamic GetOne(int empCode)
        {
            var staffs = (List<dynamic>)this.storageManager.Deserialize();

            return staffs.Single(staff => staff.EmpCode == empCode);
        }

        public bool Update(int empCode, string name, string email, string extra)
        {
            var staffs = (List<dynamic>)this.storageManager.Deserialize();

            try
            {
                dynamic staff = staffs.Single(staff => staff.EmpCode == empCode);

                staff.Name = name;
                staff.Email = email;
                if (staff.Type == StaffType.teacher) staff.Subject = extra;
                else if (staff.Type == StaffType.administrator) staff.Role = extra;
                if (staff.Type == StaffType.support) staff.Department = extra;

                this.storageManager.Serialize(staffs);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
