using BeanDiscovery;
using BeanDiscovery.Attributes;

namespace BeanDiscoveryExample.Queries
{
    [Query(scope: ScopeType.SINGLETON)]
    public class PowerfulQuery
    {
        public string power() => "Power!";
    }
}
