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
            app.Groups.IntelligentRemove(10);
            app.Navigator.GoToGroupPage();
        }
        

       

      

        

        

      
        

     
      
    }
}

