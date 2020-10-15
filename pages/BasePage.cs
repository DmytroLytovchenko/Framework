using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.pages
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

        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public void WaitForPageLoadComplete()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
