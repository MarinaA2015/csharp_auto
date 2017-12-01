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

    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            app.Navigator.GoToContactPage();
            ContactData fromTable = app.Contacts.GetContactFromTable(0);
            ContactData fromForm = app.Contacts.GetContactFromForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}
