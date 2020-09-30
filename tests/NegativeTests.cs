using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1.tests
{
    [TestFixture]
    public class NegativeTests : BaseTest
    {
        private const string TEXT_OF_QUESTION_ERROR = "can't be blank";
        private const string TEXT_OF_NAME_ERROR = "Name can't be blank";
        private const string TEXT_OF_EMAIL_ERROR = "Email address can't be blank";
        private const string TEXT_OF_NUMBER_ERROR = "Telephone number can't be blank";
        private const string TEXT_OF_CHECKBOXES_ERROR = "must be accepted";

/*        private const string TEXT_OF_QUESTION = "Question?";
        private const string TEXT_OF_NAME = "Boris Britva";
        private const string TEXT_OF_EMAIL = "email@email.com";
        private const string TEXT_OF_AGE = "20";
        private const string TEXT_OF_POSTCODE = "123456";
        private const string TEXT_OF_TELEPHONE_NUMBER = "+123456789";*/

        Dictionary<int, string> InputFields = new Dictionary<int, string>()
        {
            [1] = "Question?",
            [2] = "Name",
            [3] = "email@email.com",
            [4] = "20",
            [5] = "123456",
            [6] = "+123456789",
            [7] = "Turn off age checkbox",
            [8] = "Turn off terms of service checkbox"
        };

        [Test, Priority(0)]
        public void CheckUnenteredQuestionErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields,1);

            Assert.IsTrue(GetQuestionPage().TextOfQuestionErrorIsPresent(TEXT_OF_QUESTION_ERROR));
        }

        [Test, Priority(1)]
        public void CheckUnenteredNameErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields, 2);

            Assert.IsTrue(GetQuestionPage().TextOfNameErrorIsPresent(TEXT_OF_NAME_ERROR));
        }

        [Test, Priority(2)]
        public void CheckUnenteredEmailErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields, 3);

            Assert.IsTrue(GetQuestionPage().TextOfEmailErrorIsPresent(TEXT_OF_EMAIL_ERROR));
        }

        [Test, Priority(3)]
        public void CheckUnenteredTelephoneNumberErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields, 6);

            Assert.IsTrue(GetQuestionPage().TextOfTelephoneNumberErrorIsPresent(TEXT_OF_NUMBER_ERROR));
        }

        [Test, Priority(4)]
        public void CheckAgeCheckboxToggledOffErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields, 7);

            Assert.IsTrue(GetQuestionPage().IsAgeCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }

        [Test, Priority(5)]
        public void CheckTermsCheckboxToggledOffErrorIsPresent()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();
            GetNewsPage().WaitVisibility();

            GetNewsPage().NavigateToQuestionPage();
            GetQuestionPage().FillForm(InputFields, 8);

            Assert.IsTrue(GetQuestionPage().IsTermsCheckboxErrorMessageIsPresent(TEXT_OF_CHECKBOXES_ERROR));
        }
    }
}
