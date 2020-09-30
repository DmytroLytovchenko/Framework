
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;
using UnitTestProject1.pages;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace UnitTestProject1.tests
{
    [TestFixture]
    public class BBC_NewsTests : BaseTest
    {
        private const string TEXT_OF_HEADLINE_NEWS = "Trump says Supreme Court nominee will be a woman";

        private const string TITLE_OF_THE_FIRTS_ELEMENT = "#HoodDocumentary: Family Business";


        List<string> list_of_secondary_news_text = new List<string>()
        {
            "Who will be the next US president? You decide",
            "Armenia and Azerbaijan battle over disputed region",
            "'Forced to work' as medics fighting coronavirus",
                        "Attenborough spent lockdown 'listening to birds'",
            "TikTok: US judge halts app store ban",
                        "NFL legend Joe Montana thwarts kidnapping attempt",

            "Australian theme park fined A$3.6m over ride deaths",
            "PM promises to protect 30% of UK's land by 2030",
            "Britons face up to £10,000 fine for not self-isolating",
            "Gove heads to Brussels as EU trade talks resume",
            "Trump says new court ruling on abortion 'possible'",
            "Tear gas and arrests in Belarus protest crackdown"
            //"At least 90 whales dead in stranding off Australia"
        };


        [Test]
        public void GetTextOfMainNews()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();

            Assert.AreEqual(TEXT_OF_HEADLINE_NEWS, GetNewsPage().TextOfHeadLineNews());
        }

        [Test]
        public void ChecksSecondaryArticleTitles()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();

            Assert.IsTrue(GetNewsPage().IsSecondaryNewsTextCorrect(list_of_secondary_news_text));
        }

        [Test]
        public void CheckSearchResultContainsText()
        {
            GetHomePage().WaitVisibility();

            GetHomePage().NavigateToNews();

            GetNewsPage().InputTextOfCategory();

            Assert.AreEqual(TITLE_OF_THE_FIRTS_ELEMENT, GetSearchResultPage().FirstSearchResultText());
        }
    }
}
