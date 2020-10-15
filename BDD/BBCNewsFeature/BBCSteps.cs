using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FinalProject.specflow.Steps;
using OpenQA.Selenium.Chrome;

namespace FinalProject.specflow.BBC_NEWS_STEP
{
    [Binding]
    public class BBCSteps :  BaseSteps
    {
        private const string TEXT_OF_HEADLINE_NEWS = "Trump criticised over car ride with Covid-19";

        private const string TITLE_OF_THE_FIRTS_ELEMENT = "US election 2020: Who really decides the outcome?";

        List<string> LIST_OF_SECONDARY_NEWS_TEXT = new List<string>()
        {
            "Thailand passes emergency decree in protest crackdown",
            "Trump's son Barron had Covid-19, says first lady",
            "Long Covid 'could be four different syndromes'",
            "'I don't feel like dying today': Hiker meets cougar",
            "Idris Elba: We can all help solve climate change",
            "EU leaders weigh up hard choices over Brexit trade deal",
            "Nigerian army warning amid brutality protests",
            "US Supreme Court pick grilled on presidential powers",
            "'Game-changer' drug to tackle addiction",
            "A hit share market debut for BTS's music label",
            "Australian police drop case against ABC journalist",
            "Breonna Taylor's boyfriend recalls night she was killed",
            "Glitter litter 'could be damaging rivers'"
        };

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        [Given(@"i navigate to BBC")]
        public void GivenIWaitHomePageLoading()
        {
            NavigateToBBC();
            GetHomePage().ImplicitWait();
        }

        [When(@"i navigate to news page")]
        public void WhenINavigateToNewsPage()
        {
            GetHomePage().NavigateToNews();
        }

        [When(@"input text of main news category on search field")]
        public void WhenInputTextOfMainNewsCategoryOnSearchField()
        {
            GetNewsPage().InputTextOfCategory();
        }

        [When(@"click search button")]
        public void WhenClickSearchButton()
        {
            GetNewsPage().ClickOnSearchInputButton();
        }

        [Then(@"the text of main news is correct")]
        public void ThenTheTextOfMainNewsIsCorrect()
        {
            Assert.AreEqual(TEXT_OF_HEADLINE_NEWS, GetNewsPage().TextOfHeadLineNews());
        }

        [Then(@"the text of secondary news is correct")]
        public void ThenTheTextOfSecondaryNewsIsCorrect()
        {
            Assert.IsTrue(GetNewsPage().IsSecondaryNewsTextCorrect(LIST_OF_SECONDARY_NEWS_TEXT));
        }

        [Then(@"first search result text is correct")]
        public void ThenFirstSearchResultTextIsCorrect()
        {
            Assert.AreEqual(TITLE_OF_THE_FIRTS_ELEMENT, GetSearchResultPage().FirstSearchResultText());
        }
    }
}
