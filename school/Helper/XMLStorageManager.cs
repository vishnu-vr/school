using System.Xml.Serialization;
using System.IO;
using System;
using school.Interface;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace school
{
    public class XMLStorageManager : ISerialize
    {
        private readonly string xmlFilePath;
        readonly Type[] types = new Type[] { typeof(Teacher), typeof(Administartor), typeof(Support) };

        public XMLStorageManager()
        {
            //get and build configuration file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //fetch file path
            this.xmlFilePath = config["XMLFilePath"];
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

        public void Serialize(List<dynamic> staffs)
        {
            if (File.Exists(this.xmlFilePath)) File.Delete(this.xmlFilePath);

            XmlSerializer xs = new XmlSerializer(typeof(List<dynamic>), this.types);

            TextWriter txtWriter = new StreamWriter(this.xmlFilePath);

            xs.Serialize(txtWriter, staffs);

            txtWriter.Close();
        }
    }
}
