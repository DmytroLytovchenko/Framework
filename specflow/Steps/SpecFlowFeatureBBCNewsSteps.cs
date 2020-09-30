using System;
using TechTalk.SpecFlow;
using UnitTestProject1.specflow.Steps;

namespace UnitTestProject1.specflow.BBC_NEWS_STEP
{
    [Binding]
    public class SpecFlowFeatureBBCNewsSteps : BaseSteps
    {
        [Given(@"user on home page")]
        public void GivenUserOnHomePage()
        {
            GetHomePage().WaitVisibility();
        }
        
        [When(@"user navigate to news page")]
        public void WhenUserNavigateToNewsPage()
        {
            GetHomePage().NavigateToNews();
        }
        
        [When(@"input text of main news category on search field")]
        public void WhenInputTextOfMainNewsCategoryOnSearchField()
        {
            GetNewsPage().InputTextOfCategory();
        }

        [Then(@"the text of main news is correct")]
        public void ThenTheTextOfMainNewsIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the text of second news is correct")]
        public void ThenTheTextOfSecondNewsIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the text of result is correct")]
        public void ThenTheTextOfResultIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
