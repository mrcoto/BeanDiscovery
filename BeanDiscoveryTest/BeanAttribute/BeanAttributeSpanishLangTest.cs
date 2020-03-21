using Microsoft.Extensions.DependencyInjection;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute
{
    public class BeanAttributeSpanishLangTest : IClassFixture<FakeApplicationFactory<FakeStartupSpanishLang>>
    {
        private FakeApplicationFactory<FakeStartupSpanishLang> _factory;

        public BeanAttributeSpanishLangTest(FakeApplicationFactory<FakeStartupSpanishLang> factory) => _factory = factory;

        [Fact]
        public void Test_Should_Retrieve_SpanishLangBean()
        {
            var bean = _factory.Services.GetService(typeof(ILangBean)) as ILangBean;
            Assert.NotNull(bean);
            Assert.Equal("Hola", bean.SayHi());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(ILangBean)));
        }
    }
}
