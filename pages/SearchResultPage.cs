using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1.pages
{
    public class SearchResultPage:BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }
        //p//a//span[contains(text(),'')]
        //(//li/div[@class='css-1uxmp1f-Promo ett16tt11']//text())[1]
        //span[contains(text(),'#HoodDocumentary: Family Business')]

        [FindsBy(How = How.XPath, Using = "//p//a//span[contains(text(),'')]")]
        protected IWebElement SearchResults { get; set; }

        public string FirstSearchResultText() { return SearchResults.Text; }

    }
}
