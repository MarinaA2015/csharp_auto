using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

       
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.InitNewgroupCreation();
            app.Groups.FillFieldsOfGroup(new GroupData("name1","header1","footer1"));
            app.Groups.SubmitGroupCreation();
            app.Navigator.GoToGroupPage();
            app.Auth.Logout();
        }

        
    }
}
