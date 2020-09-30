using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.pages;

namespace UnitTestProject1.pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//li[@class='orb-nav-newsdotcom']")]
        protected IWebElement NewsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']//button[@class='sign_in-exit']")]
        protected IWebElement ClickOnLogInAlertButton { get; set; }

        public void NavigateToNews()
        {
            NewsButton.Click();
            ClickOnLogInAlertButton.Click();
        }
    }
}
