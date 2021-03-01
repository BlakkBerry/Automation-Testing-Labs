using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;

namespace Practice2_Selenium
{
    public class ConfigurationUtils
    {
        private static Configuration _configuration;

        static ConfigurationUtils()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetValue(string key)
        {
            return _configuration.AppSettings.Settings[key].Value;
        }

        public static int ParsePrice(string price)
        {
            price = price.Replace(" ", String.Empty).Trim(' ', '₴');
            Int32.TryParse(price, out var result);

            return result;
        }
    }
}