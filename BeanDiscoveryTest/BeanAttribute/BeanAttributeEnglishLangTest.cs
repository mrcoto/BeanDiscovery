using BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace BeanDiscoveryTest.BeanAttribute
{
    public class BeanAttributeEnglishLangTest : IClassFixture<FakeApplicationFactory<FakeStartupEnglishLang>>
    {
        private FakeApplicationFactory<FakeStartupEnglishLang> _factory;

        public BeanAttributeEnglishLangTest(FakeApplicationFactory<FakeStartupEnglishLang> factory) => _factory = factory;

        [Fact]
        public void Test_Should_Retrieve_SpanishLangBean()
        {
            var bean = _factory.Services.GetService(typeof(ILangBean)) as ILangBean;
            Assert.NotNull(bean);
            Assert.Equal("Hello", bean.SayHi());
        }
    }
}
