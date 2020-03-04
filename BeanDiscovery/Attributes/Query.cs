
namespace BeanDiscovery.Attributes
{
    public class Query : Bean
    {
        public Query(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) : base(name, scope) { }
    }
}
