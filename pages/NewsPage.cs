using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTestProject1.pages;

namespace UnitTestProject1.pages
{
    public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']")]
        protected IWebElement logInAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[@class='gs-c-promo-heading__title gel-paragon-bold nw-o-link-split__text']")]
        protected IWebElement TextOfHeadlineArticle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@data-entityid,'container-top-stories')]//h3)[position()>2]")]// (//div[contains(@data-entityid,'container-top-stories')]//h3)[position()>2] 
        protected IList<IWebElement> SecondaryArticleTitlesList { get; set; }//div[contains(@data-entityid,'container-top-stories')]

        [FindsBy(How = How.XPath, Using = "//a[@class='gs-c-section-link gs-c-section-link--truncate nw-c-section-link nw-o-link nw-o-link--no-visited-state']")]
        protected IWebElement TextOfNewsCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        protected IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/news/coronavirus']")]
        protected IWebElement ButtonOfCoronavirusTap { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Your Coronavirus Stories']")]
        protected IWebElement ButtonOfYourCoronavirusStoriesTap { get; set; }        

        [FindsBy(How = How.XPath, Using = "(//div[@class='gel-layout__item gel-1/3@m gel-1/4@l gel-1/5@xxl nw-o-keyline nw-o-no-keyline@m'])[2]")]//"//h3[text() = 'Coronavirus: Send us your questions']")] (//div[@class='gel-layout__item gel-1/3@m gel-1/4@l gel-1/5@xxl nw-o-keyline nw-o-no-keyline@m'])[2]
        protected IWebElement ButtunOfQuetions { get; set; }



        private string GetTextOfNewsCategory() { return TextOfNewsCategory.Text; }

        public string TextOfHeadLineNews() { return TextOfHeadlineArticle.Text; }

        public IList<IWebElement> GetListOfNews() { return SecondaryArticleTitlesList.ToList(); }

        public void InputTextOfCategory()
        {
            SearchInput.Click();
            SearchInput.SendKeys(GetTextOfNewsCategory());
            SearchInput.SendKeys(Keys.Enter);
        }

        public void NavigateToQuestionPage()
        {
            ButtonOfCoronavirusTap.Click();
            ButtonOfYourCoronavirusStoriesTap.Click();
            ButtunOfQuetions.Click();
        }

        public bool IsSecondaryNewsTextCorrect(List<string> list_of_secondary_news)
        {
            Exception e = new ArgumentException("не совпадают");

            int n = 0;
            IList<IWebElement> web_element = SecondaryArticleTitlesList.ToList();

            foreach (var element in list_of_secondary_news)
            {
                if (web_element[n].Displayed)
                {
                    if (element != web_element[n].ToString())
                    {
                    throw new ArgumentException($"{element} не совпадают {web_element}");
                    }
                }
                n++;
            }
            return true;
        }

    }
}
