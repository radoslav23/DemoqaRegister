using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace DemoqaRegister.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        public IWebDriver Driver => driver;

        public WebDriverWait Wait => wait;
    }
}
