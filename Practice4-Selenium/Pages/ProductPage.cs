using OpenQA.Selenium;

namespace Practice2_Selenium.Pages
{
    public class ProductPage : Page
    {
        public ProductPage(IWebDriver driver, Page previousPage) : base(driver, previousPage)
        {
        }

        public int GetPrice()
        {
            var textPrice = Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("product-page-price"))).Text;
            var price = ConfigurationUtils.ParsePrice(textPrice);

            return price;
        }
    }
}