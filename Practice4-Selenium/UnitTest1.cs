using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Practice2_Selenium.Pages;

namespace Practice2_Selenium
{
    public class Tests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void TestsInit()
        {
        }

        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        [Test, Repeat(20)]
        public void CheckPrice()
        {
            MainPage mainPage = new MainPage(_driver, null);

            ProductListPage productsPage = mainPage
                .OpenMenu()
                .ChangeLanguageToUkr()
                .CloseMenu()
                .Search("Lenovo");

            var firstPrice = productsPage.GetFirstProductPrice();

            ProductPage productPage = productsPage.VisitFirstProduct();
            
            var secondPrice = productPage.GetPrice();
            
            Assert.That(firstPrice == secondPrice, "Price #1 is not equal to Price #2");
            Console.WriteLine("Price #1 and #2 are identical.");

            var thirdPrice = ((ProductListPage) productPage.Back()).GetFirstProductPrice();
            
            Assert.That(firstPrice == thirdPrice,  "Price #1 is not equal to Price #3");
            Console.WriteLine("Price #1 and #3 are identical.");
        }
    }
}