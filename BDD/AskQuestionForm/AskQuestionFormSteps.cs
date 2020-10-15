using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FinalProject.specflow.Steps;
using OpenQA.Selenium.Chrome;

namespace FinalProject.specflow.CoronavirusForm
{
    [Binding]
    public class AskQuestionFormSteps : BaseSteps
    {
        private const string TEXT_OF_QUESTION_ERROR = "can't be blank";
        private const string TEXT_OF_NAME_ERROR = "Name can't be blank";
        private const string TEXT_OF_EMAIL_ERROR = "Email address can't be blank";
        private const string TEXT_OF_NUMBER_ERROR = "Telephone number can't be blank";
        private const string TEXT_OF_CHECKBOXES_ERROR = "must be accepted";

        Dictionary<int, string> InputData = new Dictionary<int, string>()
        {
            [1] = "Question?",
            [2] = "Name",
            [3] = "email@email.com",
            [4] = "+123456789",
            [5] = "Turn off age checkbox",
            [6] = "Turn off terms of service checkbox"
        };

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

        [Given(@"i navigate to BBC home page")]
        public void GivenIWaitHomePageLoadComplete()
        {
            NavigateToBBC();
            GetHomePage().ImplicitWait();
        }

        [Given(@"i go to News page")]
        public void GivenIGoToNewsPage()
        {
            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();
        }

        [Given(@"i go to Question page")]
        public void GivenIGoToQuestionPage()
        {
            GetNewsPage().NavigateToQuestionPage();
        }

        [When(@"i fill form without Question")]
        public void WhenIFillFormWithoutQuestion()
        {
            GetQuestionPage().FillForm(InputData, excludeQuestion: true);
        }

        [When(@"click Submit button")]
        public void WhenClickSubmitButton()
        {
            GetQuestionPage().ClickOnSubmitButton();
        }

        [When(@"i fill form without Name")]
        public void WhenIFillFormWithoutName()
        {
            GetQuestionPage().FillForm(InputData, excludeName: true);
        }

        [When(@"i fill form without Email")]
        public void WhenIFillFormWithoutEmail()
        {
            GetQuestionPage().FillForm(InputData, excludeEmail: true);
        }

        [When(@"i fill form without Telephone Number")]
        public void WhenIFillFormWithoutTelephoneNumber()
        {
            GetQuestionPage().FillForm(InputData, excludeTelephone: true);
        }

        [When(@"i fill form without Age Checkbox")]
        public void WhenIFillFormWithoutAgeCheckbox()
        {
            GetQuestionPage().FillForm(InputData, excludeAgeCheckbox: true);
        }

        [When(@"i fill form without Terms Checkbox")]
        public void WhenIFillFormWithoutTermsCheckbox()
        {
            GetQuestionPage().FillForm(InputData, excludeTermsCheckbox: true);
        }

        [Then(@"error text of question is correct")]
        public void ThenErrorTextOfQuestionIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().TextOfQuestionErrorIsPresent(TEXT_OF_QUESTION_ERROR));
        }

        [Then(@"error text of name is correct")]
        public void ThenErrorTextOfNameIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().TextOfNameErrorIsPresent(TEXT_OF_NAME_ERROR));
        }

        [Then(@"error text of email is correct")]
        public void ThenErrorTextOfEmailIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().TextOfEmailErrorIsPresent(TEXT_OF_EMAIL_ERROR));
        }

        [Then(@"error text of telephone number is correct")]
        public void ThenErrorTextOfTelephoneNumberIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().TextOfTelephoneNumberErrorIsPresent(TEXT_OF_NUMBER_ERROR));
        }

        [Then(@"error text of toggle off age checkbox is correct")]
        public void ThenErrorTextOfToggleOffAgeCheckboxIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().IsAgeCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }

        [Then(@"error text of toggle off terms checkbox is correct")]
        public void ThenErrorTextOfToggleOffTermsCheckboxIsCorrect()
        {
            Assert.IsTrue(GetQuestionPage().IsTermsCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }
    }
}
