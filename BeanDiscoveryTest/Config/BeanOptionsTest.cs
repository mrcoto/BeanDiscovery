using BeanDiscovery.Config;
using BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace BeanDiscoveryTest.Config
{
    public class BeanOptionsTest
    {
        [Fact]
        public void Test_Should_Add_Bean_To_Ignore_List()
        {
            var beanOptions = new BeanOptions();
            beanOptions.IgnoreBean(typeof(Spanish2LangBean));
            beanOptions.IgnoreBean<SpanishLangBean>();
            Assert.Contains(beanOptions.IgnoredBeanList, type => type == typeof(Spanish2LangBean));
            Assert.Contains(beanOptions.IgnoredBeanList, type => type == typeof(SpanishLangBean));
        }

        [Theory]
        [InlineData("Global", false)]
        [InlineData("Santa", true)]
        public void Test_Should_Use_Global_BeanName(string name, bool withErrors)
        {
            var beanOptions = new BeanOptions();
            if (withErrors)
                beanOptions.UseGlobalBeanNameWithError(name);
            else
                beanOptions.UseGlobalBeanName(name);

            Assert.Equal(name, beanOptions.GlobalBeanName.BeanName);
            Assert.Equal(withErrors, beanOptions.GlobalBeanName.ThrowExceptionIfNotFound);
        }

        [Fact]
        public void Test_Should_Use_BeanName()
        {
            var beanOptions = new BeanOptions();
            beanOptions.UseBeanName(typeof(ILangBean), "Spanish");
            Assert.Equal("Spanish", beanOptions.InterfaceNameBag[typeof(ILangBean)].BeanName);
            Assert.False(beanOptions.InterfaceNameBag[typeof(ILangBean)].ThrowExceptionIfNotFound);
            beanOptions.UseBeanNameWithError(typeof(ILangBean), "Spanish 2");
            Assert.Equal("Spanish 2", beanOptions.InterfaceNameBag[typeof(ILangBean)].BeanName);
            Assert.True(beanOptions.InterfaceNameBag[typeof(ILangBean)].ThrowExceptionIfNotFound);
            beanOptions.UseBeanName<ILangBean>("Spanish 3");
            Assert.Equal("Spanish 3", beanOptions.InterfaceNameBag[typeof(ILangBean)].BeanName);
            Assert.False(beanOptions.InterfaceNameBag[typeof(ILangBean)].ThrowExceptionIfNotFound);
            beanOptions.UseBeanNameWithError<ILangBean>("Spanish 4");
            Assert.Equal("Spanish 4", beanOptions.InterfaceNameBag[typeof(ILangBean)].BeanName);
            Assert.True(beanOptions.InterfaceNameBag[typeof(ILangBean)].ThrowExceptionIfNotFound);
        }

        [Fact]
        public void Test_Should_Find_GlobalBeanConfig()
        {
            var beanOptions = new BeanOptions();
            beanOptions.UseGlobalBeanName("Global");
            var beanConfig = beanOptions.FindBeanConfig(typeof(ILangBean));
            Assert.Equal("Global", beanConfig.BeanName);
            Assert.False(beanConfig.ThrowExceptionIfNotFound);
        }

        [Fact]
        public void Test_Should_Find_InterfaceBeanConfig()
        {
            var beanOptions = new BeanOptions();
            beanOptions.UseGlobalBeanName("Global");
            beanOptions.UseBeanNameWithError(typeof(ILangBean), "Spanish");
            var beanConfig = beanOptions.FindBeanConfig(typeof(ILangBean));
            Assert.Equal("Spanish", beanConfig.BeanName);
            Assert.True(beanConfig.ThrowExceptionIfNotFound);
        }

    }
}
