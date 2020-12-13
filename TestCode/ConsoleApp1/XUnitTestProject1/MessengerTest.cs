using ConsoleApp1;
using Xunit;

namespace XUnitTestProject1
{
    public class MessengerTest
    {
        [Fact]
        public void GetMessage_����̎��̃e�X�g()
        {
            var sunny = new SunnyWeatherService();

            var messenger = new Messenger(sunny);

            var msg = messenger.GetMessage();

            Assert.Equal("�����͗ǂ��V�C�ł��B�撣��܂��傤", msg);
        }
    }
}
