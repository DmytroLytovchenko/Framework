using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using UnitTestProject1.pages;

namespace UnitTestProject1.specflow.Steps
{
   public class BaseSteps
    {
        public IWebDriver driver;

        [BeforeScenario]
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
        }

        public IWebDriver GetDriver() { return driver; }
        public HomePage GetHomePage() { return new HomePage(GetDriver()); }
        public NewsPage GetNewsPage() { return new NewsPage(GetDriver()); }
        public SearchResultPage GetSearchResultPage() { return new SearchResultPage(GetDriver()); }
        public QuestionPage GetQuestionPage() { return new QuestionPage(GetDriver()); }
    }
}
