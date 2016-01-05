using HK.SelfStub.Service;
using Xunit;

namespace HK.SelfStub.UnitTests
{
    public class LogAnalyzerUsingFactoryMethodTest
    {
        [Fact]
        public void IsValidLogFileName()
        {
            IExtensionManager stub = new FakeExtensionManager
            {
                WillBeValid = true
            };
            var testableLogAnalyzer = new TestableLogAnalyzer(stub);
            var result = testableLogAnalyzer.IsValidLogFileName("file.ext");
            Assert.True(result);
        }
    }

    class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        private readonly IExtensionManager _manager;

        public TestableLogAnalyzer(IExtensionManager manager)
        {
            _manager = manager;
        }

        protected override IExtensionManager GetManager()
        {
            return _manager;
        }
    }
}
