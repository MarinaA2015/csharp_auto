using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.IsEmptyContactList())
            {
                app.Contacts.Create(new ContactData("Additional", "Contact"));
            }
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
           
            app.Contacts.Remove(toBeRemoved);
            app.Navigator.GoToContactPage();

            List<ContactData> newContacts = ContactData.GetAll();
           
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
                Assert.AreNotEqual(toBeRemoved.Id, contact.Id);
        }
    }
}
