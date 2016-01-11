using System;
using HK.AutoFake.Business;
using HK.AutoFake.ExternalService.Contract.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HK.AutoFake.FakesUnitTests
{
    [TestClass]
    public class WriteToFspServiceTest
    {
        [TestMethod]
        public void WriteImageTest_FakeTrue_True()
        {
            var repository = new StubIImageWritor {WriteStringByteArray = (t1, t2) => true};
            var service = new WriteToFspService(repository);
            var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.AutoFake.Business.dll");
            var result = service.WriteImage(filePath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeFalse_False()
        {
            var repository = new StubIImageWritor {WriteStringByteArray = (t1, t2) => false};
            var service = new WriteToFspService(repository);
            var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.AutoFake.Business.dll");
            var result = service.WriteImage(filePath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeException_Exception()
        {
            var repository = new StubIImageWritor
            {
                WriteStringByteArray = (t1, t2) =>
                {
                    throw new ApplicationException("ServiceException");
                }
            };
            try
            {
                var service = new WriteToFspService(repository);
                var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.AutoFake.Business.dll");
                service.WriteImage(filePath);
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual(ex.Message, "ServiceException");
            }
        }
    }
}
