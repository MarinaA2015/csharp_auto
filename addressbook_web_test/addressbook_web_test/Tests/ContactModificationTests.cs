﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.IsEmptyContactList())
            {
                app.Contacts.Create(new ContactData("Additional", "Contact"));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            oldContacts[0].FirstName = "PetrModif";
            oldContacts[0].LastName = "PetrovModif";
            oldContacts.Sort();

            app.Contacts.Modify(1, new ContactData("PetrModif", "PetrovModif"));
            app.Navigator.GoToContactPage();

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            Assert.AreEqual(oldContacts, newContacts);


        }
    }
}
