using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DemoqaRegister.Pages.NavigateToDemoqa;
using DemoqaRegister.Pages.RegistrationPage;
using DemoqaRegister.UserRegData;
using FluentAssertions;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoqaRegister
{
    [TestFixture]
    public class DemoqaRegisterTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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

        //this test navigates to demoqa.com and verify that registration page is open
        [Test]
        public void NavigateToDemoqa()
        {
            var navigateToDemoqa = new NavigateToDemoqa(driver);

            navigateToDemoqa.NavigateTo();
            navigateToDemoqa.RegistrationPageClick();

            navigateToDemoqa.EntryTitle.Text.Contains("Registration").Should().BeTrue();
        }

        //create one valid registration test to check is form working correctly
        [Test]
        public void DemoqaValidRegistration()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "QaUser46254181",
                "spareemail02181@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.SuccessRegisterMessage.Text.Should().Be("Thank you for your registration");
        }

        //create negative registration tests to check form's behavior
        [Test]
        public void DemoqaRegisterWithoutNames()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "",
                "",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoNames.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithoutLastName()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoNames.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithNoHobbySelected()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { false, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoHobbySelected.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithNoValidPhone()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111g",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoValidPhone.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterOnlyLettersInPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "wwwwwwwwwwwwwww",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoValidPhone.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithoutUserName()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoUserName.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithoutUserNameAndEmail()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "",
                "",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoUserName.Displayed.Should().BeTrue();
            regPage.NoValidEmail.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterWithNoValidEmail()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.b@g",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "12345678",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoValidEmail.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterNoMatchingPasswords()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "123456789",
                "12345678");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NoMatchingPasswords.Displayed.Should().BeTrue();
        }

        [Test]
        public void DemoqaRegisterNotEnoughSymbolsPassword()
        {
            var regPage = new RegistrationPage(this.driver);

            UserRegistration user = new UserRegistration(
                "Gospodin",
                "Gospodinov",
                new List<bool>(new bool[] { true, false, false }),
                new List<bool>(new bool[] { true, false, false }),
                "Bulgaria",
                "8",
                "6",
                "1998",
                "05555511111",
                "justuser9996666",
                "grey56ghgh6@abv.bg",
                @"..\..\..\avatar.jpg",
                "lorem ipsum",
                "1234567",
                "1234567");
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.NotEnoughSymbolsPassword.Displayed.Should().BeTrue();
        }

        [Test]
        public void LoginFormIsEmpty()
        {
            var regPage = new RegistrationPage(this.driver);
            
            regPage.NavigateTo();
            regPage.SubmitButton.Click();

            regPage.NoNames.Displayed.Should().BeTrue();
            regPage.NoHobbySelected.Displayed.Should().BeTrue();
            regPage.NoValidPhone.Displayed.Should().BeTrue();
            regPage.NoUserName.Displayed.Should().BeTrue();
            regPage.NoValidEmail.Displayed.Should().BeTrue();
            regPage.NotEnoughSymbolsPassword.Displayed.Should().BeTrue();
        }
    }
}