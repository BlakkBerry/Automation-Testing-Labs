using Atata;

namespace Practice15_Atata.Pages
{
    using _ = MainPage;
    
    [Url("")]
    public class MainPage : Page<_>
    {
        [FindByXPath("//input[@name='search']")]
        public TextInput<_> Search { get; private set; }

        [FindByXPath("//rz-mobile-user-menu/button[@class='header__button']")]
        public Button<_> OpenMenu { get; private set; }

        [FindByXPath("//button[@class='side-menu__close']")]
        public Button<_> CloseMenu { get; private set; }

        [FindByXPath("//ul[contains(normalize-space(@class),'lang')]//li[@class='lang__item __item']//a")]
        public Link<_> ChangeLangBtn { get; private set; }

        [FindByXPath("//header//div[contains(@class, 'header-search')]//button[contains(@class, 'search-form__submit')]")]
        public Button<ProductListPage, _> SearchBtn { get; private set; }
    }
}