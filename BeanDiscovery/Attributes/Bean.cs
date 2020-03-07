using BeanDiscovery.Data.Exceptions;
using System;

namespace BeanDiscovery.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class Bean : Attribute
    {
        public string Name { get; set; }
        public ScopeType Scope { get; }

        public Bean(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyBeanNameException();
            Name = name;
            Scope = scope;
        }

    }
}
