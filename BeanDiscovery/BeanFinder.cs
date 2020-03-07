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

        public BeanGroup GetBeanTypes(List<AssemblyName> assemblyNames, List<Type> ignoreBeans)
        {
            var beanGroup = new BeanGroup();
            assemblyNames.ToList().ForEach(assemblyName =>
            {
                var assembly = Assembly.Load(assemblyName);
                var tbeans = GetBeanTypes(assembly);
                if (ignoreBeans != null)
                    tbeans = tbeans.Except(ignoreBeans).ToList();
                AddTypesToBeanGroup(beanGroup, tbeans);
            });
            return beanGroup;
        }

        private void AddTypesToBeanGroup(BeanGroup beanGroup, List<Type> tbeans)
        {
            tbeans.ForEach(tbean =>
            {
                var interfaces = tbean.GetInterfaces().ToList();
                if (interfaces.Count > 0)
                    interfaces.ForEach(tinterface => beanGroup.Add(tinterface, tbean));
                else
                    beanGroup.Add(tbean);
            });
        }

        public List<Type> GetBeanTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            return types.Where(t =>
            {
                return t.GetCustomAttribute(typeof(Bean), inherit: true) != null &&
                       t.IsClass;
            }).ToList();
        }

    }
}
