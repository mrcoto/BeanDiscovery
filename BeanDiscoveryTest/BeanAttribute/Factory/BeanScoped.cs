
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.SCOPED)]
    public class BeanScoped : IBeanScoped
    {
        public string WhoAmI() => "BeanScoped";
    }
}
