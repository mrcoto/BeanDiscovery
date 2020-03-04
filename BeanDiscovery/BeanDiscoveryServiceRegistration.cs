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
            types.ToList().ForEach(t => RegisterTypeInServiceCollection(services, t));
        }

        private static void RegisterTypeInServiceCollection(IServiceCollection services, Type type)
        {
            var interfaces = type.GetInterfaces().ToList();
            var scopeType = GetScopeType(type);
            interfaces.ForEach(tinterface =>
            {
                var result = scopeType switch
                {
                    ScopeType.TRANSIENT => services.AddTransient(tinterface, type),
                    ScopeType.SCOPED => services.AddScoped(tinterface, type),
                    _ => services.AddSingleton(tinterface, type)
                };
            });
        }

        private static ScopeType GetScopeType(Type type)
        {
            // Attribute is already set in class (Method GetBeanTypes)
            var bean = type.GetCustomAttribute(typeof(Bean), inherit: true) as Bean;
            return bean.Scope;
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
