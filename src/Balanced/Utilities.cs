using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Balanced
{
    public class Utilities
    {
        public static string ConvertToPythonCase(string Word)
        {
            string PythonCased = Regex.Replace(Word, @"(.)([A-Z][a-z]+)", "$1_$2");
            PythonCased = Regex.Replace(PythonCased, @"([a-z0-9])([A-Z])", "$1_$2");
            return PythonCased.ToLower();
        }
    }
}
