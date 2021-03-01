using OpenQA.Selenium;

namespace Practice2_Selenium.Pages
{
    public class ProductListPage : Page
    {
        public ProductListPage(IWebDriver driver, Page previousPage) : base(driver, previousPage)
        {
            
        }

        public int GetFirstProductPrice()
        {
            var textPrice = Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("first-product-price"))).Text;
            var price = ConfigurationUtils.ParsePrice(textPrice);

            return price;
        }

        public ProductPage VisitFirstProduct()
        {
            Driver.FindElement(By.XPath(ConfigurationUtils.GetValue("first-product-link"))).Click();

            return new ProductPage(Driver, this);
        }
    }
}