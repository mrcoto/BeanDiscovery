using MrCoto.BeanDiscovery.Attributes;
using System;
using System.Reflection;

namespace MrCoto.BeanDiscovery.Data
{
    /// <summary>
    /// This class encapsulates needed bean's data given a Type.
    /// </summary>
    public class BeanData
    {
        /// <summary>
        /// Type of the bean (class marked with Bean Attribute)
        /// </summary>
        public Type TBean { get; protected set; }

        /// <summary>
        /// The Bean attribute of the Type.
        /// </summary>
        public Bean Bean { get; protected set; }

        /// <summary>
        /// ScopeType of the Bean property
        /// </summary>
        public ScopeType Scope { get; protected set; }

        /// <summary>
        /// BeanName of the Bean property
        /// </summary>
        public string BeanName { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tbean">Type of the class marked with Bean attribute.</param>
        public BeanData(Type tbean)
        {
            TBean = tbean;
            Bean = tbean.GetCustomAttribute(typeof(Bean), inherit: true) as Bean;
            Scope = Bean.Scope;
            BeanName = Bean.Name;
        }

    }
}
