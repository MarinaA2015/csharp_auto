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
            GroupData grWithContacts = null;
            foreach(GroupData gr in groups)
                 if (gr.GetContacts().Any())
                {
                    grWithContacts = gr;
                    break;
                }
            if (grWithContacts == null)
            {
                Console.Out.WriteLine("No groups with contacts");
                return;
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
