using System;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.PageObjects
{
    /* The PageObjectBase class.  This class is to represent anything that applies to all pages
     * of the site to be tested.  The example here shows that you can pass in by default a
     * Title from the driver to ensure that the correct page is loaded, but the intention 
     * of this is to provide a base class so that codereplication is kept to a minimum
     */
    class TestBase
    {
        private IWebDriver Driver { get; set; }

        public TestBase(IWebDriver driver, String titleOfPage)
        {
            Driver = driver;
            if (driver.Title != titleOfPage)
                throw new NoSuchWindowException("PageObjectBase: The Page Title doesnt match.");

        }
    }
}
