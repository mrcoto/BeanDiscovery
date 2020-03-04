
using BeanDiscovery;
using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean(scope: ScopeType.TRANSIENT)]
    public class BeanTransient : IBeanTransient
    {
        public string WhoAmI() => "BeanTransient";
    }
}
