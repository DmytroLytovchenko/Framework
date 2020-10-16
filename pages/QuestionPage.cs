using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalProject.pages
{
    public class QuestionPage : BasePage
    {
        public QuestionPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//textarea[@class='text-input--long']")]
        protected IWebElement EnterQuestionField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        protected IWebElement EnterNameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        protected IWebElement EnterEmailField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Telephone number']")]
        protected IWebElement EnterTelephoneNumberField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]")]
        protected IWebElement CheckboxAgeConfirmation { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]")]
        protected IWebElement CheckboxTermsConfirmation { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button']")]
        protected IWebElement ButtonOfSubmit { get; set; }


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


        private void ClickOnAgeConfirmationCheckBox() { CheckboxAgeConfirmation.Click(); }
        private void ClickOnTermsOfServiceAcceptanceCheckBox() { CheckboxTermsConfirmation.Click(); }
        public void ClickOnSubmitButton() { ButtonOfSubmit.Click(); }

        public void FillForm(Dictionary<int, string> dictionary,  bool excludeQuestion = false, bool excludeName = false, bool excludeEmail = false, bool excludeTelephone = false, bool excludeAgeCheckbox = false, bool excludeTermsCheckbox = false) 
        {
            if (excludeQuestion != true){ EnterQuestionField.SendKeys(dictionary[1]); }

            if (excludeName != true) { EnterNameField.SendKeys(dictionary[2]); }

            if (excludeEmail != true) { EnterEmailField.SendKeys(dictionary[3]); }

            if (excludeTelephone != true) { EnterTelephoneNumberField.SendKeys(dictionary[4]); }

            if (excludeAgeCheckbox != true) { ClickOnAgeConfirmationCheckBox(); }

            if (excludeTermsCheckbox != true) { ClickOnTermsOfServiceAcceptanceCheckBox(); }
        }

        public bool TextOfQuestionErrorIsPresent(string text_of_error) 
        {
            return TextOfQuestionErrorMessage.Text.Contains(text_of_error); 
        }
        public bool TextOfNameErrorIsPresent(string text_of_error) 
        { 
            return TextOfNameErrorMessage.Text.Contains(text_of_error); 
        }
        public bool TextOfEmailErrorIsPresent(string text_of_error)
        { 
            return TextOfEmailErrorMessage.Text.Contains(text_of_error);
        }
        public bool TextOfTelephoneNumberErrorIsPresent(string text_of_error) 
        { 
            return TextOfTelephoneNumberErrorMessage.Text.Contains(text_of_error); 
        }

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
    }
}

