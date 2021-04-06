using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practice8_Apium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var authPage = new AuthPage();

            authPage
                .EnterEmail("test@")
                .EmailValidationMessage.Should().Contain("Not a valid username");

            authPage
                .EnterPassword("123")
                .PasswordValidationMessage.Should().Contain("Password must be >5 characters");

            authPage
                .ClearFields()
                .EnterEmail("validemail@gmail.com")
                .EnterPassword("validpassword123")
                .Login();
        }
    }
}