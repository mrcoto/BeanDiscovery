using BeanDiscovery.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeanDiscovery
{
    public static class BeanDiscoveryServiceRegistration
    {
        public static void UseBeanDiscovery(this IServiceCollection services)
        {
            // This call needs to be here, if this call is inside "GetBeanTypes"
            // or another method, then the actual assembly is used, and not the 'Real calling assembly'
            var assembly = Assembly.GetCallingAssembly();
            var types = GetBeanTypes(assembly);
        }

        private static IEnumerable<Type> GetBeanTypes(Assembly assembly)
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
