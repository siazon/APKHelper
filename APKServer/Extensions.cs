﻿using System.Text.RegularExpressions;

namespace APKServer
{
    public static class Extensions
    {
        private static readonly string config =
            string.Join("|", System.Enum.GetNames(typeof(Models.Configs)));

        /// <summary>
        /// </summary>
        /// <param name="id">resource id</param>
        public static bool IsResource(this string input, string id = "")
        {
            // id is a word (\w)
            id = string.Empty.Equals(id) ? @"\w*" : id;
            return Regex.IsMatch(input, $"^\\s*resource\\s{id}");
        }
        /// <summary>
        /// Is resource value
        /// </summary>
        public static bool IsResourceValue(this string input)
        {
            // Start with space, then (string?)
            return Regex.IsMatch(input, @"^\s*\((string\d*)\)*");
        }
        /// <summary>
        /// Determines resource is reference (to another)
        /// </summary>
        public static bool IsReference(this string input)
        {
            // Start with space, then (reference)
            return Regex.IsMatch(input, @"^\s*\((reference)\)*");
        }
        /// <summary>
        /// Determines resource is a bitmap resource
        /// </summary>
        public static bool IsBitmapElement(this string input)
        {
            return Regex.IsMatch(input, @"^\s*E:\sbitmap");
        }

        public static bool IsConfig(this string input)
        {
            // config (default) | (hdpi|mdpi|...)[-vxx]
            return Regex.IsMatch(input, $"^\\s*config\\s\\(?({config})(-v\\d*)?\\)?:");
        }

        public static bool IsEntryType(this string input)
        {
            // type x configCount=xx entryCount=xxx
            return Regex.IsMatch(input, $"^\\s*type\\s\\d*\\sconfigCount=\\d*\\sentryCount=\\d*$");
        }
    }
}
