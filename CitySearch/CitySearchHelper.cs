using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CitySearch
{
    public static class CitySearchHelper
    {
        /// <summary>
        /// Method to check if the supplied char values is an allowed character for the lookup
        /// </summary>
        /// <param name="keyChar">The char to lookup</param>
        /// <returns>True is char is allowed, false otherwise</returns>
        public static bool IsAllowedChar(char keyChar)
        {
            var patternMatch = new Regex("^[A-Za-z\\s-]+$");

            if (patternMatch.IsMatch(keyChar.ToString()))
                return true;

            return false;
        }

    }
}
