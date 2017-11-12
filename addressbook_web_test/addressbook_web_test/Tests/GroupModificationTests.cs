using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class GroupModificationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            app.Groups.Modify(1, new GroupData("NameModif", "HeaderModif", "FooterModif"));
            
        }
    }
}
