using System;

namespace BeanDiscovery.Data.Exceptions
{
    public class NotFoundBeanException : InvalidOperationException
    {
        public NotFoundBeanException(Type Tinterface, string beanName) : base(
            $"No Bean '{beanName}' found for interface '{Tinterface.FullName}'"
        ) { }
    }
}
