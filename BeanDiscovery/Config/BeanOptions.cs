using BeanDiscovery.Config.Data;
using System;
using System.Collections.Generic;

namespace BeanDiscovery.Config
{
    public class BeanOptions
    {
        public BeanConfig GlobalBeanName { get; protected set; }

        public Dictionary<Type, BeanConfig> InterfaceNameBag { get; protected set; }

        public List<Type> IgnoredBeanList { get; protected set; }

        public BeanOptions()
        {
            GlobalBeanName = new BeanConfig("Primary");
            InterfaceNameBag = new Dictionary<Type, BeanConfig>();
            IgnoredBeanList = new List<Type>();
        }

        public void IgnoreBean(Type Tbean) => IgnoredBeanList.Add(Tbean);

        public void IgnoreBean<Tbean>() where Tbean : class => IgnoreBean(typeof(Tbean));

        public void UseGlobalBeanName(string beanName) => GlobalBeanName = new BeanConfig(beanName);

        public void UseGlobalBeanNameWithError(string beanName) => GlobalBeanName = new BeanConfig(beanName, throwIfNotFound: true);

        public void UseBeanName(Type Tinterface, string beanName) => InterfaceNameBag.Add(Tinterface, new BeanConfig(beanName));

        public void UseBeanNameWithError(Type Tinterface, string beanName) => InterfaceNameBag.Add(Tinterface, new BeanConfig(beanName, throwIfNotFound: true));

        public void UseBeanName<Tinterface>(string beanName) where Tinterface : class => UseBeanName(typeof(Tinterface), beanName);
        
        public void UseBeanNameWithError<Tinterface>(string beanName) where Tinterface : class => UseBeanNameWithError(typeof(Tinterface), beanName);

        public BeanConfig FindBeanConfig(Type Tinterface) => InterfaceNameBag.GetValueOrDefault(Tinterface, GlobalBeanName);
    
    }
}
