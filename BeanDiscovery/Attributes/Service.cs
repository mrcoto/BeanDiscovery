namespace MrCoto.BeanDiscovery.Attributes
{
    public class Service : Bean
    {
        public Service(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) : base(name, scope) { }
    }
}
