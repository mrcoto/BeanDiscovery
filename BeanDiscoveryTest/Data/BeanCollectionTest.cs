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

    }
}
