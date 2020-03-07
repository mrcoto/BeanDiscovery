
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.TRANSIENT)]
    public class BeanTransient : IBeanTransient
    {
        public string WhoAmI() => "BeanTransient";
    }
}
