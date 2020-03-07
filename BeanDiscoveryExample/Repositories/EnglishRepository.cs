using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Repositories
{
    [Repository("English")]
    public class EnglishRepository : ILangRepository
    {
        public string sayHi() => "Hello";
    }
}
