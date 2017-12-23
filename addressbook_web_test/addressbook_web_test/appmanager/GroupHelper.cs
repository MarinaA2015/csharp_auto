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

        

        private List<GroupData> groupCache = null;

        internal List<GroupData> GetGroupsList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(null) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };

                    groupCache.Add(group);
                }
                string allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string [] parts = allGroupsNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                }
            }    

            return new List<GroupData>(groupCache);
        }

        public GroupHelper Remove(GroupData toBeRemoved)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(toBeRemoved.Id);
            DeleteGroup();
            return this;
        }

       

        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(i);
            DeleteGroup();
            return this;
        }

        internal GroupHelper Modify(GroupData oldData, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(oldData.Id);
            InitModifyGroup();
            FillFieldsOfGroup(newData);
            SubmitModifyGroup();
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public GroupHelper Modify(int i, GroupData newData)
        {
             manager.Navigator.GoToGroupPage();          
             SelectGroup(i);
             InitModifyGroup();
             FillFieldsOfGroup(newData);
             SubmitModifyGroup();
             manager.Navigator.GoToGroupPage();            
           
            return this;
        }

        public bool IsEmptyGroupList()
        {
            return !IsElementPresent(By.XPath("//input[@name='selected[]']"));
        }


        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+"']")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        private GroupHelper InitModifyGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }

   
}
