using System.IO;
using DemoqaRegister.Pages.NavigateToDemoqa;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//this test navigate to demoqa.com and verify that registration page is open
namespace DemoqaRegister
{
    [TestFixture]
    public class DemoqaNavigateTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }

        [TearDown]
        public void EndTest()
        {
            //take a screenshot in case of test failure
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenshotLocation = Path.GetFullPath(@"..\..\..\Screenshots\");
                string testName = TestContext.CurrentContext.Test.Name;
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotLocation + testName + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
        }

        [Test]
        public void NavigateToDemoqa()
        {
            var navigateToDemoqa = new NavigateToDemoqa(driver);

            navigateToDemoqa.NavigateTo();
            navigateToDemoqa.RegistrationPageClick();

            navigateToDemoqa.EntryTitle.Text.Contains("Registration").Should().BeTrue();
        }
    }
}