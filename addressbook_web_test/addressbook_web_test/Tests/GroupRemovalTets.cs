using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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
            app.Groups.Remove(0);
            app.Navigator.GoToGroupPage();
        }
        

       

      

        

        

      
        

     
      
    }
}

