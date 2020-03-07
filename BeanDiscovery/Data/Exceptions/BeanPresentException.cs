using System;

namespace MrCoto.BeanDiscovery.Data.Exceptions
{
    /// <summary>
    /// Exception thrown when two beans with same name are in the same
    /// collection interface.
    /// </summary>
    public class BeanPresentException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Tinterface">Type of the interface where the class is annotated with the bean.</param>
        /// <param name="beanName">Name of the bean that is already present.</param>
        public BeanPresentException(Type Tinterface, string beanName) : base(
            $"Bean '{beanName}' is already present in interface '{Tinterface.FullName}'"
        )
        { }
    }
}
