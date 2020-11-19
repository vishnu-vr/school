using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using school;

namespace consoleapp
{
    public class ConsoleMenu
    {
        public static IManageStaff GetManager()
        {
            //get and build configuration file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //fetch managerClass
            string managerClassTypeString = config["managerClass"];

            //get the type of the class
            Type managerClassType = Type.GetType("school." + managerClassTypeString + ",school", true);

            //build an instance of the class
            IManageStaff manager = Activator.CreateInstance(managerClassType) as IManageStaff;

            return manager;
        }

        public static void ShowConsoleMenu()
        {
            IManageStaff manager = GetManager();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add New Staff");
                Console.WriteLine("2. View All Staff Details");
                Console.WriteLine("3. View Specific Staff Detail");
                Console.WriteLine("4. Update Details");
                Console.WriteLine("5. Delete Staff");
                Console.WriteLine("6. Bulk Add Staff");
                Console.WriteLine("7. exit");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());

                //add
                if (option == 1) AddStaffMethod(manager);

                //view all
                else if (option == 2) ViewAllMethod(manager);

                //view specific one
                else if (option == 3) ViewSpecificMethod(manager);

                //update
                else if (option == 4) UpdateMethod(manager);

                //delete
                else if (option == 5) DeleteMethod(manager);

                //bulk add
                else if (option == 6) BulkAddStaffMethod(manager);

                else Environment.Exit(0);

                Console.WriteLine();
                Console.WriteLine("Go again ?");
                Console.WriteLine("1. No");
                Console.WriteLine("2. Yes");
                option = int.Parse(Console.ReadLine());
                if (option == 1) Environment.Exit(0);
                else Console.Clear();

            }
        }

        public static void BulkAddStaffMethod(dynamic manager)
        {
            Console.Write("Enter the number of bulk insertion : ");
            int count = int.Parse(Console.ReadLine());

            List<dynamic> Staffs = new List<dynamic>();

            string name = null;
            string email = null;
            int id = 0;
            string subject = null;
            string role = null;
            string dept = null;

            for (int i=0; i<count; i++) 
            {
                Console.Write("Name : ");
                name = Console.ReadLine();
                Console.Write("Email : ");
                email = Console.ReadLine();
                Console.Write("emp id : ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Staff Type : ");
                Console.WriteLine("1. Teacher");
                Console.WriteLine("2. Administrator");
                Console.WriteLine("3. Support");
                int type = int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    Console.WriteLine();
                    Console.Write("Enter Subject : ");
                    subject = Console.ReadLine();
                    Staffs.Add(new Teacher(name, email, id, subject));
                }
                else if (type == 2)
                {
                    Console.WriteLine();
                    Console.Write("Enter Role : ");
                    role = Console.ReadLine();
                    Staffs.Add(new Administrator(name, email, id, role));
                }
                else if (type == 3)
                {
                    Console.WriteLine();
                    Console.Write("Enter Department : ");
                    dept = Console.ReadLine();
                    Staffs.Add(new Support(name, email, id, dept));
                }
            }

            manager.Bulk_AddStaff(Staffs);
        }

        public static void AddStaffMethod(IManageStaff manager)
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("emp id : ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Staff Type : ");
            Console.WriteLine("1. Teacher");
            Console.WriteLine("2. Administrator");
            Console.WriteLine("3. Support");
            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                Console.WriteLine();
                Console.Write("Enter Subject : ");
                string subject = Console.ReadLine();
                manager.AddStaff(school.StaffType.teacher, name, email, id, subject);
            }
            else if (type == 2)
            {
                Console.WriteLine();
                Console.Write("Enter Role : ");
                string role = Console.ReadLine();
                manager.AddStaff(school.StaffType.administrator, name, email, id, role);
            }
            else if (type == 3)
            {
                Console.WriteLine();
                Console.Write("Enter Department : ");
                string dept = Console.ReadLine();
                manager.AddStaff(school.StaffType.support, name, email, id, dept);
            }
        }

        public static void ViewAllMethod(IManageStaff manager)
        {
            List<dynamic> Staffs = manager.GetAll();
            for (int i = 0; i < Staffs.Count; i++)
            {
                PrintDetails(Staffs[i]);
            }
        }

        public static void ViewSpecificMethod(IManageStaff manager)
        {
            Console.WriteLine("Enter Emp Code : ");
            int empCode = int.Parse(Console.ReadLine());
            try
            {
                dynamic staff = manager.GetOne(empCode);
                PrintDetails(staff);
            }
            catch (Exception)
            {
                Console.WriteLine("Staff with given code doesn't exists");
            }
        }

        public static void UpdateMethod(IManageStaff manager)
        {
            Console.WriteLine("Enter Emp Code : ");
            int empCode = int.Parse(Console.ReadLine());

            try
            {
                dynamic staff = manager.GetOne(empCode);

                Console.WriteLine("Enter new name : ");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter new email : ");
                string newEmail = Console.ReadLine();

                if (staff.Type == school.StaffType.teacher)
                {
                    Console.WriteLine("Enter new subject : ");
                }
                else if (staff.Type == school.StaffType.support)
                {
                    Console.WriteLine("Enter new deparment : ");
                }
                else if (staff.Type == school.StaffType.administrator)
                {
                    Console.WriteLine("Enter new role : ");
                }

                string extra = Console.ReadLine();

                if (manager.Update(empCode, newName, newEmail, extra))
                {
                    Console.WriteLine("Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Staff with given code doesn't exists");
            }
        }

        public static void DeleteMethod(IManageStaff manager)
        {
            Console.WriteLine("Enter Emp Code : ");
            int empCode = int.Parse(Console.ReadLine());
            if (manager.Delete(empCode))
            {
                Console.WriteLine("Successfully Deleted");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        public static void PrintDetails(dynamic staff)
        {
            Console.WriteLine(staff.Name);
            Console.WriteLine(staff.Email);
            Console.WriteLine(staff.EmpCode);
            Console.WriteLine(staff.Type);
            if (staff.Type == school.StaffType.teacher)
            {
                Console.WriteLine(staff.Subject);
            }
            else if (staff.Type == school.StaffType.support)
            {
                Console.WriteLine(staff.Department);
            }
            else if (staff.Type == school.StaffType.administrator)
            {
                Console.WriteLine(staff.Role);
            }
            Console.WriteLine("----------------------------");
        }
    }
}
