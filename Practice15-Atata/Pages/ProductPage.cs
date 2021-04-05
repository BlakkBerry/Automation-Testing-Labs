using Atata;

namespace Practice15_Atata.Pages
{
    using _ = ProductPage;

    public class ProductPage : Page<_>
    {
        [FindByXPath(
            "//div[@class='product-trade']//div[@class='product-prices__inner']//p[contains(@class, 'product-prices__big')]")]
        public Currency<_> Price { get; private set; }
    }
}