using System;

namespace MrCoto.BeanDiscovery.Data.Exceptions
{
    /// <summary>
    /// Exception thrown where a bean name or identifier is empty.
    /// </summary>
    public class EmptyBeanNameException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmptyBeanNameException() : base(
            "Bean Name can't be empty"
        )
        { }
    }
}
