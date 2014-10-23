using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;

namespace Google.UI.NUnit
{

    [TestFixture]
    public class Test
    {
        private IWebDriver _driver;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        [Test]
        public void TestSimpleGoogleWebSearch()
        {
            _driver.Navigate().GoToUrl(
              "http://www.google.com"
            );

            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("Step.1 - Start Page.jpg", ImageFormat.Jpeg);

            _driver.FindElement(By.Name("q")).SendKeys("1 + 1");
            _driver.FindElement(By.Id("gbqfb")).Submit();


            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("Step.2 - Results Page.jpg", ImageFormat.Jpeg);

            Assert.That(_driver.Title.Contains("1 + 1 - Google Search"));
        }
    }
}