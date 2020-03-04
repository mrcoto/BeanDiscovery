using BeanDiscovery;
using BeanDiscovery.Attributes;

namespace BeanDiscoveryExample.Services
{
    [Service(scope: ScopeType.SINGLETON)]
    public class BookMagicService : IMagicService
    {
        public string Magic() => "El Principito";

    }
}
