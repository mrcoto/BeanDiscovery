
namespace MrCoto.BeanDiscovery.Attributes
{
    public class Repository : Bean
    {
        public Repository(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) : base(name, scope) { }
    }
}
