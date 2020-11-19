using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using school.Interface;

namespace school
{
    public class JSONStorageManager : ISerialize
    {
        private readonly string jsonFilePath;

        public JSONStorageManager()
        {
            //get and build configuration file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //fetch file path
            this.jsonFilePath = config["JSONFilePath"];
        }

        public dynamic Deserialize()
        {
            if (!File.Exists(this.jsonFilePath))
            {
                return new List<dynamic>();
            }

            StreamReader streamReader = new StreamReader(this.jsonFilePath);

            List<dynamic> jsonObjects = JsonConvert.DeserializeObject<List<dynamic>>(streamReader.ReadToEnd());

            streamReader.Close();

            List<dynamic> staffs = new List<dynamic>();

            foreach (var obj in jsonObjects)
            {
                if (obj.Type == 0)
                {
                    staffs.Add(new Teacher(obj.Name.ToString(), 
                                            obj.Email.ToString(), 
                                            int.Parse(obj.EmpCode.ToString()), 
                                            obj.Subject.ToString()));
                }
                else if (obj.Type == 1)
                {
                    staffs.Add(new Support(obj.Name.ToString(), 
                                            obj.Email.ToString(), 
                                            int.Parse(obj.EmpCode.ToString()), 
                                            obj.Department.ToString()));
                }
                else if (obj.Type == 2)
                {
                    staffs.Add(new Administrator(obj.Name.ToString(), 
                                                obj.Email.ToString(), 
                                                int.Parse(obj.EmpCode.ToString()), 
                                                obj.Role.ToString()));
                }
            }

            return staffs;
        }

        public void Serialize(List<dynamic> staffs)
        {
            if (File.Exists(this.jsonFilePath))
            {
                File.Delete(this.jsonFilePath);
            }

            StreamWriter sw = new StreamWriter(this.jsonFilePath);

            string jsonString = JsonConvert.SerializeObject(staffs);

            sw.Write(jsonString);
            sw.Close();
        }
    }
}