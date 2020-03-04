
using BeanDiscovery;
using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.SCOPED)]
    public class BeanScoped : IBeanScoped
    {
        public string WhoAmI() => "BeanScoped";
    }
}
