using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jwt.Core.Extensions
{
    public static class CoreExtensions
    {
        public static string IsNull(this string value)
        {
            if (value == null) return "";
            return value;
        }

        public static TimeSpan ToTimeSpan(this string value)
        {
            return !TimeSpan.TryParse(value, out var time) ? TimeSpan.Zero : time;
        }

        public static string ToPhone(this string value)
        {
            value ??= "";
            if (value.Length >= 10 && value.Length <= 11)
            {
                return value.Length == 10 ? value : value.Substring(1, 10);
            }

            return "";
        }
        public static string Right(this string value, int length)
        {
            var result = string.IsNullOrEmpty(value) ? "" : value;
            result = result.Length > length ? result.Substring(result.Length - length, length) : result;
            return result;
        }

        public static string Left(this string value, int length)
        {
            var result = string.IsNullOrEmpty(value) ? "" : value;
            result = result.Length > length ? result.Substring(0, length) : result;
            return result;
        }

        public static string ClearSymbol(this string value)
        {
            var source = new[] {
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','R','S','T','U','V','Y','Z','W','X',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','r','s','t','u','v','y','z','w','x',
                '0','1','2','3','4','5','6','7','8','9'
            };
            var builder = new StringBuilder();
            foreach (var ch in value.Where(ch => source.Contains(ch)))
            {
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static int ToInt(this object value)
        {
            value ??= "0";
            int.TryParse(value.ToString(), out var result);
            return result;
        }
        public static double ToDouble(this object value)
        {
            value ??= "0";
            double.TryParse(value.ToString().Replace(",", "").Replace(".", ","), out var result);
            return result;
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static List<string> ToList(this string value, string separator)
        {
            var result = new List<string>();
            value ??= "";
            if (value.Length <= 0) return result;
            if (value.IndexOf(separator, StringComparison.Ordinal) < 0)
            {
                if (value != "")
                    result.Add(value);
            }
            else
            {
                var values = value.Split(new[] { separator }, StringSplitOptions.None);
                result.AddRange(values.Where(item => !string.IsNullOrEmpty(item)));
            }
            return result;
        }
        public static string StripHtmlTags(this string source)
        {
            return Regex.Replace(source, "<.*?>|&.*?;", string.Empty);
        }
        public static List<string> ParseRangeValue(this string source, string parser = ";")
        {
            return !source.Contains(";") ? new List<string>() : source.Split(new string[] { parser }, StringSplitOptions.None).ToList();
        }
        public static void AddRange(this IList iList, IEnumerable collection)
        {
            foreach (var item in collection)
            {
                iList.Add(item);
            }
        }
    }
}
