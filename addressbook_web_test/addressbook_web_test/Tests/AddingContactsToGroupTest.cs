using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactsToGroupTest : AuthTestBase
    {
        [Test]
        public void AddingCotactToGroupTest()
        {
            GroupData group;
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
                app.Groups.Create(new GroupData("Name1", "Header1", "Footer1"));   
                        
            group = GroupData.GetAll()[0];

           // Console.Out.WriteLine("Group Id: " + group.Id);

            ContactData contact;
            List<ContactData> oldList = group.GetContacts();
          
            /*Console.Out.WriteLine("------------------------ContctData.GetAll()------------------------------------");
            Console.Out.WriteLine("ContactData.GetAll()" + ContactData.GetAll().Count);
            foreach (ContactData c in ContactData.GetAll())
                Console.Out.WriteLine(c.Id + " - " + c.FirstName);*/
          
            if (ContactData.GetAll().Count == oldList.Count)
                app.Contacts.Create(new ContactData("First Name1", "Last Name1"));


            /*Console.Out.WriteLine("---old list----");
             foreach (ContactData c in oldList)
                 Console.Out.WriteLine(c.Id + " - " + c.FirstName);*/

            contact = ContactData.GetAll().Except(oldList).First();
           
            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList,newList);
        }
    }
}
