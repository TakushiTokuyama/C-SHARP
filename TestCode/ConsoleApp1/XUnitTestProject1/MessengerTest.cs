using ConsoleApp1;
using Xunit;

namespace XUnitTestProject1
{
    public class MessengerTest
    {
        [Fact]
        public void GetMessage_晴れの時のテスト()
        {
            var sunny = new SunnyWeatherService();

            var messenger = new Messenger(sunny);

            var msg = messenger.GetMessage();

            Assert.Equal("明日は良い天気です。頑張りましょう", msg);
        }
    }
}
