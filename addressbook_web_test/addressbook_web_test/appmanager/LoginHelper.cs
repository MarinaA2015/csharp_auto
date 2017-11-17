using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {  
        }
        
        public LoginHelper Login(AccountData user)
        {
            Type(By.Name("user"), user.UserName);
            Type(By.Name("pass"), user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public LoginHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
