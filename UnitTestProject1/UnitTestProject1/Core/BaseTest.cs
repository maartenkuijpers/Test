using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace UnitTestProject1.Core
{
    public class BaseTest
    {
        static public string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


        protected IWebDriver CurrentDriver { get; set; }

        [SetUp]
        public void TestSetup()
        {
            var webDriversPath = Path.Combine(AssemblyDirectory, ConfigurationManager.AppSettings["WebDriversPath"]);

            switch (ConfigurationManager.AppSettings["SpecFlowDriver"])
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--test-type");
                    CurrentDriver = new ChromeDriver(webDriversPath, chromeOptions);
                    break;
                case "Firefox":
                    CurrentDriver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile());
                    break;
                case "InternetExplorer":
                    var ieOptions = new InternetExplorerOptions {IntroduceInstabilityByIgnoringProtectedModeSettings = true};
                    CurrentDriver = new InternetExplorerDriver(webDriversPath, ieOptions);
                    break;
                case "Safari":
                    CurrentDriver = new SafariDriver(new SafariOptions());
                    break;
                default:
                    CurrentDriver = new PhantomJSDriver(); // Headless browser
                    break;
            }

            CurrentDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
        }

        [TearDown]
        public void TestTeardown()
        {
            CurrentDriver.Quit();
        }
    }
}
