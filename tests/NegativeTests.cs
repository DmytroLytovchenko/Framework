using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace FinalProject.tests
{
    [TestFixture]
    public class NegativeTests : BaseTest
    {
        private const string TEXT_OF_QUESTION_ERROR = "can't be blank";
        private const string TEXT_OF_NAME_ERROR = "Name can't be blank";
        private const string TEXT_OF_EMAIL_ERROR = "Email address can't be blank";
        private const string TEXT_OF_NUMBER_ERROR = "Telephone number can't be blank";
        private const string TEXT_OF_CHECKBOXES_ERROR = "must be accepted";

        readonly Dictionary<int, string> InputData = new Dictionary<int, string>()
        {
            [1] = "Question?",
            [2] = "Name",
            [3] = "email@email.com",
            [4] = "+123456789",
            [5] = "Turn off age checkbox",
            [6] = "Turn off terms of service checkbox"
        };

        [Test, Priority(0)]
        public void CheckUnenteredQuestionErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeQuestion:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().TextOfQuestionErrorIsPresent(TEXT_OF_QUESTION_ERROR));
        }

        [Test, Priority(1)]
        public void CheckUnenteredNameErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeName:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().TextOfNameErrorIsPresent(TEXT_OF_NAME_ERROR));
        }

        [Test, Priority(2)]
        public void CheckUnenteredEmailErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeEmail:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().TextOfEmailErrorIsPresent(TEXT_OF_EMAIL_ERROR));
        }

        [Test, Priority(3)]
        public void CheckUnenteredTelephoneNumberErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeTelephone:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().TextOfTelephoneNumberErrorIsPresent(TEXT_OF_NUMBER_ERROR));
        }

        [Test, Priority(4)]
        public void CheckAgeCheckboxToggledOffErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeAgeCheckbox:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().IsAgeCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }

        [Test, Priority(5)]
        public void CheckTermsCheckboxToggledOffErrorIsPresent()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().ImplicitWait();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputData, excludeTermsCheckbox:true);
            GetQuestionPage().ClickOnSubmitButton();

            Assert.IsTrue(GetQuestionPage().IsTermsCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }
    }
}
