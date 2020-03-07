using MrCoto.BeanDiscovery.Config.Data;
using MrCoto.BeanDiscovery.Data;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using System.Linq;
using Xunit;

namespace MrCoto.BeanDiscoveryTest.Data
{
    public class BeanGroupTest
    {
        [Fact]
        public void Test_Should_Add_SingleBean()
        {
            var beanGroup = new BeanGroup();
            beanGroup.Add(typeof(SingleBean));
            Assert.Contains(beanGroup.SingleBeans, x => x.TBean == typeof(SingleBean));
        }

        [Fact]
        public void Test_Should_Add_InterfaceWithBean()
        {
            var beanGroup = new BeanGroup();
            beanGroup.Add(typeof(ILangBean), typeof(SpanishLangBean));
            var beanCollection = beanGroup.InterfaceBeans.FirstOrDefault(x => x.TInterface == typeof(ILangBean));
            Assert.NotNull(beanCollection);
            var beanData = beanCollection.FindBean(new BeanConfig("Spanish", false));
            Assert.NotNull(beanData);
            Assert.Equal(typeof(SpanishLangBean), beanData.TBean);
        }
    }
}
