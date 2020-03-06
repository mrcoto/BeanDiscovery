using BeanDiscovery.Attributes;

namespace BeanDiscoveryExample.Repositories
{
    [Repository("Spanish")]
    public class SpanishRepository : ILangRepository
    {
        public string sayHi() => "Hola";
    }
}
