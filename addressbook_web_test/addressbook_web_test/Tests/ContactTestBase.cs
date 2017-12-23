using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECK)
            {
                List<ContactData> fromUIContacts = app.Contacts.GetContactsList();
                List<ContactData> fromDBContacts = ContactData.GetAll();
                fromUIContacts.Sort();
                fromDBContacts.Sort();
                Assert.AreEqual(fromUIContacts, fromDBContacts);
            }

        }
    }
}
