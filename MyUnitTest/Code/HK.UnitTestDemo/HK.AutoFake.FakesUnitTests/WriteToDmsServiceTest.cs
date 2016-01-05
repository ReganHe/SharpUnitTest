using System;
using HK.AutoFake.Business;
using HK.AutoFake.ExternalService.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HK.AutoFake.FakesUnitTests
{
    [TestClass]
    public class WriteToDmsServiceTest
    {
        [TestMethod]
        public void WriteImageTest_FilePathIsNull_False()
        {
            var service = new WriteToDmsService();
            var result = service.WriteImage(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FilePathIsEmpty_False()
        {
            var service = new WriteToDmsService();
            bool result = service.WriteImage(string.Empty);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FileNotExists_False()
        {
            const string filePath = "C:\\a.txt";
            var service = new WriteToDmsService();
            bool result = service.WriteImage(filePath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeTrue_True()
        {
            using (ShimsContext.Create())
            {
                ShimExternalDmsService.AllInstances.WriteStringByteArray = (t0, t1, t2) => true;
                var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.MockDemo.Business.dll");
                var service = new WriteToDmsService();
                bool result = service.WriteImage(filePath);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void WriteImageTest_FakeFalse_False()
        {
            using (ShimsContext.Create())
            {
                ShimExternalDmsService.AllInstances.WriteStringByteArray = (t0, t1, t2) => false;
                var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.MockDemo.Business.dll");
                var service = new WriteToDmsService();
                bool result = service.WriteImage(filePath);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void WriteImageTest_FakeException_Exception()
        {
            using (ShimsContext.Create())
            {
                ShimExternalDmsService.AllInstances.WriteStringByteArray = (t0, t1, t2) =>
                {
                    throw new ApplicationException("ServiceException");
                };
                try
                {
                    var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.MockDemo.Business.dll");
                    var service = new WriteToDmsService();
                    service.WriteImage(filePath);
                }
                catch (ApplicationException ex)
                {
                    Assert.AreEqual(ex.Message, "ServiceException");
                }

            }
        }
    }
}
