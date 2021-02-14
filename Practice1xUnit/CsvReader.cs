using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Practice1xUnit
{
    public class CsvReader : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            using (TextFieldParser parser =
                new TextFieldParser(@"C:\Users\blakk\OneDrive\Desktop\users.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    
                    yield return new object[] {Int32.Parse(fields[2])};
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}