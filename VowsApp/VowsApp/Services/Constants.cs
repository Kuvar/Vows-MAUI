using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowsApp.Services
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.135:5240/api/{0}" : "https://localhost:5240/api/{0}";
        public static string WeatherForecastUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.135:5240/{0}" : "https://localhost:5240/{0}";

        public const string _locationKey = "LocationKey";
    }
}
