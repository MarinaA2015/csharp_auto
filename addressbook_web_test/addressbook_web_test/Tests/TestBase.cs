using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            /*FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";*/
            /* driver = new FirefoxDriver(options);
             baseURL = "http://localhost/";
             verificationErrors = new StringBuilder();*/
            app = new ApplicationManager();


        }

        [TearDown]
        public void TeardownTest()
        {

            app.Stop();
        }
    }
}
