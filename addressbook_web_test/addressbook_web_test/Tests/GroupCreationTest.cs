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

            app.Groups.Create(new GroupData("Name", "Header", "Footer"));         
            app.Auth.Logout();
        }

        
    }
}