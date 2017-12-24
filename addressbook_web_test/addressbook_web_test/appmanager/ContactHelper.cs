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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            //ClearGroupFilter();
            SelectGroup(group.Name);
            SelectContact(contact.Id);         
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        internal void RemoveContactFromGroup(GroupData group, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            
            CommitRemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);


        }
      
        private void CommitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        internal ContactData GetContactFromForm(int index)
        {
            index++;
            manager.Navigator.OpenHomePage();
            manager.Contacts.InitModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            // Console.WriteLine("lastName - " + lastName);
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string home = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                BDay = bDay,
                BMonth = bMonth,
                BYear = bYear,
                ADay = aDay,
                AMonth = aMonth,
                AYear = aYear,
                SecAddress = address2,
                SecHome = home,
                SecNotes = notes
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

        public string ReceiveContactSummary(int index)
        {
            index++;
            OpenSummaryDetails(index);
            string content = driver.FindElement(By.Id("content")).Text;
            //Console.WriteLine(content);
            return content.Replace(" ","").Trim();
        }

        internal ContactHelper Modify(ContactData oldData, ContactData newData)
        {
            manager.Navigator.GoToContactPage();
            InitModifyContact(oldData.Id);
            FillFieldsOfContact(newData);
            SubmitContactModification();
            return this;
        }

       

        public ContactHelper Modify(int i,ContactData newData)
        {
            manager.Navigator.GoToContactPage();
            InitModifyContact(i);
            FillFieldsOfContact(newData);
            SubmitContactModification();
            return this;
        }

        internal ContactHelper Remove(ContactData toBeRemoved)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(toBeRemoved.Id);
            RemoveSelectedContact();
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

        private ContactHelper InitModifyContact(string id)
        {        
            driver.FindElement(By.XPath("//*[@href='edit.php?id="+id+"']/*")).Click();
            return this;
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
        private ContactHelper SelectContact(string contactId)
        {
            //driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+"']")).Click();
            driver.FindElement(By.Id(contactId)).Click();
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

      

        public ContactHelper OpenSummaryDetails(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + index + "]")).Click();
            return this;
        }

        
    }
}
