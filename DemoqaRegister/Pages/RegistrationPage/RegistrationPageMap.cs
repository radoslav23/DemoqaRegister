using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoqaRegister.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement FirstName => Driver.FindElement(By.Id("name_3_firstname")); 
        
        public IWebElement LastName => Driver.FindElement(By.Id("name_3_lastname"));
        
        public List<IWebElement> MartialStatus => Driver.FindElements(By.Name("radio_4[]")).ToList();
        
        public List<IWebElement> Hobbys => Driver.FindElements(By.Name("checkbox_5[]")).ToList(); 

        private IWebElement Country => Driver.FindElement(By.Id("dropdown_7")); 

        public SelectElement CountrySelect => new SelectElement(Country);

        private IWebElement BirthMonth => Driver.FindElement(By.Id("mm_date_8")); 
        
        public SelectElement BirthMonthSelect => new SelectElement(BirthMonth);       

        private IWebElement BirthDay => Driver.FindElement(By.Id("dd_date_8")); 
        
        public SelectElement BirthDaySelect => new SelectElement(BirthDay);        

        private IWebElement BirthYear => Driver.FindElement(By.Id("yy_date_8")); 

        public SelectElement BirthYearSelect => new SelectElement(BirthYear);

        public IWebElement Phone => Driver.FindElement(By.Id("phone_9")); 

        public IWebElement UserName => Driver.FindElement(By.Id("username")); 

        public IWebElement Email => Driver.FindElement(By.Id("email_1")); 

        public IWebElement UploadPicture => Driver.FindElement(By.Id("profile_pic_10")); 

        public IWebElement AboutYourself => Driver.FindElement(By.Id("description")); 

        public IWebElement Password => Driver.FindElement(By.Id("password_2")); 
         
        public IWebElement ConfirmPassword => Driver.FindElement(By.Id("confirm_password_password_2")); 

        public IWebElement SubmitButton => Driver.FindElement(By.Name("pie_submit"));         

        public IWebElement SuccessRegisterMessage => Driver.FindElement(By.ClassName("piereg_message")); 

        //error messages
        public IWebElement NoNames => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span")));

        public IWebElement NoHobbySelected => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span")));

        public IWebElement NoValidPhone => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span")));

        public IWebElement NoUserName => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span")));

        public IWebElement NoValidEmail => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span")));

        public IWebElement NoMatchingPasswords => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span")));

        public IWebElement NotEnoughSymbolsPassword => Wait.Until(x => x.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span")));
    }
}
