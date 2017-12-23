using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECK)
            {
                List<GroupData> fromUIGroups = app.Groups.GetGroupsList();
                List<GroupData> fromDBGroups = GroupData.GetAll();
                fromUIGroups.Sort();
                fromDBGroups.Sort();
                Assert.AreEqual(fromUIGroups, fromDBGroups);
            }
            
        }
    }
}
