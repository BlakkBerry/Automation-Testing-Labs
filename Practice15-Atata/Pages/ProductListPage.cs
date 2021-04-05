using Atata;

namespace Practice15_Atata.Pages
{
    using _ = ProductListPage;

    public class ProductListPage : Page<_>
    {
        [FindByXPath(
            "//ul[@class='catalog-grid']/li[1]/app-goods-tile-default//p[1]")]
        public Currency<_> FirstProductPrice { get; private set; }
        
        [FindByXPath(
            "//div[@class='goods-tile__inner']//a[@class='goods-tile__picture'][1]")]
        public Link<ProductPage, _> FirstProductLink { get; private set; }
    }
}