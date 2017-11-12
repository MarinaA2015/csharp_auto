using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            app.Contacts.Modify(1, new ContactData("PetrModif", "PetrovModif"));

        }
    }
}
