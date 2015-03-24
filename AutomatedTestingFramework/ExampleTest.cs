using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.PageObjects;
using System.Threading;

namespace Selenium_Automation.Tests
{
    [TestClass]
    public class GoogleTest : SeleniumDriver
    {
        [TestInitialize]
        public void SetupTest() {
            Console.WriteLine("SetupTest");
            Visit("http://ximpact.us");
        }

        [TestMethod]
        public void GooglePageTitle()
        {
            /*  The first task is to create the HomePage Object.  This
             * allows us to reference the Homepage and all of the defined elements
             * as shown in the examples below
             */
            HomePage homepage = new HomePage(WebDriver);

            /* Here is an example of using the new Elements to validate information
             * within the webpage using the pagefactory
             */
            Assert.AreEqual("ximpact.us", homepage.Title.Text);
            homepage.EnterSearchText("hello world");
            homepage.Search();
            /* The following sleep statement has only been placed in this code to demostrate
             * the button push as there is no validation of the search results in place
             * so its not possible to actually see the result of the button click.
             */
            Thread.Sleep(5000);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Console.WriteLine("Cleanup");
            if (WebDriver != null) WebDriver.Quit();
        }
    }
}
