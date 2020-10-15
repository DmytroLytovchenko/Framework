using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.pages
{
    public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//h3[@class='gs-c-promo-heading__title gel-paragon-bold nw-o-link-split__text']")]
        protected IWebElement TextOfMainArticleTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@data-entityid,'container-top-stories')]//h3)[position()>2]")]
        protected IList<IWebElement> ListOfSecondaryArticleTitles { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='nw-c-promo-meta']/a/span")]
        protected IWebElement TextOfNewsCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        protected IWebElement SearchInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/news/coronavirus']")]
        protected IWebElement ButtonOfCoronavirusTap { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Your Coronavirus Stories']")]
        protected IWebElement ButtonOfYourCoronavirusStoriesTap { get; set; }        

        [FindsBy(How = How.XPath, Using = "(//div[@class='gel-layout__item gel-1/3@m gel-1/4@l gel-1/5@xxl nw-o-keyline nw-o-no-keyline@m'])[2]")]
        protected IWebElement SendQuestionTap { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        protected IWebElement ButtonOfSearch { get; set; }


        private string GetTextOfNewsCategory() { return TextOfNewsCategory.Text; }

        public string TextOfHeadLineNews() { return TextOfMainArticleTitle.Text; }

        public void ClickOnSearchInputButton() { ButtonOfSearch.Click(); }

        public void InputTextOfCategory()
        {
            SearchInputField.Click();
            SearchInputField.SendKeys(GetTextOfNewsCategory());
        }

        public void NavigateToQuestionPage()
        {
            ButtonOfCoronavirusTap.Click();
            ButtonOfYourCoronavirusStoriesTap.Click();
            SendQuestionTap.Click();
        }

        public bool IsSecondaryNewsTextCorrect(List<string> list_of_secondary_news)
        {
            List<string> num_of_incorrect = new List<string>();
            IList<IWebElement> web_element_list = ListOfSecondaryArticleTitles.ToList();

            foreach (var web_element in web_element_list)
            {
                if (web_element.Displayed)
                {
                    if (!list_of_secondary_news.Contains(web_element.Text))
                    {
                        num_of_incorrect.Add(web_element.Text);
                    }
                }
            }
            if (num_of_incorrect.Count > 0)
            {
                Console.WriteLine("Incorrect news:");
                foreach (var t in num_of_incorrect)
                {                   
                    Console.WriteLine(t);
                }
                return false;
            }
            return true;
        }
    }
}
