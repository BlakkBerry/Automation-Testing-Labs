using System;
using OpenQA.Selenium;

namespace Practice2_Selenium.Pages
{
    public class MainPage : Page
    {
        private IWebElement _menu;

        public MainPage(IWebDriver driver, Page previousPage) : base(driver, previousPage)
        {
            Driver.Navigate().GoToUrl(ConfigurationUtils.GetValue("base-url"));
        }

        public MainPage OpenMenu()
        {
            _menu = Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("open-menu")));
            _menu.Click();

            return this;
        }

        public MainPage ChangeLanguageToUkr()
        {
            if (_menu == null)
            {
                throw new AggregateException("Trying to change language, but menu is not opened!");
            }
            
            try
            {
                IWebElement ukButton = Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("uk-lang")));
                if (ukButton.Displayed && ukButton.Enabled)
                {
                    ukButton.Click();
                    Console.WriteLine("Website language has been changed to Ukrainian.");
                }
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine("Website is using Ukrainian language.");
            }

            return this;
        }

        public MainPage CloseMenu()
        {
            if (_menu == null)
            {
                throw new AggregateException("Trying to close the menu, but it is not opened!");
            }
            
            if (_menu.Displayed)
            {
                Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("close-menu"))).Click();
            }

            return this;
        }

        public ProductListPage Search(string text)
        {
            IWebElement searchInput = Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("search")));
            searchInput.Click();
            
            searchInput.SendKeys(text + Keys.Enter);

            return new ProductListPage(Driver, this);
        }
    }
}