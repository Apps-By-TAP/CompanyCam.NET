using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CompanyCam.NET.Utils
{
    internal static class Utils
    {
        internal static string AddQueryParameter(string queryString, string key, string value)
        {
            if(!queryString.Contains("?"))
            {
                queryString += $"?{key}={value}";
            }
            else
            {
                queryString += $"&{key}={value}";
            }

            return queryString;
        }
    }
}
