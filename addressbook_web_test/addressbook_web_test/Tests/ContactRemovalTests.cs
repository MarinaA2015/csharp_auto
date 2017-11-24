using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.IsEmptyContactList())
            {
                app.Contacts.Create(new ContactData("Additional", "Contact"));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(1);
            app.Navigator.GoToContactPage();

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
