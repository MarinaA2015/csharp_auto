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
    public class ContactCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            FillFieldsOfContact(new ContactData("Ivan", "Ivanov"));
            SubmitContactCreation();
            Logout();
        }

        private void FillFieldsOfContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);          
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            /*driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys("mm");
            driver.FindElement(By.Name("photo")).Clear();
            driver.FindElement(By.Name("photo")).SendKeys("C:\\xampp\\htdocs\\addressbook\\header.jpg");
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("t");
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("c");
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys("a");
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys("h");
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys("m");
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys("w");
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("f");
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("email1");
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys("email2");
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys("email3");
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
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData user)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(user.UserName);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
