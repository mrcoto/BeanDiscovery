
namespace MrCoto.BeanDiscovery.Attributes
{
    public class Command : Bean
    {
        public Command(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) : base(name, scope) { }
    }
}
