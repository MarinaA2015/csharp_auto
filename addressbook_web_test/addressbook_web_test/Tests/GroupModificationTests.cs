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

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            GroupData oldData = oldGroups[0];

            GroupData group = new GroupData("NameModif", "HeaderModif", "FooterModif");
            app.Groups.Modify(0, group);

            List<GroupData> newGroup = app.Groups.GetGroupsList();

            oldGroups[0].Name = group.Name;
            app.Navigator.OpenHomePage();
            Assert.AreEqual(oldGroups, newGroup);
            foreach(GroupData element in newGroup)
            {
                if (element.Id == oldData.Id)
                    Assert.AreEqual(element.Name, group.Name);
            }
        }
    }
}
