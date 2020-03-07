using MrCoto.BeanDiscovery.Config.Data;
using MrCoto.BeanDiscovery.Data.Exceptions;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.Config.Data
{
    public class BeanConfigTest
    {
        [Theory]
        [InlineData("Secondary", false)]
        [InlineData("English", true)]
        public void Test_Should_Set_Correct_Values(string name, bool throwIfNotFound)
        {
            var beanConfig = new BeanConfig(name, throwIfNotFound);
            Assert.Equal(name, beanConfig.BeanName);
            Assert.Equal(throwIfNotFound, beanConfig.ThrowExceptionIfNotFound);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_Should_Throw_EmptyBeanNameException(string name)
        {
            Assert.Throws<EmptyBeanNameException>(() => new BeanConfig(name));
        }
    }
}
