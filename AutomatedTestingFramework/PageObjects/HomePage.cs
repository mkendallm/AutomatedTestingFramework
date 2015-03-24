using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedTestingFramework.PageObjects
{
    class HomePage : TestBase
    {

        private IWebDriver Driver { get; set; }

        /*These are the elements that you wish to reference on the page.  The first part
         * is to identify how to actually find the element, including the search
         * reference so I have given Name and XPath examples and the second part is 
         * the object reference that you wish to assign.  I have given public and private 
         * references so that you can see how each are used
         */

        [FindsBy(How = How.XPath, Using = "/html/head/title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchDialog { get; set; }

        [FindsBy(How = How.Name, Using = "btnG")]
        private IWebElement SearchButton { get; set; }

        public HomePage(IWebDriver driver)
            /*This is to reference the PageObjectBase Class.  Passing in the Title of the 
             * page that is expected for the HomePage to ensure the correct Page is loaded
             * before starting any tests.
             */
            : base(driver, "ximpact.us")
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /* Here are two example methods of using the newly generated objects with friendlier
         *  names so that it clearly identifies the task being completed
         * Note that there is no validation on these, so if they are to fail there will 
         * be no friendly output provided other than the failure.
         */
        public void EnterSearchText(String text)
        {
            SearchDialog.SendKeys(text);
        }
        public void Search()
        {
            SearchButton.Click();
        }
    }
}
