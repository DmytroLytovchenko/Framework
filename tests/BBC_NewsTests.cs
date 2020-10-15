using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace FinalProject.tests
{
    [TestFixture]
    public class BBC_NewsTests : BaseTest
    {
        private const string TEXT_OF_HEADLINE_NEWS = "Trump says Supreme Court nominee will be a woman";
        private const string TITLE_OF_THE_FIRTS_ELEMENT = "#HoodDocumentary: Family Business";

        List<string> LIST_OF_SECONDARY_NEWS = new List<string>()
        {
            "Who really decides the US election?",
            "Hepatitis C discovery wins the Nobel Prize",
            "Lana Del Rey criticised for wearing mesh mask",
            "How do pandemics normally end?",
            "Paris to shut bars and increase virus alert",
            "US Supreme Court pick grilled on presidential powers",
            "'World's best airport' warns of prolonged crisis",
            "Spike Lee leads tributes to murdered actor",
            "Tasmanian Devils reintroduced into Australian wild",
            "McDonald's among firms urging tougher forest rules",
            "Charity pledges $250m to 'reimagine' US monuments",
            "Nagorno-Karabakh conflict grows as big cities hit"
        };

        [Test, Priority(3)]
        public void GetTextOfMainNews()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();

            Assert.AreEqual(TEXT_OF_HEADLINE_NEWS, GetNewsPage().TextOfHeadLineNews());
        }

        [Test, Priority(3)]
        public void ChecksSecondaryArticleTitles()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();

            Assert.IsTrue(GetNewsPage().IsSecondaryNewsTextCorrect(LIST_OF_SECONDARY_NEWS));
        }

        [Test, Priority(3)]
        public void CheckSearchResultContainsText()
        {
            GetHomePage().ImplicitWait();

            GetHomePage().NavigateToNews();
            GetNewsPage().InputTextOfCategory();
            GetNewsPage().ClickOnSearchInputButton();

            Assert.AreEqual(TITLE_OF_THE_FIRTS_ELEMENT, GetSearchResultPage().FirstSearchResultText());
        }
    }
}
