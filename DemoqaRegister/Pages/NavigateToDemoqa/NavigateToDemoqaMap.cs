using OpenQA.Selenium;

namespace DemoqaRegister.Pages.NavigateToDemoqa
{
    public partial class NavigateToDemoqa
    {
        public IWebElement RegistrationPage => Wait.Until(x => x.FindElement(By.LinkText("Registration")));

        public IWebElement EntryTitle => Driver.FindElement(By.ClassName("entry-title"));
    }
}
