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
    public class ContactHelper  : HelperBase
    {
        

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
           
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillFieldsOfContact(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int i,ContactData newData)
        {
            manager.Navigator.GoToContactPage();
            InitModifyContact(i,newData);
            FillFieldsOfContact(newData);
            SubmitContactModification();
            return this;
        }
        public ContactHelper Remove(int i)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(i);
            RemoveSelectedContact();
            return this;
        }

        public ContactHelper InitModifyContact(int i,ContactData newData)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + i + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        
        public ContactHelper RemoveSelectedContact()
        {
            driver.FindElement(By.CssSelector("input[value=\"Delete\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SelectContact( int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + i + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillFieldsOfContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;

        }
    }
}
