using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Repositories
{
    [Repository("Spanish")]
    public class SpanishRepository : ILangRepository
    {
        public string sayHi() => "Hola";
    }
}
