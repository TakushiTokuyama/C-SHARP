using System;

namespace ConsoleApp1
{
    internal class WeatherService : IWeatherService
    {
        public WeatherService()
        {
        }

        public string GetTomorrowWeather()
        {
            Random ran = new Random();

            var wetherNum = ran.Next(1, 4);

            var weather = "";

            switch (wetherNum)
            {
                case 1:
                    weather = "晴れ";
                    break;
                case 2:
                    weather = "雨";
                    break;
                case 3:
                    weather = "曇り";
                    break;
            }

            return weather;
        }
    }
}