using BeanDiscovery.Attributes;

namespace BeanDiscoveryExample.Repositories
{
    [Repository("English")]
    public class EnglishRepository : ILangRepository
    {
        public string sayHi() => "Hello";
    }
}
