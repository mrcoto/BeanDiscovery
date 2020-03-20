namespace MrCoto.BeanDiscovery.Attributes
{
    /// <summary>
    /// Bean representing a Service
    /// </summary>
    public class Service : Bean
    {
        /// <summary>
        /// Same constructor as Bean
        /// </summary>
        /// <param name="name">Name or identifier of your bean</param>
        /// <param name="scope">ScopeType of the bean (Transient, Scope or Singleton)</param>
        public Service(string name = "Primary", ScopeType scope = ScopeType.SCOPED) : base(name, scope) { }
    }
}
