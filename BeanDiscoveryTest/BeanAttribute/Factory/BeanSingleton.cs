
using BeanDiscovery;
using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.SINGLETON)]
    public class BeanSingleton : IBeanSingleton
    {
        public string WhoAmI() => "BeanSingleton";
    }
}
