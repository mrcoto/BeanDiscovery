
using BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace BeanDiscoveryTest.BeanAttribute
{
    public class BeanAttributeTest : IClassFixture<FakeApplicationFactory<FakeStartup>>
    {
        private FakeApplicationFactory<FakeStartup> _factory;

        public BeanAttributeTest(FakeApplicationFactory<FakeStartup> factory) => _factory = factory;

        [Fact]
        public void Test_Should_Retrieve_BeanTransient()
        {
            var bean = _factory.Services.GetService(typeof(IBeanTransient)) as IBeanTransient;
            Assert.NotNull(bean);
            Assert.Equal("BeanTransient", bean.WhoAmI());
        }
    }
}
