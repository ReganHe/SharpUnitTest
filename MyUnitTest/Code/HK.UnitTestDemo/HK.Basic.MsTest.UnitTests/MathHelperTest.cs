using System;
using HK.Basic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HK.Basic.MsTest.UnitTests
{
    [TestClass]
    public class MathHelperTest
    {
        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(4, new MathHelper().Add(2, 2));
        }

        [TestMethod]
        public void MyFirstTheory_3_true()
        {
            Assert.IsTrue(new MathHelper().IsOdd(3));
        }

        [TestMethod]
        public void MyFirstTheory_10_false()
        {
            Assert.IsFalse(new MathHelper().IsOdd(10));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_0_Exception()
        {
            new MathHelper().Divide(10, 0);
        }

        [Ignore]
        [TestMethod]
        public void Divide_1_10()
        {
            const double expectual = 0xa;
            var result = new MathHelper().Divide(10, 0);
            Assert.AreEqual(result, expectual);
        }
    }
}
