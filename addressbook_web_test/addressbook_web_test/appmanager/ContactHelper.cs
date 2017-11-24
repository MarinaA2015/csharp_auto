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

        internal List<ContactData> GetContactsList()
        {
            
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));

            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> attr = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text,
                                               element.FindElements(By.TagName("td"))[1].Text));
            }
            return contacts;
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

        public bool IsEmptyContactList()
        {
            return !IsElementPresent(By.XPath("//img[@alt='Edit']"));

        }
      
        public ContactHelper InitModifyContact(int i,ContactData newData)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + i +"]")).Click();
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
           
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
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
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
           
            return this;

        }
    }
}
