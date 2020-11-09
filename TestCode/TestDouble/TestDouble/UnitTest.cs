using Moq;
using System;
using System.Linq;
using Xunit;

namespace TestDouble
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var mock = new Mock<IGreet>();

            // プロパティ
            var response = mock.SetupGet(x => x.Hello)
                .Returns("こんにちは");

            // メソッド
            mock.Setup(x => x.Greet("こんにちは"))
                .Returns("おはよう");

            Assert.Equal("こんにちは", mock.Object.Hello);
            Assert.Equal("おはよう", mock.Object.Greet("こんにちは"));

        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<IGreet>();

            string[] greets = { "おはよう", "こんにちは", "こんばんは" };

            // メソッド
            mock.Setup(x => x.Greet(It.Is<string>(s => greets.Contains(s))))
                .Returns("あいさつ");

            Assert.Equal("あいさつ", mock.Object.Greet("こんばんは"));

        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<IGreet>();
            // 全プロパティの定義
            mock.SetupAllProperties();

            var hello = mock.Object.Hello = "Hello";
            var name = mock.Object.Name = "Taro";
            var good = mock.Object.Good = "いいね！";

            mock.Setup(x => x.Greet("あいさつ"))
                .Returns(hello + name + good);

            Assert.Equal("HelloTaroいいね！", mock.Object.Greet("あいさつ"));
        }

        [Fact]
        public void Test4()
        {
            var mock = new Mock<IGreet>();

            // 複数返す
            mock.SetupSequence(x => x.Greet("あいさつ"))
                .Returns("おはよう")
                .Returns("こんにちは")
                .Returns("こんばんは");

            Assert.Equal("おはよう", mock.Object.Greet("あいさつ"));
            Assert.Equal("こんにちは", mock.Object.Greet("あいさつ"));
            Assert.Equal("こんばんは", mock.Object.Greet("あいさつ"));
        }

        [Fact]
        public void Test5()
        {
            var mock = new Mock<IGreet>();

            // 例外時
            mock.Setup(x => x.Greet("あいさつ以外"))
                .Throws<Exception>();

            Assert.Throws<Exception>(() => mock.Object.Greet("あいさつ以外"));
        }

        [Fact]
        public void Test6()
        {
            var mock = new Mock<IGreet>();

            Assert.Equal("こんばんは", mock.Object.Greet("あいさつ"));
        }
    }
}
