namespace MrCoto.BeanDiscovery.Attributes
{
    /// <summary>
    /// Bean representing a Query (CQRS context)
    /// </summary>
    public class Query : Bean
    {
        /// <summary>
        /// Same constructor as Bean
        /// </summary>
        /// <param name="name">Name or identifier of your bean</param>
        /// <param name="scope">ScopeType of the bean (Transient, Scope or Singleton)</param>
        public Query(string name = "Primary", ScopeType scope = ScopeType.SCOPED) : base(name, scope) { }
    }
}
