using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FinalProject.pages;

namespace FinalProject.specflow.Steps
{
    [Binding]
    public class BaseSteps
    {
        protected IWebDriver driver;

        private string BBC_URL = "https://www.bbc.com";
/*        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.bbc.com";
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }*/
        public void NavigateToBBC()
        {
            driver.Url = BBC_URL;
        }
        public IWebDriver GetDriver() { return driver; }
        public HomePage GetHomePage() { return new HomePage(GetDriver()); }
        public NewsPage GetNewsPage() { return new NewsPage(GetDriver()); }
        public SearchResultPage GetSearchResultPage() { return new SearchResultPage(GetDriver()); }
        public QuestionPage GetQuestionPage() { return new QuestionPage(GetDriver()); }
    }
}
