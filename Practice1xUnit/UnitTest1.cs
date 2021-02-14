using System;
using SourceCode;
using Xunit;
using Xunit.Abstractions;

namespace Practice1xUnit
{
    public class UnitTest1 : IDisposable
    {
        private readonly ITestOutputHelper _output;

        // TASK 11 - Global setup and tear down are impossible to implement with xUnit 
        
        // TASK 11
        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Test Started - " + Lab1Utils.GetEstTime());
        }

        // TASK 11
        public void Dispose()
        {
            _output.WriteLine("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - Data driven
        [Theory]
        [InlineData(6)]
        public void CallMyFunction_GreaterThan5_PositiveValue(int value)
        {
            var res = Lab1Utils.CallMyFunction(value);

            Assert.True(res > 0);
        }

        // TASK 7 - Data driven
        [Theory]
        [InlineData(4)]
        public void CallMyFunction_LowerThan5_NegativeValue(int value)
        {
            var res = Lab1Utils.CallMyFunction(value);

            Assert.True(res < 0);
        }

        // TASK 7 - Data driven, which reads from csv
        [Theory]
        [ClassData(typeof(CsvReader))]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge(int age)
        {
            Assert.True(age > 0);
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
        [Theory, InlineData(5)]
        public void MyFunction_ValueOf5_DivideByZeroException(int criticalValue)
        {
            Assert.Throws<DivideByZeroException>(() => Lab1Utils.CallMyFunction(criticalValue));
        }
    }
}