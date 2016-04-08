using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App10.Helper
{
    public class ConstantHelper
    {
        public static string ApiKey = "3f17eef11fab42bcb5683402160404";
        private const string CurrentBaseUrl = "http://api.apixu.com/v1/current.json?key=";
        private const string ForecastBaseUrl = "http://api.apixu.com/v1/forecast.json?key=";
        private const string SearchUrl = "http://api.apixu.com/v1/search.json?key=";

        public static string SetUrl(bool value)
        {
            if (value)
                return string.Format(CurrentBaseUrl + ApiKey + "&q=");
            else
                return string.Format(ForecastBaseUrl + ApiKey + "&q=");
        }

        public static string SetSearchUrl()
        {
            return (
                string.Format(SearchUrl + ApiKey + "&q=")
                );
        }
    }
}
