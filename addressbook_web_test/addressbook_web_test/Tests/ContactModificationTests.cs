using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.IsEmptyContactList())
            {
                app.Contacts.Create(new ContactData("Additional", "Contact"));
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];
            oldContacts[0].FirstName = "PetrModif";
            oldContacts[0].LastName = "PetrovModif";
            oldContacts.Sort();

            app.Contacts.Modify(oldData, new ContactData("PetrModif", "PetrovModif"));
            app.Navigator.GoToContactPage();

            List<ContactData> newContacts = ContactData.GetAll();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            foreach(ContactData data in newContacts)
            {
                if (oldData.Id == data.Id)
                {
                    Assert.AreEqual(oldData.FirstName, data.FirstName);
                    Assert.AreEqual(oldData.LastName, data.LastName);
                }
                   
            }
        }
    }
}
