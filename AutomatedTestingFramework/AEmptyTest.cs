using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTestingFramework.Selenium;

namespace AutomatedTestingFramework
{
    [TestClass]
    public class AEmptyTest : SeleniumDriver
    {
        [TestInitialize]
        public void SetupTest() { Console.WriteLine("SetupTest"); }

        [TestMethod]
        public void ExampleTestMethod1() { Console.WriteLine("ExampleTestMethod1"); }

        [TestMethod]
        public void ExampleTestMethod2() { Console.WriteLine("ExampleTestMethod2"); }

        [TestCleanup()]
        public void Cleanup() {
            Console.WriteLine("Cleanup");
            if (WebDriver != null) WebDriver.Quit();
        }
        
    }
}
