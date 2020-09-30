using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.pages;


/*        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        protected IWebElement EnterNameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        protected IWebElement EnterEmailField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Age']")]
        protected IWebElement EnterAgeField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Postcode']")]
        protected IWebElement EnterPostcodeField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Telephone number']")]
        protected IWebElement EnterTelephoneNumberField { get; set; }*/
namespace UnitTestProject1.pages
{
    public class QuestionPage : BasePage
    {
        public QuestionPage(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.XPath, Using = "//div[@class='text-input']/input")]
        protected IList<IWebElement> EnterFields { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//textarea[@class='text-input--long']")]
        protected IWebElement EnterQuestionField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]")]
        protected IWebElement CheckboxAgeConfirmation { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]")]
        protected IWebElement CheckboxTermsConfirmation { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button']")]
        protected IWebElement ButtonOfSubmit { get; set; }


        ///// error messages////
        [FindsBy(How = How.XPath, Using = "(//textarea[@class='text-input--long--error']/following-sibling::div)[2]")]
        protected IWebElement TextOfQuestionErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']/following-sibling::div")]
        protected IWebElement TextOfNameErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']/following-sibling::div")]
        protected IWebElement TextOfEmailErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Telephone number']/following-sibling::div")]
        protected IWebElement TextOfTelephoneNumberErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox'][1]/div")]
        protected IWebElement TextOfAgeCheckboxErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox'][2]/div")]
        protected IWebElement TextOfTermsCheckboxErrorMessage { get; set; }


        private void ClickOnSubmitButton() { ButtonOfSubmit.Click(); }
        private void ClickOnAgeConfirmationCheckBox() { CheckboxAgeConfirmation.Click(); }
        private void ClickOnTermsOfServiceAcceptanceCheckBox() { CheckboxTermsConfirmation.Click(); }


        public void FillForm(Dictionary<int, string> dictionary, int excludeStringByKey = 0) //exclude string => list<string> и передавать несколько елементов
        {
            int n = 0;

            IList<IWebElement> element = EnterFields;

            if (excludeStringByKey != 1)
            { EnterQuestionField.SendKeys(dictionary[1]); }


            foreach (var keyValue in dictionary)
            {
                if (keyValue.Key == 1 || keyValue.Key == 7 || keyValue.Key == 8) { continue; }

                if (excludeStringByKey != keyValue.Key)
                {
                    element[n].Click();
                    element[n].SendKeys(keyValue.Value);
                    n++;
                }
                else { n++; continue; }
            }

            if (excludeStringByKey != 7) { ClickOnAgeConfirmationCheckBox(); }

            if (excludeStringByKey != 8) { ClickOnTermsOfServiceAcceptanceCheckBox(); }

            ClickOnSubmitButton();
        }


        public bool TextOfQuestionErrorIsPresent(string text_of_error) { return TextOfQuestionErrorMessage.Text.Contains(text_of_error); }
        public bool TextOfNameErrorIsPresent(string text_of_error) { return TextOfNameErrorMessage.Text.Contains(text_of_error); }
        public bool TextOfEmailErrorIsPresent(string text_of_error) { return TextOfEmailErrorMessage.Text.Contains(text_of_error); }
        public bool TextOfTelephoneNumberErrorIsPresent(string text_of_error) { return TextOfTelephoneNumberErrorMessage.Text.Contains(text_of_error); }


        public bool IsAgeCheckboxErrorMessageIsPresent(string text_of_error)
        {
            if (CheckboxAgeConfirmation.Selected)
            {
                throw new Exception("Age Checkbox is toggled on");
            }
            return TextOfAgeCheckboxErrorMessage.Text.Contains(text_of_error);
        }

        public bool IsTermsCheckboxErrorMessageIsPresent(string text_of_error)
        {
            if (CheckboxTermsConfirmation.Selected)
            {
                throw new Exception("Terms Checkbox is toggled on");
            }
            return TextOfTermsCheckboxErrorMessage.Text.Contains(text_of_error);
        }


        // public void InputQuestionField(string question) { EnterQuestionField.Click(); EnterQuestionField.SendKeys(question); }
        /*
                public void InputNameField(string name) { EnterNameField.Click(); EnterNameField.SendKeys(name); }

                public void InputEmailField(string question) { EnterEmailField.Click(); EnterEmailField.SendKeys(question); }

                public void InputAgeField(string age) { EnterAgeField.Click(); EnterAgeField.SendKeys(age); }

                public void InputPostcodeField(string postcode) { EnterPostcodeField.Click(); EnterPostcodeField.SendKeys(postcode); }

                public void InputTelephoneNumberField(string number) { EnterTelephoneNumberField.Click(); EnterTelephoneNumberField.SendKeys(number); }*/
        //
    }
}
