using BeanDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeanDiscovery
{
    class BeanFinder
    {
        public IEnumerable<Type> GetBeanTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            return types.Where(t =>
            {
                return t.GetCustomAttribute(typeof(Bean), inherit: true) != null &&
                       t.GetTypeInfo().IsClass;
            }).AsEnumerable();
        }

    }
}
