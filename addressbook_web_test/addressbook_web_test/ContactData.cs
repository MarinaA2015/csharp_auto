using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string photo = "";
        private string company = "";
        private string title = "";
        private string address = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";

        /*
          driver.FindElement(By.Name("homepage")).Clear();
          driver.FindElement(By.Name("homepage")).SendKeys("homepage");
          new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
          new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("May");
          driver.FindElement(By.Name("byear")).Clear();
          driver.FindElement(By.Name("byear")).SendKeys("2000");
          new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("7");
          new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("September");
          driver.FindElement(By.Name("ayear")).Clear();
          driver.FindElement(By.Name("ayear")).SendKeys("2010");
          driver.FindElement(By.Name("address2")).Clear();
          driver.FindElement(By.Name("address2")).SendKeys("address secondary");
          driver.FindElement(By.Name("phone2")).Clear();
          driver.FindElement(By.Name("phone2")).SendKeys("home");
          driver.FindElement(By.Name("notes")).Clear();
          driver.FindElement(By.Name("notes")).SendKeys("notes");*/


        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
    }
}
