﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCSVFile()
        {
            List<GroupData> groups = new List<GroupData>();
            String[] lines = File.ReadAllLines(@"groups.csv");
            foreach (String l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            List<GroupData> groups = new List<GroupData>();

            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"example.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            return JsonConvert
                 .DeserializeObject<List<GroupData>>(File.ReadAllText(@"example.json"));


        }

        [Test, TestCaseSource("GroupDataFromJSONFile")]
        public void GroupCreationAutoParameters(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            app.Navigator.OpenHomePage();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }



        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData group = new GroupData("Name", "Header", "Footer");
            app.Groups.Create(group);

            List<GroupData> newGroups = GroupData.GetAll();
            app.Navigator.OpenHomePage();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            List<GroupData> groups = GroupData.GetAll();
            GroupData group2 = new GroupData();
            foreach (GroupData gr in groups)
                if (gr.Id == "108")
                    group2 = gr;
            foreach (ContactData contact in group2.GetContacts())
                Console.Out.WriteLine(contact);
            

        }
    }
}
