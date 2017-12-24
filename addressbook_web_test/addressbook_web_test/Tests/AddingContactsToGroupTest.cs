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
            GroupData group = GroupData.GetAll()[0];
          //  Console.Out.WriteLine("Group Id: " + group.Id);
            List<ContactData> oldList = group.GetContacts();
           /* Console.Out.WriteLine("---old list----");
            foreach (ContactData c in oldList)
                Console.Out.WriteLine(c.Id + " - " + c.FirstName);*/

            ContactData contact = ContactData.GetAll().Except(oldList).First();
            Console.Out.WriteLine("contact to add: " + contact.Id + " - " + contact.FirstName);

            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            
            oldList.Sort();
            newList.Sort();
          /*  Console.Out.WriteLine("---old list----");
            foreach (ContactData c in oldList)
                Console.Out.WriteLine(c.Id + " - " + c.FirstName);
            Console.Out.WriteLine("---new list----");
            foreach (ContactData c in newList)
                Console.Out.WriteLine(c.Id + " - " + c.FirstName);*/
            Assert.AreEqual(oldList,newList);
        }
    }
}
