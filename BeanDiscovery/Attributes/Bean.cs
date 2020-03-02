using System;

namespace BeanDiscovery.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Bean : Attribute
    {
        public string Name { get; set; }
        public ScopeType Scope { get; }

        public Bean(string name = "Primary", ScopeType scope = ScopeType.TRANSIENT) 
        {
            Name = name;
            Scope = scope;
        }

    }
}
