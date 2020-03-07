using MrCoto.BeanDiscovery.Attributes;
using System;
using System.Reflection;

namespace MrCoto.BeanDiscovery.Data
{
    public class BeanData
    {
        public Type TBean { get; protected set; }

        public Bean Bean { get; protected set; }

        public ScopeType Scope { get; protected set; }

        public string BeanName { get; protected set; }

        public BeanData(Type tbean)
        {
            TBean = tbean;
            Bean = tbean.GetCustomAttribute(typeof(Bean), inherit: true) as Bean;
            Scope = Bean.Scope;
            BeanName = Bean.Name;
        }

    }
}
