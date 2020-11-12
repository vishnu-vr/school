using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace school
{
    public class ManageStaff : IManageStaff
    {
        private List<dynamic> Staffs;// = new List<dynamic>();

        StorageManager storageManager = new StorageManager();

        public ManageStaff()
        {
            this.Staffs = RetreiveAllXml();
        }

        public void AddStaff(StaffType type, string name, string email, int empCode, string extra)
        {
            //teacher
            if (type == StaffType.teacher) Staffs.Add(new Teacher(name, email, empCode, extra));

            //admin
            else if (type == StaffType.administrator) Staffs.Add(new Administartor(name, email, empCode, extra));

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
            //Staffs = Staffs.Where(staff => staff.EmpCode != empCode).ToList();

            dynamic staff = Staffs.Single(staff => staff.EmpCode == empCode);

            string folderName = null;

            if (staff.Type == StaffType.administrator) folderName = "Administrator";
            else if (staff.Type == StaffType.teacher) folderName = "Teacher";
            else if (staff.Type == StaffType.support) folderName = "Support";

            storageManager.DeleteXML(folderName, staff.EmpCode.ToString());

            Staffs.Remove(staff);
            
            return true;
        }

        public void SaveAsXml()
        {
            string folderName = "";

            for (int i=0; i<Staffs.Count; i++)
            {
                if (Staffs[i].Type == StaffType.administrator) folderName = "Administrator";
                else if (Staffs[i].Type == StaffType.teacher) folderName = "Teacher";
                else if (Staffs[i].Type == StaffType.support) folderName = "Support";

                storageManager.StoreAsXML(Staffs[i], Staffs[i].EmpCode.ToString(), folderName);
            }
        }

        public List<dynamic> RetreiveAllXml()
        {

            //Console.WriteLine("in retriving function");

            List<dynamic> objs = new List<dynamic>();

            string filePath = "/Users/vishnu/desktop/XMLStore/";

            //string[] files = { };

            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(filePath + "Teacher"));
            files.AddRange(Directory.GetFiles(filePath + "Administrator"));
            files.AddRange(Directory.GetFiles(filePath + "Support"));

            //Console.WriteLine("before loop");

            //string[] t = Directory.GetFiles(filePath + "Teacher");

            //Console.WriteLine(t[0]);

            for (int i=0; i<files.Count; i++)
            {
                //Console.WriteLine(files[i]);

                //check whether the file extension is xml
                string[] fileNameAndExtension = files[i].Split(".");
                if (fileNameAndExtension[1] != "xml") continue;

                dynamic obj = storageManager.RetreiveXML(files[i]);

                objs.Add(obj);
            }



            return objs;
        }
    }
}
