﻿using System;
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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupCreation();
            InitNewgroupCreation();
            FillFieldsOfGroup(new GroupData("name1","header1","footer1"));
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }

        
    }
}
