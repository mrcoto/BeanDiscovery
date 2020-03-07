namespace MrCoto.BeanDiscovery.Attributes
{
    /// <summary>
    /// Bean representing a Repository
    /// </summary>
    public class Repository : Bean
    {
        /// <summary>
        /// Same constructor as Bean
        /// </summary>
        /// <param name="name">Name or identifier of your bean</param>
        /// <param name="scope">ScopeType of the bean (Transient, Scope or Singleton)</param>
        public Repository(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) : base(name, scope) { }
    }
}
