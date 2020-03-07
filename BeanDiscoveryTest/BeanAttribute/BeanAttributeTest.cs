
using BeanDiscovery.Attributes;
using BeanDiscovery.Data.Exceptions;
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

        [Fact]
        public void Test_Should_Retrieve_BeanScoped()
        {
            var bean = _factory.Services.GetService(typeof(IBeanScoped)) as IBeanScoped;
            Assert.NotNull(bean);
            Assert.Equal("BeanScoped", bean.WhoAmI());
        }

        [Fact]
        public void Test_Should_Retrieve_BeanSingleton()
        {
            var bean = _factory.Services.GetService(typeof(IBeanSingleton)) as IBeanSingleton;
            Assert.NotNull(bean);
            Assert.Equal("BeanSingleton", bean.WhoAmI());
        }

        [Fact]
        public void Test_Should_Retrieve_SingleBean()
        {
            var bean = _factory.Services.GetService(typeof(SingleBean)) as SingleBean;
            Assert.NotNull(bean);
            Assert.Equal("SingleBean", bean.WhoAmI());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Should_Throw_EmptyBeanNameException(string beanName)
        {
            Assert.Throws<EmptyBeanNameException>(() => new Bean(beanName));
        }
    }
}
