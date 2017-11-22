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

    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.IsEmptyContactList())
            {
                app.Contacts.Create(new ContactData("Additional", "Contact"));
            }
            
            app.Contacts.Modify(0, new ContactData("PetrModif", "PetrovModif"));


        }
    }
}
