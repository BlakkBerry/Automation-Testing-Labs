using System;
using System.Linq;
using Atata;
using NUnit.Framework;
using Practice15_Atata.Pages;

namespace Practice15_Atata
{
    public class Tests
    {
        [OneTimeSetUp]
        public void Init()
        {
            AtataContext.GlobalConfiguration
                .UseChrome()
                .WithArguments("start-maximized");
        }
        
        [SetUp]
        public void Setup()
        {
            AtataContext.Configure().
                UseChrome().
                UseBaseUrl("https://rozetka.com.ua/").
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void Test1()
        {
            var browser = Go.To<MainPage>()
                .OpenMenu.Click()
                .Wait(2)
                .ChangeLangBtn.Click()
                .Search.Set("lenovo")
                .SearchBtn.ClickAndGo()
                .FirstProductPrice.Click();
            
            var firstPrice = browser.FirstProductPrice.Value;

            browser
                .FirstProductLink
                .ClickAndGo()
                .Price.Should.Equal(firstPrice)
                .GoBack<ProductListPage>()
                .FirstProductPrice.Should.Equal(firstPrice);
        }
    }
}