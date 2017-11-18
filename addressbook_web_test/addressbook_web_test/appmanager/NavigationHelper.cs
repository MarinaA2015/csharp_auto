using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToGroupPage()
        {
            if (!(driver.Url == baseURL + "addressbook/group.php" &&
                IsElementPresent(By.Name("New"))))
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
            return this;
        }
        
        public NavigationHelper OpenHomePage()
        {

            if (driver.Url != baseURL + "addressbook/" )
            {
                // driver.FindElement(By.XPath("//*[@id='nav']/ul/li[1]/a")).Click();
                driver.Navigate().GoToUrl(baseURL + "addressbook/");
            }
            return this;
        }

        public NavigationHelper GoToContactPage()
        {

            if (driver.Url != baseURL + "addressbook/" && IsElementPresent(By.LinkText("home")))
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
                return this;
        }
        
    }
}
