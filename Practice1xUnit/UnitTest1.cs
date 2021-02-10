using System;
using SourceCode;
using Xunit;
using Xunit.Abstractions;

namespace Practice1xUnit
{
    public class UnitTest1 : IDisposable
    {
        private readonly ITestOutputHelper _output;

        // TASK 11
        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;

            output.WriteLine("Hello World");
        }

        // TASK 11
        public void Dispose()
        {
            _output.WriteLine("Cruel World");
        }

        // TASK 7 - Data driven
        [Fact]
        public void CallMyFunction_GreaterThan5_PositiveValue()
        {
            _output.WriteLine("Test Started - " + Lab1Utils.GetEstTime());

            var res = Lab1Utils.CallMyFunction(6);

            Assert.True(res > 0);

            _output.WriteLine("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - Data driven
        [Fact]
        public void CallMyFunction_LowerThan5_NegativeValue()
        {
            var res = Lab1Utils.CallMyFunction(4);

            Assert.True(res < 0);
        }

        // TASK 7 - Data driven, which reads from csv
        [Fact]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge()
        {
            const int expectedFirstAge = 20;

            var firstAgeFromCsv = Lab1Utils.GetFirstAgeFromCsv();

            Assert.Equal(expectedFirstAge, firstAgeFromCsv);
        }

        // TASK 7 and 8 - Data driven, 100 tests with random values
        [Theory]
        [Repeat(100)]
        public void MyFunction_RandomValues_ValidDoubleOrDivideByZeroException(int randomValue)
        {
            _output.WriteLine("Random value: " + randomValue);
            
            if (randomValue == 5)
            {
                Assert.Throws<DivideByZeroException>(() => Lab1Utils.CallMyFunction(randomValue));
            }
        }
        
        // TASK 9 (Retry and timeout is impossible to implement with basic xUnit functionality)
        
        // TASK 10
        [Fact]
        public void MyFunction_ValueOf5_DivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Lab1Utils.CallMyFunction(5));
        }
    }
}