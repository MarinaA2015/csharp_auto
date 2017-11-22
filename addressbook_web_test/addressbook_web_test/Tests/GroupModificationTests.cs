using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class GroupModificationTests : AuthTestBase
    {
        
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsEmptyGroupList())
            {
                app.Groups.Create(new GroupData("Additional Group"));
            }
            app.Groups.Modify(0, new GroupData("NameModif", "HeaderModif", "FooterModif"));
            app.Navigator.OpenHomePage();
            
        }
    }
}
