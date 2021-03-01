using OpenQA.Selenium;

namespace Practice2_Selenium.Pages
{
    public class Page
    {
        protected readonly IWebDriver Driver;
        protected Page PreviousPage;

        public Page(IWebDriver driver, Page previousPage)
        {
            Driver = driver;
            PreviousPage = previousPage;
        }

        public Page Back()
        {
            Driver.Navigate().Back();
            return PreviousPage;
        }
    }
}