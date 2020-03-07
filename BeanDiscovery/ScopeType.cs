namespace MrCoto.BeanDiscovery
{
    /// <summary>
    /// Lifetime of a Service
    /// 
    /// - Transient
    /// - Scoped
    /// - Singleton
    /// </summary>
    public enum ScopeType
    {
        /// <summary>
        /// Transient scope
        /// </summary>
        TRANSIENT = 1,
        /// <summary>
        /// Scoped scope
        /// </summary>
        SCOPED = 2,
        /// <summary>
        /// Singleton scope
        /// </summary>
        SINGLETON = 3
    }
}
