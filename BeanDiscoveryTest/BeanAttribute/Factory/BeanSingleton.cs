
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.SINGLETON)]
    public class BeanSingleton : IBeanSingleton
    {
        public string WhoAmI() => "BeanSingleton";
    }
}
