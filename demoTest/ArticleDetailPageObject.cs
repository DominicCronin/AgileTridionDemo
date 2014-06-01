using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoTest
{
    class ArticleDetailPageObject
    {
        protected IWebDriver driver;

        public ArticleDetailPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locators
        protected By articleLocator = By.CssSelector("div.article:first-of-type");
        protected By header = By.CssSelector("h2");
       

        public string Header {
            get
            {
                return this.driver.FindElement(articleLocator).FindElement(header).Text;
            }
        }

        public string Article
        {
            get
            {
                return this.driver.FindElement(articleLocator).ToString();
            }
        }

    }
}
