using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Messageクラス
    /// </summary>
    public class Messenger
    {
        IWeatherService _weatherService;

        public Messenger(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public string GetMessage()
        { 
            var tommorowWeather = _weatherService.GetTomorrowWeather();

            switch (tommorowWeather)
            {
                case "晴れ":
                    return "明日は良い天気です。頑張りましょう";
                case "雨":
                    return "明日は雨みたいです。傘を忘れないように！";
                case "曇り":
                    return "明日は曇りのようです。気をつけて！";
                default:
                    throw new Exception("想定外エラー");
            }
        }
    }
}
