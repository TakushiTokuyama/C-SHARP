using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public class SunnyWeatherService : IWeatherService
    {
        public string GetTomorrowWeather()
        {
            return "晴れ";
        }
    }
}
