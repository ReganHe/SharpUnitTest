using System;
using HK.Basic.Services;
using Xunit;

namespace HK.Basic.XUnit.UnitTests
{
    public class MathHelperTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, new MathHelper().Add(2, 2));
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(10, false)]
        public void MyFirstTheory(int param, bool expectual)
        {
            Assert.Equal(new MathHelper().IsOdd(param), expectual);
        }

        [Fact]
        public void Divide_0_Exception()
        {
            Assert.Throws<DivideByZeroException>(() => new MathHelper().Divide(10, 0));
        }

        [Fact(Skip = "Temp")]
        public void Divide_1_10()
        {
            const double expectual = 0xa;
            var result = new MathHelper().Divide(10, 0);
            Assert.Equal(result, expectual);
        }
    }
}
