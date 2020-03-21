
using MrCoto.BeanDiscovery.Attributes;
using MrCoto.BeanDiscovery.Data.Exceptions;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute
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

        [Fact]
        public void Test_Should_Retrieve_BeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(IBeanGeneric<BeanScoped>)) as IBeanGeneric<BeanScoped>;
            Assert.NotNull(bean);
            Assert.Equal("BeanGeneric:BeanScoped", bean.WhoAmI());
        }

        [Fact]
        public void Test_Should_Retrieve_SingleBeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(SingleBeanGeneric<BeanTransient>)) as SingleBeanGeneric<BeanTransient>;
            Assert.NotNull(bean);
            Assert.Equal("SingleBeanGeneric:BeanTransient", bean.WhoAmI());
        }

        [Fact]
        public void Test_Should_Retrieve_SunBeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(ISubBeanGeneric)) as ISubBeanGeneric;
            Assert.NotNull(bean);
            Assert.Equal("BeanGeneric:BeanScoped", bean.WhoAmI());
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
