using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using Tesseract;

namespace Practice8_Apium
{
    using _ = AuthPage;

    public class AuthPage
    {
        private AndroidDriver<AndroidElement> _driver;

        private static Uri _testServerAddress = new Uri("http://localhost:4723/wd/hub");
        private static TimeSpan _initTimeoutSec = TimeSpan.FromSeconds(200);
        private static TimeSpan _implicitTimeoutSec = TimeSpan.FromSeconds(10);

        private const string EmailId = "com.example.test:id/username";
        private const string PasswordId = "com.example.test:id/password";
        private const string AuthBtnId = "com.example.test:id/login";

        private AndroidElement EmailField => _driver.FindElementById(EmailId);

        public string EmailValidationMessage =>
            GetErrorMessage(EmailField, new Rectangle(new Point(570, 680), new Size(380, 50)));

        private AndroidElement PasswordField => _driver.FindElementById(PasswordId);

        public string PasswordValidationMessage =>
            GetErrorMessage(EmailField, new Rectangle(new Point(370, 820), new Size(580, 50)));

        private AndroidElement AuthBtn => _driver.FindElementById(AuthBtnId);

        public AuthPage()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName,
                AutomationName.AndroidUIAutomator2);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App,
                @"C:\Users\blakk\AndroidStudioProjects\Test\app\build\outputs\apk\debug\app-debug.apk");

            _driver = new AndroidDriver<AndroidElement>(_testServerAddress, capabilities, _initTimeoutSec);
        }

        public _ EnterEmail(string email)
        {
            EmailField.Click();
            EmailField.SendKeys(email);

            return this;
        }

        public _ EnterPassword(string password)
        {
            PasswordField.Click();
            PasswordField.SendKeys(password);

            return this;
        }

        public _ Login()
        {
            AuthBtn.Click();

            return this;
        }

        public _ ClearFields()
        {
            EmailField.Clear();
            PasswordField.Clear();

            return this;
        }

        private string GetErrorMessage(AndroidElement element, Rectangle rectangle)
        {
            _driver.GetScreenshot().SaveAsFile($"{element.Id}.png");
            var img = Image.FromFile(Environment.CurrentDirectory + @$"\{element.Id}.png");
            var cloned = new Bitmap(img).Clone(rectangle, img.PixelFormat);
            cloned.Save(Environment.CurrentDirectory + @"\message.png");
            cloned.Dispose();

            var ocr = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            var pImg = Pix.LoadFromFile(Environment.CurrentDirectory + @"\message.png");
            var res = ocr.Process(pImg);

            File.Delete(Environment.CurrentDirectory + @"\message.png");
            return res.GetText();
        }
    }
}