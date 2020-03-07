using MrCoto.BeanDiscovery.Data.Exceptions;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute
{
    public class BeanAttributeUnknowLangTest : IClassFixture<FakeApplicationFactory<FakeStartupUnknowLang>>
    {
        private FakeApplicationFactory<FakeStartupUnknowLang> _factory;

        public BeanAttributeUnknowLangTest(FakeApplicationFactory<FakeStartupUnknowLang> factory) => _factory = factory;

        [Fact]
        public void Test_Should_Throw_NotFoundBeanException()
        {
            Assert.Throws<NotFoundBeanException>(() => _factory.Services.GetService(typeof(ILangBean)));
        }
    }
}
