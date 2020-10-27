using ApiNetCore.Services;
using Moq;
using NUnit.Framework;

namespace ApiNetCoreTests.Tests
{
    public class HelloWorldTest
    {

        [TestCase(TestName = "Should return 'Hello world! '")]
        public void Should_return_Hello_world()
        {
            var getServiceNameServiceMock = new Mock<IGetServiceNameService>();

            getServiceNameServiceMock.Setup(p => p.GetServiceName()).Returns("Hello world!");

            Assert.AreEqual(getServiceNameServiceMock.Object.GetServiceName(), "Hello world!");
        }
    }
}