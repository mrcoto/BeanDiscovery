using System;

namespace BeanDiscovery.Data.Exceptions
{
    public class EmptyBeanNameException : InvalidOperationException
    {
        public EmptyBeanNameException() : base(
            "Bean Name can't be empty"
        )
        { }
    }
}
