using System.Collections.Generic;
using school;
using System;
using System.IO;
using school.Interface;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleMenu.ShowConsoleMenu();

            //Teacher t = new Teacher("vishnu", "asdasd", 1, "ma");
            //StorageManager man = new StorageManager();

            //man.StoreAsJSON(t, "test", "Teacher");

            //ISerialize storageManager = new StorageManager();

            //List<dynamic> testList = new List<dynamic>
            //{
            //    new Teacher("vishnu", "email", 1, "maths"),
            //    new Administartor("vishnu", "email", 1, "admin")
            //};


            ////##################################################################
            //string xmlFilePath = "/Users/vishnu/desktop/XMLStore/persistence.xml";

            ////if (!File.Exists(xmlFilePath)) return new List<dynamic>();

            //Type[] types = new Type[] { typeof(Teacher), typeof(Administartor) };

            //XmlSerializer xs = new XmlSerializer(typeof(List<dynamic>), types);

            //TextReader reader = new StreamReader(xmlFilePath);
            //dynamic obj = xs.Deserialize(reader);
            //reader.Close();

            //Console.WriteLine(obj[1].Name);
            ////##################################################################

            //if (File.Exists(xmlFilePath)) File.Delete(xmlFilePath);




            //XmlSerializer xs = new XmlSerializer(typeof(List<dynamic>),types);

            //TextWriter txtWriter = new StreamWriter(xmlFilePath);

            //xs.Serialize(txtWriter, testList);

            //txtWriter.Close();

            //XDocument xmlDocument = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),

            //    new XComment("Creating an XML Tree using LINQ to XML"),

            //    new XElement("Staffs",

            //    from l in testList
            //    select new XElement("id", new XAttribute("Id", l.EmpCode.ToString()),
            //        new XElement("Name", l.Name),
            //        new XElement("Email", l.Email)
            //        //new XElement("TotalMarks", l.TotalMarks)
            //        )
            //    ));

            //xmlDocument.Save("/Users/vishnu/desktop/XMLStore/Data.xml");
        }

    }
}
