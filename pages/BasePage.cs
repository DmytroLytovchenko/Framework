using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using Framework.Driver.Support;

namespace UnitTestProject1.pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        private readonly long timeout = 10000;

        public BasePage(IWebDriver driver)
        {           
            this.driver = driver;           
            PageFactory.InitElements(driver, this);
        }


        public void WaitVisibility()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public void WaitForPageLoadComplete()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1000)");
        }
    }
}
