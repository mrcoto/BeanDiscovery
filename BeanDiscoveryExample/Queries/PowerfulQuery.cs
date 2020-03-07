using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Queries
{
    [Query(scope: ScopeType.SINGLETON)]
    public class PowerfulQuery
    {
        public string power() => "Power!";
    }
}
