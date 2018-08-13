using System.Collections.Generic;
using System.IO;
using DemoqaRegister.UserRegData;
using OpenQA.Selenium;

namespace DemoqaRegister.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm(UserRegistration user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            ClickElements(MartialStatus, user.MartialStatus);
            ClickElements(Hobbys, user.Hobbys);
            CountrySelect.SelectByText(user.Country);
            BirthMonthSelect.SelectByText(user.BirthMonth);
            BirthDaySelect.SelectByText(user.BirthDay);
            BirthYearSelect.SelectByText(user.BirthYear);
            Type(Phone, user.Phone);
            Type(UserName, user.UserName);
            Type(Email, user.Email);
            UploadPicture.Click();
            Driver.SwitchTo().ActiveElement().SendKeys(Path.GetFullPath(user.ProfilePicture));
            Type(AboutYourself, user.AboutYourself);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);
            SubmitButton.Click();
        }

        private void ClickElements(List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i])
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
