using ApiNetCore.Services;
using Moq;
using NUnit.Framework;

namespace ApiNetCoreTests.Tests
{
    public class Tests
    {
        //private IGetServiceNameService _getServiceNameService;

        [SetUp]
        public void Setup()
        {
            //_getServiceNameService = new GetServiceNameService();
        }

        [TestCase(TestName = "Should return 'Hello world! '")]
        public void Should_return_Hello_world()
        {
            var getServiceNameServiceMock = new Mock<IGetServiceNameService>();

            getServiceNameServiceMock.Setup(p => p.GetServiceName()).Returns("Hello world!");

            Assert.AreEqual(getServiceNameServiceMock.Object.GetServiceName(), "Hello world!");

            //Assert.AreEqual(_getServiceNameService.getServiceName(), "Hello world!");
        }
    }
}