using System;

namespace MrCoto.BeanDiscovery.Data.Exceptions
{
    /// <summary>
    /// Exception thrown when a specific bean of an interface collection is not found.
    /// </summary>
    public class NotFoundBeanException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Tinterface">Type of the interface where the class is annotated with the bean.</param>
        /// <param name="beanName">Not found bean's name</param>
        public NotFoundBeanException(Type Tinterface, string beanName) : base(
            $"No Bean '{beanName}' found for interface '{Tinterface.FullName}'"
        ) { }
    }
}
