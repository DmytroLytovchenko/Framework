using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalProject.pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//li[@class='orb-nav-newsdotcom']")]
        protected IWebElement NewsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']//button[@class='sign_in-exit']")]
        protected IWebElement LogInAlertButton { get; set; }

        private void ClickOnContinueButton() { LogInAlertButton.Click(); }
        public void NavigateToNews()
        {
            NewsButton.Click();
            ClickOnContinueButton();
        }
    }
}
