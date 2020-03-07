using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Services
{
    [Service(scope: ScopeType.SINGLETON)]
    public class BookMagicService : IMagicService
    {
        public string Magic() => "El Principito";

    }
}
