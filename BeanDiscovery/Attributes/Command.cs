namespace MrCoto.BeanDiscovery.Attributes
{
    /// <summary>
    /// Bean representing a Command (CQRS context)
    /// </summary>
    public class Command : Bean
    {
        /// <summary>
        /// Same constructor as Bean
        /// </summary>
        /// <param name="name">Name or identifier of your bean</param>
        /// <param name="scope">ScopeType of the bean (Transient, Scope or Singleton)</param>
        public Command(string name = "Primary", ScopeType scope = ScopeType.SCOPED) : base(name, scope) { }
    }
}
