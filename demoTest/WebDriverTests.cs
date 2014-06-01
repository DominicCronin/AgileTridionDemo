using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace demoTest
{
    /// <summary>
    /// Summary description for WebDriverTests
    /// </summary>
    [TestClass]
    public class WebDriverTests
    {
        protected static IWebDriver driver;

        public WebDriverTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void TestHeaderText()
        {
            string subject = "http://www.visitorsweb.local/test/ArticleDetailTest.aspx";
            driver.Navigate().GoToUrl(subject);
            var articleObject = new ArticleDetailPageObject(driver);
            Assert.AreEqual<string>(@"header [<>""&'ŦĐŜ]", articleObject.Header);
        }

        [TestMethod]
        public void TestNoTCDLinOutput()
        {
            string subject = "http://www.visitorsweb.local/test/ArticleDetailTest.aspx";
            driver.Navigate().GoToUrl(subject);
            Assert.IsFalse(driver.PageSource.Contains("tcdl:"), "A tcdl tag was found in the page: {0}.", subject);
        }
    }
}
