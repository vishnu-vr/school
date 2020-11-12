using System.Xml.Serialization;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using school.Interface;
using System.Collections.Generic;

namespace school
{
    public class XMLStorageManager : InMemoryManageStaff, ISerialize
    {

        private readonly string xmlFilePath = "/Users/vishnu/desktop/XMLStore/persistence.xml";
        readonly Type[] types = new Type[] { typeof(Teacher), typeof(Administartor), typeof(Support) };

        public XMLStorageManager()
        {
            base.Staffs.AddRange(this.Deserialize());
        }

        public dynamic Deserialize()
        {
            if (!File.Exists(this.xmlFilePath)) return new List<dynamic>();

            XmlSerializer xs = new XmlSerializer(typeof(List<dynamic>), this.types);

            TextReader reader = new StreamReader(this.xmlFilePath);
            dynamic obj = xs.Deserialize(reader);
            reader.Close();

            return obj;
        }

        public void Serialize()
        {
            if (File.Exists(this.xmlFilePath)) File.Delete(this.xmlFilePath);

            XmlSerializer xs = new XmlSerializer(typeof(List<dynamic>), this.types);

            TextWriter txtWriter = new StreamWriter(this.xmlFilePath);

            xs.Serialize(txtWriter, base.Staffs);

            txtWriter.Close();
        }


        //private readonly string xmlFilePath = "/Users/vishnu/desktop/XMLStore/";

        //private readonly string jsonFilePath = "/Users/vishnu/desktop/JSONStore/";

        //public void StoreAsJSON(object obj, string fileName, string className)
        //{
        //    JsonSerializer jsonSerializer = new JsonSerializer();
        //    StreamWriter sw = new StreamWriter(this.jsonFilePath +  className + "/" + fileName + ".json");
        //    JsonWriter jsonWriter = new JsonTextWriter(sw);

        //    jsonSerializer.Serialize(jsonWriter, obj);

        //    jsonWriter.Close();
        //    sw.Close();
        //}

        ////public void RetreiveJSON(strin)
        ////{
        ////    JObject jObject = null;
        ////    JsonSerializer jsonSerializer = new JsonSerializer();


        ////}

        ////save individual objects
        //public void StoreAsXML(object obj, string fileName, string className)
        //{
        //    XmlSerializer xs = new XmlSerializer(obj.GetType());

        //    TextWriter txtWriter = new StreamWriter(this.xmlFilePath + className + "/" + fileName + ".xml");

        //    xs.Serialize(txtWriter, obj);

        //    txtWriter.Close();
        //}

        ////retreive all files in a particular folder of a type
        //public dynamic RetreiveXML(string filePath)
        //{
        //    Type objType = null;

        //    string[] path = filePath.Split("/");

        //    if (path[^2] == "Teacher") objType = typeof(Teacher);
        //    else if (path[^2] == "Administrator") objType = typeof(Administartor);
        //    else if (path[^2] == "Support") objType = typeof(Support);

        //    XmlSerializer xs = new XmlSerializer(objType);

        //    TextReader reader = new StreamReader(filePath);
        //    object obj = xs.Deserialize(reader);
        //    reader.Close();

        //    return obj;
        //}

        //public void DeleteXML(string folderName, string fileName)
        //{
        //    if (File.Exists(Path.Combine(this.xmlFilePath + folderName, fileName + ".xml")))
        //    {
        //        // If file found, delete it
        //        string exactPath = this.xmlFilePath + folderName + "/" + fileName + ".xml";
        //        File.Delete(exactPath);
        //    }
        //}
    }
}
