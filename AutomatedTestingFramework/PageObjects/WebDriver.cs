using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace AutomatedTestingFramework.Selenium
{
    public class SeleniumDriver
    {
        private static IWebDriver _driver;
        protected static IWebDriver WebDriver
        {
            get
            {
                if (_driver == null)
                {
                    string driverConfig = ConfigurationManager.AppSettings["browser"];
                    if (!String.IsNullOrEmpty(driverConfig))
                    {
                        switch (ConfigurationManager.AppSettings["browser"])
                        {
                            case "Chrome":
                                _driver = new ChromeDriver();
                                ConfigureDriver();
                                break;
                            case "Firefox":
                                _driver = new FirefoxDriver();
                                ConfigureDriver();
                                break;
                            case "IE":
                                _driver = new InternetExplorerDriver();
                                ConfigureDriver();
                                break;
                            default:
                                Console.WriteLine("App.config key error.");
                                Console.WriteLine("Defaulting to Firefox");
                                _driver = new FirefoxDriver();
                                ConfigureDriver();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("* * * * DEFAULTMODE * * * *");
                        Console.WriteLine("App.config key not present.");
                        _driver = new FirefoxDriver();
                        ConfigureDriver();
                    }
                }
                return _driver;
            }
        }
        internal static void ConfigureDriver()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Manage().Window.Maximize();
        }
        public static void Visit(String url)
        {
            var rootUrl = new Uri(url);
            WebDriver.Navigate().GoToUrl(rootUrl);
        }
    }
}
