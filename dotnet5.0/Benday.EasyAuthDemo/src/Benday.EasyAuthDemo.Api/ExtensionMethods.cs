using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Globalization;

namespace Benday.EasyAuthDemo.Api
{
    public static partial class ExtensionMethods
    {
        public static string SafeToString(this string value)
        {
            if (value == null)
            {
                return String.Empty;
            }
            else
            {
                return value;
            }
        }
        
        public static string SafeToString(this string value, string defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }
        
        public static int SafeToInt32(this string value, int defaultValue)
        {
            var valueAsString = value.SafeToString();
            
            if (value == String.Empty)
            {
                return defaultValue;
            }
            else
            {
                int returnValue = defaultValue;
                
                Int32.TryParse(valueAsString, out returnValue);
                
                return returnValue;
            }
        }
        
        public static bool IsNullOrWhitespace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
        
        public static string ToStringUsdCurrency(this float value)
        {
            return String.Format(new CultureInfo("en-US"), "{0:C}", value);
        }
    }
}
