using System.Xml.Serialization;
using System.IO;
using System;

namespace school
{
    public class StorageManager
    {
        private readonly string filePath = "/Users/vishnu/desktop/XMLStore/";

        //save individual objects
        public void StoreAsXML(object obj, string fileName, string className)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());

            TextWriter txtWriter = new StreamWriter(this.filePath + className + "/" + fileName + ".xml");

            xs.Serialize(txtWriter, obj);

            txtWriter.Close();
        }

        //retreive all files in a particular folder of a type
        public dynamic RetreiveXML(string filePath)
        {
            //List<dynamic> objs = new List<dynamic>();

            Type objType = null;

            string[] path = filePath.Split("/");

            //Console.WriteLine();
            //Console.WriteLine("###############");
            //Console.WriteLine(path[^2]);
            //Console.WriteLine("###############");
            //Console.WriteLine();

            if (path[^2] == "Teacher") objType = typeof(Teacher);
            else if (path[^2] == "Administrator") objType = typeof(Administartor);
            else if (path[^2] == "Support") objType = typeof(Support);

            XmlSerializer xs = new XmlSerializer(objType);

            TextReader reader = new StreamReader(filePath);
            object obj = xs.Deserialize(reader);
            //objs.Add(obj);
            reader.Close();

            //string[] files = Directory.GetFiles(this.filePath + "/" + className);

            //foreach (string file in files)
            //{
            //    //check whether the file extension is xml
            //    string[] fileNameAndExtension = file.Split(".");
            //    if (fileNameAndExtension[1] != "xml") continue;

            //    TextReader reader = new StreamReader(file);
            //    object obj = xs.Deserialize(reader);
            //    objs.Add(obj);
            //    reader.Close();
            //}

            return obj;
        }
    }
}
