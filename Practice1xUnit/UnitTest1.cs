using System;
using SourceCode;
using Xunit;
using Xunit.Abstractions;

namespace Practice1xUnit
{
    public class UnitTest1 : IDisposable
    {
        ITestOutputHelper output;

        // TASK 11
        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;

            output.WriteLine("Hello World");
        }

        // TASK 11
        public void Dispose()
        {
            output.WriteLine("Cruel World");
        }

        // TASK 7 - DATA DRIVEN
        [Fact]
        public void CallMyFunction_GreaterThan5_PositiveValue()
        {
            output.WriteLine("Test Started - " + Lab1Utils.GetEstTime());

            var res = Lab1Utils.CallMyFunction(6);

            Assert.True(res > 0);

            output.WriteLine("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - DATA DRIVEN
        [Fact]
        public void CallMyFunction_LowerThan5_NegativeValue()
        {
            var res = Lab1Utils.CallMyFunction(4);

            Assert.True(res < 0);
        }

        // TASK 7 - DATA DRIVEN WHICH READS FROM CSV
        [Fact]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge()
        {
            Int32 expectedFirstAge = 20;

            var firstAgeFromCsv = Lab1Utils.GetFirstAgeFromCsv();

            Assert.Equal(expectedFirstAge, firstAgeFromCsv);
        }

        // TASK 7 and 8 - DATA DRIVEN, RANDOM 100 TIMES
        [Theory]
        [Repeat(100)]
        public void MyFunction_RandomValues_ValidDoubleOrDivideByZeroException(int randomValue)
        {
            output.WriteLine("Random value: " + randomValue);
            
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