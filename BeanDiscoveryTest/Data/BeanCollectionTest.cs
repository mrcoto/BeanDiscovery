using BeanDiscovery.Config.Data;
using BeanDiscovery.Data;
using BeanDiscovery.Data.Exceptions;
using BeanDiscoveryTest.BeanAttribute.Factory;
using Xunit;

namespace BeanDiscoveryTest.Data
{
    public class BeanCollectionTest
    {

        [Fact]
        public void Test_Should_Throw_BeanPresentException()
        {
            var beanCollection = new BeanCollection(typeof(ILangBean));
            beanCollection.AddBean(typeof(SpanishLangBean));
            Assert.Throws<BeanPresentException>(() => beanCollection.AddBean(typeof(Spanish2LangBean)));
        }

        [Theory]
        [InlineData("English", true, true)]
        [InlineData("English", false, false)]
        public void Test_Should_Throw_NotFoundBeanException(string beanName, bool throwExceptionIfNotFound, bool addSpanishLangBean)
        {
            var beanCollection = new BeanCollection(typeof(ILangBean));
            if (addSpanishLangBean)
                beanCollection.AddBean(typeof(SpanishLangBean));
            var beanConfig = new BeanConfig(beanName, throwExceptionIfNotFound);
            Assert.Throws<NotFoundBeanException>(() => beanCollection.FindBean(beanConfig));
        }

        [Fact]
        public void Test_Should_FindBean()
        {
            var beanCollection = new BeanCollection(typeof(ILangBean));
            beanCollection.AddBean(typeof(SpanishLangBean));
            var beanConfig = new BeanConfig("Spanish", true);
            var beanData = beanCollection.FindBean(beanConfig);
            Assert.NotNull(beanData);
            Assert.Equal(typeof(SpanishLangBean), beanData.TBean);
        }

    }
}
