using MrCoto.BeanDiscovery.Attributes;
using MrCoto.BeanDiscovery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MrCoto.BeanDiscovery
{
    class BeanFinder
    {
        /// <summary>
        /// Find all classes marked with bean attributes in assemblyNames list.
        /// All found classes in ignoreBeans list will be ignored.
        /// </summary>
        /// <param name="assemblyNames">Name of assemblies where classes with bean attribute are looked for</param>
        /// <param name="ignoreBeans">Beans to be ignored</param>
        /// <returns>Group of beans (with or without interface)</returns>
        public BeanGroup GetBeanTypes(List<AssemblyName> assemblyNames, List<Type> ignoreBeans = null)
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

        /// <summary>
        /// Find classes marked as bean in a specific Assembly
        /// </summary>
        /// <param name="assembly">Assembly where beans will be looked for</param>
        /// <returns>List of beans found</returns>
        public List<Type> GetBeanTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            return types.Where(t =>
            {
                return t.GetCustomAttribute(typeof(Bean), inherit: true) != null &&
                       t.IsClass;
            }).ToList();
        }

        /// <summary>
        /// Add a list of beans to bean's group
        /// </summary>
        /// <param name="beanGroup">Bean's group</param>
        /// <param name="tbeans">List of beans (classes marked as bean)</param>
        private void AddTypesToBeanGroup(BeanGroup beanGroup, List<Type> tbeans)
        {
            tbeans.ForEach(tbean =>
            {
                var interfaces = GetDirectInterfaces(tbean);
                if (interfaces.Count > 0)
                    interfaces.ForEach(tinterface => beanGroup.Add(tinterface, tbean));
                else
                    beanGroup.Add(tbean);
            });
        }

        /// <summary>
        /// Get Direct (not Inherited interfaces)
        /// </summary>
        /// <param name="tbean">Type of tbean class</param>
        /// <returns>Direct (not Inherited) interface type list</returns>
        private List<Type> GetDirectInterfaces(Type tbean)
        {
            var directInterfaces = tbean.GetInterfaces();
            if (tbean.BaseType != null) 
                directInterfaces = directInterfaces.Except(tbean.BaseType.GetInterfaces()).ToArray();
            foreach (var tinterface in directInterfaces) 
                directInterfaces = directInterfaces.Except(tinterface.GetInterfaces()).ToArray();
            return directInterfaces.ToList();
        }

    }
}
