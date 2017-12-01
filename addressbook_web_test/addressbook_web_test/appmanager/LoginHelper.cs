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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user))
                {
                    return this;

                }
                Logout();
                Login(user);

            }
            Type(By.Name("user"), user.UserName);
            Type(By.Name("pass"), user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public bool IsLoggedIn(AccountData user)
        {
            /* return IsLoggedIn() &&
                 driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                     == "(" + user.UserName + ")";*/
            return IsLoggedIn() && user.UserName.Equals(GetLoginUserName());
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public string GetLoginUserName()
        {
           string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2); 
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            
            return this;
        }
    }
}
