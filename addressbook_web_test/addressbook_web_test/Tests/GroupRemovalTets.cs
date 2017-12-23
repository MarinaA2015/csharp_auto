using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsEmptyGroupList())
            {
                app.Groups.Create(new GroupData("Additional Group"));
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
            app.Navigator.GoToGroupPage();

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);

            
        }
        

       

      

        

        

      
        

     
      
    }
}

