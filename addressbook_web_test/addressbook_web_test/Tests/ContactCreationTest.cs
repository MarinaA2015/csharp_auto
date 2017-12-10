using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Company = GenerateRandomString(50),
                    Address = GenerateRandomString(100)
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"cont.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert
                 .DeserializeObject<List<ContactData>>(File.ReadAllText(@"cont.json"));


        }


        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreationAutoParameters(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contact);

            app.Contacts.Create(contact);
            app.Navigator.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Console.WriteLine("newContact - " + newContacts.Count);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactCreationTest()
        {

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            ContactData contact = new ContactData("Ivan", "Ivanov");

            oldContacts.Add(contact);
            
            app.Contacts.Create(contact);
            app.Navigator.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Console.WriteLine("newContact - " + newContacts.Count);

            oldContacts.Sort();
            newContacts.Sort();
           
            Assert.AreEqual(oldContacts, newContacts);
            
        }     
        
    }
}
