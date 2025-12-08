using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace ReqnrollBrowserStack
{
    [Binding]
    public class SampleLocalTest
    {
        private readonly IWebDriver _driver;

        public SampleLocalTest()
        {
            _driver = new ChromeDriver();
        }

        [Given(@"I navigate to local website")]
        public void GivenINavigatedTowebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:45454/");
        }

        [Then(@"title should contain (.*)")]
        public void ThenIShouldSeeTitle(string localString)
        {
            Thread.Sleep(5000);

            Assert.That(_driver.Title, Does.Contain(localString));
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
