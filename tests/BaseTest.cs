using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnitTestProject1.pages;
using UnitTestProject1.waiters;



namespace UnitTestProject1.tests
{

    public class BaseTest 
    {
        public  IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.bbc.com";
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
            
        }

        public NewsPage GetNewsPage()
        {
            return new NewsPage(GetDriver());
        }

        public SearchResultPage GetSearchResultPage()
        {
            return new SearchResultPage(GetDriver());
        }

        public QuestionPage GetQuestionPage()
        {
            return new QuestionPage(GetDriver());
        }

        [TearDown]
        public virtual void Close()
        {
            driver.Quit();
        }
    }
}
