using System;

namespace BeanDiscovery.Data.Exceptions
{
    public class BeanPresentException : InvalidOperationException
    {
        public BeanPresentException(Type Tinterface, string beanName) : base(
            $"Bean '{beanName}' is already present in interface '{Tinterface.FullName}'"
        )
        { }
    }
}
