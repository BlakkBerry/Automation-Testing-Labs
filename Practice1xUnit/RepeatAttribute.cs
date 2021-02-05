using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Practice1xUnit
{
    public class RepeatAttribute : DataAttribute
    {
        private readonly int _count;

        public RepeatAttribute(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), 
                    "Repeat count must be greater than 0.");
            }
            _count = count;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var random = new Random();
            
            foreach (var iterationNumber in Enumerable.Range(start: 1, count: this._count))
            {
                yield return new object[] { random.Next(Int32.MinValue, Int32.MaxValue) };
            }
        }
    }
}