
using Microsoft.Extensions.DependencyInjection;
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
            Assert.Equal(ServiceLifetime.Transient, ServiceDescriptors.GetServiceLifetime(typeof(IBeanTransient)));
        }

        [Fact]
        public void Test_Should_Retrieve_BeanScoped()
        {
            var bean = _factory.Services.GetService(typeof(IBeanScoped)) as IBeanScoped;
            Assert.NotNull(bean);
            Assert.Equal("BeanScoped", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(IBeanScoped)));
        }

        [Fact]
        public void Test_Should_Retrieve_BeanSingleton()
        {
            var bean = _factory.Services.GetService(typeof(IBeanSingleton)) as IBeanSingleton;
            Assert.NotNull(bean);
            Assert.Equal("BeanSingleton", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Singleton, ServiceDescriptors.GetServiceLifetime(typeof(IBeanSingleton)));
        }

        [Fact]
        public void Test_Should_Retrieve_SingleBean()
        {
            var bean = _factory.Services.GetService(typeof(SingleBean)) as SingleBean;
            Assert.NotNull(bean);
            Assert.Equal("SingleBean", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(SingleBean)));
        }

        [Fact]
        public void Test_Should_Retrieve_BeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(IBeanGeneric<BeanScoped>)) as IBeanGeneric<BeanScoped>;
            Assert.NotNull(bean);
            Assert.Equal("BeanGeneric:BeanScoped", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(IBeanGeneric<>)));
        }

        [Fact]
        public void Test_Should_Retrieve_SingleBeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(SingleBeanGeneric<BeanTransient>)) as SingleBeanGeneric<BeanTransient>;
            Assert.NotNull(bean);
            Assert.Equal("SingleBeanGeneric:BeanTransient", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(SingleBeanGeneric<>)));
        }

        [Fact]
        public void Test_Should_Retrieve_SubBeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(ISubBeanGeneric)) as ISubBeanGeneric;
            Assert.NotNull(bean);
            Assert.Equal("BeanGeneric:BeanScoped", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(ISubBeanGeneric)));
        }

        [Fact]
        public void Test_Should_Retrieve_SubSubBeanGeneric()
        {
            var bean = _factory.Services.GetService(typeof(ISubSubBeanGeneric)) as ISubSubBeanGeneric;
            Assert.NotNull(bean);
            Assert.Equal("SubSubBeanGeneric", bean.WhoAmI());
            Assert.Equal(ServiceLifetime.Scoped, ServiceDescriptors.GetServiceLifetime(typeof(ISubSubBeanGeneric)));
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
