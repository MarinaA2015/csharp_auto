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
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            String format = args[2];
            String type = args[0];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10)){
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(20)
                });
            }

            switch (format)
            {
                case "csv":
                    writeGroupsToCSV(groups, writer); break;
                case "xml":
                    writeGroupsToXML(groups, writer); break;
                case "json":
                    writeGroupsToJSON(groups, writer); break;
                default:
                    System.Console.Out.WriteLine("Unrecognized format " + format); break;
            }

            
            writer.Close();
        }
        public static void writeGroupsToCSV(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                                 group.Name, group.Header, group.Footer));
                                
            }
        }

        public static void writeGroupsToXML(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        public static void writeGroupsToJSON(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }
    }
}
