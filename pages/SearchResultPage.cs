using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalProject.pages
{
    public class SearchResultPage:BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//p//a//span[contains(text(),'')]")]
        protected IWebElement SearchResults { get; set; }

        public string FirstSearchResultText() { return SearchResults.Text; }
    }
}
