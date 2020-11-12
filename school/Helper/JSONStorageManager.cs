using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using school.Interface;

namespace school
{
    public class JSONStorageManager : ISerialize
    {
        private readonly string jsonFilePath = "/Users/vishnu/desktop/JSONStore/persistence.json";

        public dynamic Deserialize()
        {
            StreamReader streamReader = new StreamReader(this.jsonFilePath);

            List<dynamic> jsonObjects = JsonConvert.DeserializeObject<List<dynamic>>(streamReader.ReadToEnd());

            List<dynamic> staffs = new List<dynamic>();

            foreach (var obj in jsonObjects)
            {
                if (obj.Type == 0)
                {
                    staffs.Add(new Teacher(obj.Name.ToString(), obj.Email.ToString(), int.Parse(obj.EmpCode.ToString()), obj.Subject.ToString()));
                }
                else if (obj.Type == 1)
                {
                    staffs.Add(new Support(obj.Name.ToString(), obj.Email.ToString(), int.Parse(obj.EmpCode.ToString()), obj.Department.ToString()));
                }
                else if (obj.Type == 2)
                {
                    staffs.Add(new Administartor(obj.Name.ToString(), obj.Email.ToString(), int.Parse(obj.EmpCode.ToString()), obj.Role.ToString()));
                }
            }

            return staffs;
        }

        public void Serialize(List<dynamic> staffs)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter sw = new StreamWriter(this.jsonFilePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, staffs);

            jsonWriter.Close();
            sw.Close();
        }
    }
}