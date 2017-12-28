using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
                app.Groups.Create(new GroupData("Name2", "Header2", "Footer2"));

            GroupData grWithContacts = null;
            foreach(GroupData gr in groups)
                 if (gr.GetContacts().Any())
                {
                    grWithContacts = gr;
                    break;
                }
            if (grWithContacts == null)
            {
                if (ContactData.GetAll().Count == 0)
                    app.Contacts.Create(new ContactData("First Name2", "Last Name2"));

                ContactData contact = ContactData.GetAll()[0];

                grWithContacts = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(contact, grWithContacts);

            }
            //Console.Out.WriteLine("group: " + grWithContacts.Id + "-" + grWithContacts.Name);

            List<ContactData> oldContacts = grWithContacts.GetContacts();
            ContactData contactForRemove = oldContacts[0];

            //Console.Out.WriteLine("contact: " + contactForRemove.Id + "-" + contactForRemove.FirstName);

            app.Contacts.RemoveContactFromGroup(grWithContacts, contactForRemove);

            List<ContactData> newContacts = grWithContacts.GetContacts();
            newContacts.Add(contactForRemove);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
                     
        }
    }
}
