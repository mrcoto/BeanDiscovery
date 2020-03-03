using BeanDiscovery.Attributes;

namespace BeanDiscoveryExample.Services
{
    [Service]
    public class BookMagicService : IMagicService
    {
        public string Magic() => "El Principito";

    }
}
