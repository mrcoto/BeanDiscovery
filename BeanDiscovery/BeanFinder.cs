using BeanDiscovery.Attributes;
using BeanDiscovery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeanDiscovery
{
    class BeanFinder
    {

        public BeanGroup GetBeanTypes(List<AssemblyName> assemblyNames)
        {
            var beanGroup = new BeanGroup();
            assemblyNames.ToList().ForEach(assemblyName =>
            {
                var assembly = Assembly.Load(assemblyName);
                var tbeans = GetBeanTypes(assembly);
                AddTypesToBeanGroup(beanGroup, tbeans);
            });
            return beanGroup;
        }

        private void AddTypesToBeanGroup(BeanGroup beanGroup, List<Type> tbeans)
        {
            tbeans.ForEach(tbean =>
            {
                tbean.GetInterfaces().ToList().ForEach(tinterface => beanGroup.Add(tinterface, tbean));
            });
        }

        public List<Type> GetBeanTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            return types.Where(t =>
            {
                return t.GetCustomAttribute(typeof(Bean), inherit: true) != null &&
                       t.GetTypeInfo().IsClass;
            }).ToList();
        }

    }
}
