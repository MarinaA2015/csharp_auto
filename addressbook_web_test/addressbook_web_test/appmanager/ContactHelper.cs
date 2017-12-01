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

        internal ContactData GetContactFromForm(int index)
        {
            index++;
            manager.Navigator.OpenHomePage();
            manager.Contacts.InitModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            //Console.WriteLine("firstName - " + firstName);
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
           // Console.WriteLine("lastName - " + lastName);

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };


        }

        internal ContactData GetContactFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
           // Console.WriteLine("lastName - " + lastName);
            string firstName = cells[2].Text;
           // Console.WriteLine("firstName - " + firstName);
            string address = cells[3].Text;
            // Console.WriteLine("address - " + address);
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            // Console.WriteLine("allPhones - " + allPhones);

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
               
            };
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));

                foreach (IWebElement element in elements)
                {
                    ICollection<IWebElement> attr = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text,
                                                   element.FindElements(By.TagName("td"))[1].Text){
                                              Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                                      });
                }
            }
            
            return new List<ContactData>(contactCache);
        }

        public ContactHelper Modify(int i,ContactData newData)
        {
            manager.Navigator.GoToContactPage();
            InitModifyContact(i);
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
      
        public ContactHelper InitModifyContact(int i)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + i +"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        
        public ContactHelper RemoveSelectedContact()
        {
            driver.FindElement(By.CssSelector("input[value=\"Delete\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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
            contactCache = null;
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
