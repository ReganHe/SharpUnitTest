using System;
using HK.AutoFake.Business;
using HK.AutoFake.ExternalService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HK.AutoFake.MoqUnitTests
{
    [TestClass]
    public class WriteToFspServiceTest
    {
        [TestMethod]
        public void WriteImageTest_FilePathIsNull_False()
        {
            var service = new WriteToFspService(null);
            var result = service.WriteImage(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FilePathIsEmpty_False()
        {
            var service = new WriteToFspService(null);
            bool result = service.WriteImage(string.Empty);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FileNotExists_False()
        {
            const string filePath = "C:\\a.txt";
            var service = new WriteToFspService(null);
            bool result = service.WriteImage(filePath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeTrue_True()
        {
            var imageWritorMock = new Mock<IImageWritor>();
            imageWritorMock.Setup(obj => obj.Write(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(true);
            var service = new WriteToFspService(imageWritorMock.Object);
            var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.AutoFake.Business.dll");
            var result = service.WriteImage(filePath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeFalse_False()
        {
            var imageWritorMock = new Mock<IImageWritor>();
            imageWritorMock.Setup(obj => obj.Write(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(false);
            var service = new WriteToFspService(imageWritorMock.Object);
            var filePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "HK.AutoFake.Business.dll");
            var result = service.WriteImage(filePath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WriteImageTest_FakeException_Exception()
        {
            var imageWritorMock = new Mock<IImageWritor>();
            imageWritorMock.Setup(obj => obj.Write(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(() =>
            {
                throw new ApplicationException("ServiceException");
            });
            try
            {
                var service = new WriteToFspService(imageWritorMock.Object);
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
