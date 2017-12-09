using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            String format = args[3];
            String type = args[0];

            if (format != "xml" && format != "json")
                System.Console.Out.WriteLine("Unrecognized format " + format);

            if (type == "groups")
                GeneratorForGroups(writer, format, count);
            else if (type == "contacts")
                GeneratorForContacts(writer, format, count);
            else System.Console.Out.WriteLine("Unrecognized type " + type);

            writer.Close();
        }

        private static void GeneratorForContacts(StreamWriter writer, string format, int count)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10),
                                         TestBase.GenerateRandomString(10)));
            }
            if (format == "xml") writeContactsToXML(contacts, writer);
                else writeContactsToJSON(contacts, writer);

        }

        private static void GeneratorForGroups(StreamWriter writer, string format, int count)
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(20)
                });
            }

            if (format == "xml") writeGroupsToXML(groups, writer);
                else writeGroupsToJSON(groups, writer);
            
        }


        public static void writeGroupsToXML(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        public static void writeGroupsToJSON(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }

        public static void writeContactsToXML(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        public static void writeContactsToJSON(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts));
        }
    }
}
