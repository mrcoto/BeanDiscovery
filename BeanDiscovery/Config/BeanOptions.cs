using MrCoto.BeanDiscovery.Config.Data;
using System;
using System.Collections.Generic;

namespace MrCoto.BeanDiscovery.Config
{
    /// <summary>
    /// BeanOptions defines how your beans will be resolver, or 
    /// if you have beans to be ignored.
    /// </summary>
    public class BeanOptions
    {
        /// <summary>
        /// Resolver config for all discovered beans.
        /// </summary>
        public BeanConfig GlobalBeanName { get; protected set; }

        /// <summary>
        /// Defines how a bean is resolver per interface.
        /// This has priority over GlobalBeanName
        /// </summary>
        public Dictionary<Type, BeanConfig> InterfaceNameBag { get; protected set; }

        /// <summary>
        /// List of beans to be ignored (classes marked as beans).
        /// </summary>
        public List<Type> IgnoredBeanList { get; protected set; }

        /// <summary>
        /// BeanOptions Constructor
        /// </summary>
        public BeanOptions()
        {
            GlobalBeanName = new BeanConfig("Primary");
            InterfaceNameBag = new Dictionary<Type, BeanConfig>();
            IgnoredBeanList = new List<Type>();
        }

        /// <summary>
        /// Add bean to be ignored in ignored bean list
        /// </summary>
        /// <param name="Tbean">Type of the bean to be ignored (class marked with some bean attribute)</param>
        public void IgnoreBean(Type Tbean) => IgnoredBeanList.Add(Tbean);

        /// <summary>
        /// Add bean to be ignored in ignored bean list
        /// </summary>
        public void IgnoreBean<Tbean>() where Tbean : class => IgnoreBean(typeof(Tbean));

        /// <summary>
        /// Global beanName to be used when discover beans (default is "Primary")
        /// </summary>
        /// <param name="beanName">Name of the bean to be resolved.</param>
        public void UseGlobalBeanName(string beanName) => GlobalBeanName = new BeanConfig(beanName);

        /// <summary>
        /// Global beanName to be used when discover beans (default is "Primary").
        /// If no bean is found globally, then an exception should be thrown.
        /// </summary>
        /// <param name="beanName">Name of the bean to be resolved.</param>
        public void UseGlobalBeanNameWithError(string beanName) => GlobalBeanName = new BeanConfig(beanName, throwIfNotFound: true);

        /// <summary>
        /// Define beanName to be resolver for a single interface type.
        /// Only one resolver config per interface is allowed.
        /// </summary>
        /// <param name="Tinterface">Type of the interface where the class is annotated with the bean.</param>
        /// <param name="beanName">Name or identifier of the bean</param>
        /// <param name="throwIfNotFound">Should an exception must thrown if not found?</param>
        public void UseBeanName(Type Tinterface, string beanName, bool throwIfNotFound = false)
        {
            if (InterfaceNameBag.ContainsKey(Tinterface))
                InterfaceNameBag.Remove(Tinterface);
            InterfaceNameBag.Add(Tinterface, new BeanConfig(beanName, throwIfNotFound));
        }

        /// <summary>
        /// Define beanName to be resolver for a single interface type.
        /// Only one resolver config per interface is allowed.
        /// If bean not resolved, an exception should be thrown.
        /// </summary>
        /// <param name="Tinterface">Type of the interface where the class is annotated with the bean.</param>
        /// <param name="beanName">Name or identifier of the bean</param>
        public void UseBeanNameWithError(Type Tinterface, string beanName) => UseBeanName(Tinterface, beanName, throwIfNotFound: true);

        /// <summary>
        /// Define beanName to be resolver for a single interface type.
        /// Only one resolver config per interface is allowed.
        /// </summary>
        /// <param name="beanName">Name or identifier of the bean</param>
        public void UseBeanName<Tinterface>(string beanName) where Tinterface : class => UseBeanName(typeof(Tinterface), beanName);

        /// <summary>
        /// Define beanName to be resolver for a single interface type.
        /// Only one resolver config per interface is allowed.
        /// If bean not resolved, an exception should be thrown.
        /// </summary>
        /// <param name="beanName">Name or identifier of the bean</param>
        public void UseBeanNameWithError<Tinterface>(string beanName) where Tinterface : class => UseBeanNameWithError(typeof(Tinterface), beanName);

        /// <summary>
        /// Get BeanConfig configuration for a single interface type.
        /// If no configuration found, global configuration will be used.
        /// </summary>
        /// <param name="Tinterface">Type of the interface where the class is annotated with the bean.</param>
        /// <returns>Bean Configuration to be used.</returns>
        public BeanConfig FindBeanConfig(Type Tinterface) => InterfaceNameBag.GetValueOrDefault(Tinterface, GlobalBeanName);
    
    }
}
