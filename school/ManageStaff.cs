using System.Collections.Generic;

namespace school
{
    public class ManageStaff
    {
        private List<dynamic> Staffs = new List<dynamic>();

        public void AddStaff(int type, string name, string email, int empCode, string extra)
        {
            //teacher
            if (type == 1)
            {
                Staffs.Add(new Teacher(name,email,empCode, extra));
            }
            //admin
            else if (type == 2)
            {
                Staffs.Add(new Administartor(name, email, empCode, extra));
            }
            //support
            else if (type == 3)
            {
                Staffs.Add(new Support(name, email, empCode, extra));
            }
        }

        public List<dynamic> GetAll()
        {
            return Staffs;
        }

        public dynamic GetOne(int empCode)
        {
            for (int i=0; i<Staffs.Count; i++)
            {
                if (Staffs[i].EmpCode == empCode) return Staffs[i];
            }

            throw new StaffNotFoundException();
        }

        public bool Update(int empCode, string name, string email, string extra)
        {
            for (int i = 0; i < Staffs.Count; i++)
            {
                if (Staffs[i].EmpCode == empCode)
                {
                    Staffs[i].Name = name;
                    Staffs[i].Email = email;
                    if (Staffs[i].Type == "teacher") Staffs[i].Subject = extra;
                    else if (Staffs[i].Type == "administrator") Staffs[i].Role = extra;
                    if (Staffs[i].Type == "support") Staffs[i].Department = extra;

                    return true;
                }
            }

            return false;
        }

        public bool Delete(int empCode)
        {
            for (int i = 0; i < Staffs.Count; i++)
            {
                if (Staffs[i].EmpCode == empCode)
                {
                    Staffs.RemoveAt(i);
                    return true;
                }
            }
            return false;
            //throw new StaffNotFoundException();
        }
    }
}
