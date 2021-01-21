using System;
using TestCollection;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var countService = new CountService();

            

            Assert.Equal(1350, countService.getCountService());

            var result = countService.ParseLogLine("a");

            Assert.Equal("a", result);
        }
    }
}
