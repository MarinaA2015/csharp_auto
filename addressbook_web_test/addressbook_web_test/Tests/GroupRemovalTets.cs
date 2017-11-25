using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsEmptyGroupList())
            {
                app.Groups.Create(new GroupData("Additional Group"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Remove(1);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            GroupData element = oldGroups[0];
            oldGroups.RemoveAt(0);
            app.Navigator.GoToGroupPage();

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
                Assert.AreNotEqual(group.Id, element.Id);

            
        }
        

       

      

        

        

      
        

     
      
    }
}

