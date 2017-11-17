using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
       

        public GroupHelper(ApplicationManager manager)
            :base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitNewgroupCreation();
            FillFieldsOfGroup(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupPage();
            return this;
        }
        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(i);
            DeleteGroup();
            return this;
        }

        public GroupHelper Modify(int i, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            InitModifyGroup(i);
            FillFieldsOfGroup(newData);
            SubmitModifyGroup();
            manager.Navigator.GoToGroupPage();

            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper InitNewgroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillFieldsOfGroup(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
           
            return this;
        }


        private GroupHelper SubmitModifyGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitModifyGroup(int i)
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }

   
}
