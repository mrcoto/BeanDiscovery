using MrCoto.BeanDiscovery.Data.Exceptions;
using System;

namespace MrCoto.BeanDiscovery.Attributes
{
    /// <summary>
    /// Bean is the basic element where you can define a class as a Bean.
    /// Every class marked as Bean will be registered in .Net Core IoC,
    /// so that class can be resolved an injected (Dependency Injection)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class Bean : Attribute
    {
        /// <summary>
        /// Name of the bean class (bean identifier).
        /// Two classes with same interface are distingished by it's names
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Scope of the bean
        /// 
        /// - Transient
        /// - Scoped
        /// - Singleton
        /// 
        /// </summary>
        public ScopeType Scope { get; }

        /// <summary>
        /// Constructor of the bean.
        /// </summary>
        /// <param name="name">Name or identifier of your bean</param>
        /// <param name="scope">ScopeType of the bean (Transient, Scope or Singleton)</param>

        public Bean(string name = "Primary", ScopeType scope = ScopeType.SCOPED) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyBeanNameException();
            Name = name;
            Scope = scope;
        }

    }
}
