using OpenQA.Selenium;

namespace DemoqaRegister.Pages.NavigateToDemoqa
{
    public partial class NavigateToDemoqa : BasePage
    {
        public NavigateToDemoqa(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Url = "http://demoqa.com/";
        }

        public void RegistrationPageClick()
        {
            RegistrationPage.Click();
        }
    }
}
