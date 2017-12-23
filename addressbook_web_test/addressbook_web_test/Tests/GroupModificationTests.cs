using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class GroupModificationTests : GroupTestBase
    {
        
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsEmptyGroupList())
            {
                app.Groups.Create(new GroupData("Additional Group"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            GroupData group = new GroupData("NameModif", "HeaderModif", "FooterModif");
            app.Groups.Modify(oldData, group);

            List<GroupData> newGroups = GroupData.GetAll();

            oldData.Name = group.Name;
            app.Navigator.OpenHomePage();
            Assert.AreEqual(oldGroups, newGroups);
            foreach(GroupData element in newGroups)
            {
                if (element.Id == oldData.Id)
                    Assert.AreEqual(element.Name, group.Name);
            }
        }
    }
}
