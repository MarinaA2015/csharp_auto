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
            app.Contacts.Remove(0);
            
        }
    }
}
