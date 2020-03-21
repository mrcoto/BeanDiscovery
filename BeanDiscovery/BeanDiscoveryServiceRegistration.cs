using MrCoto.BeanDiscovery.Config;
using MrCoto.BeanDiscovery.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MrCoto.BeanDiscovery
{
    /// <summary>
    /// Starting point, of service discovery based on .Net Core Service Collection
    /// </summary>
    public static class BeanDiscoveryServiceRegistration
    {
        /// <summary>
        /// Function called when you are registering services in Startup,
        /// this should be called as follow:
        /// 
        /// <code>
        /// services.UseBeanDiscovery();
        /// </code>
        /// 
        /// Also, you can define options to this function, for example:
        /// 
        /// <code>
        /// services.UseBeanDiscovery(options => 
        /// {
        ///     options.UseGlobalBeanNameWithError("Secondary") // Secondary global name will be used. Default: "Primary"
        ///     options.UseBeanNameWithError&lt;ILangRepository&gt;("English"); // Use "English" Repository for ILangRepository interface
        ///     options.$lt;CustomBean$gt;(); // CustomBean will be ignored (even it's marked with Bean Attribute)
        /// });
        /// </code>
        /// 
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="options">Configuration of BeanOptions</param>
        public static void UseBeanDiscovery(this IServiceCollection services, Action<BeanOptions> options = null)
        {
            var beanOptions = new BeanOptions();
            services.AddSingleton(beanOptions);
            options?.Invoke(beanOptions);
            // This call needs to be here, if this call is inside "GetBeanTypes"
            // or another method, then the actual assembly is used, and not the 'Real calling assembly'
            var assembly = Assembly.GetCallingAssembly();
            var assemblyNames = assembly.GetReferencedAssemblies().ToList();
            assemblyNames.Add(assembly.GetName());
            DiscoverBeans(services, assemblyNames, beanOptions);
        }

        /// <summary>
        /// This function uses BeanFinder to discover beans and then register in service collection.
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="assemblyNames">Name of the assemblies where Beans will be looked for</param>
        /// <param name="beanOptions">Bean Options to be applied when discover beans</param>
        private static void DiscoverBeans(IServiceCollection services, List<AssemblyName> assemblyNames, BeanOptions beanOptions)
        {
            var beanFinder = new BeanFinder();
            var beanGroup = beanFinder.GetBeanTypes(assemblyNames, beanOptions.IgnoredBeanList);
            beanGroup.InterfaceBeans.ForEach(interfaceBean =>
            {
                var beanConfig = beanOptions.FindBeanConfig(interfaceBean.TInterface);
                var beanData = interfaceBean.FindBean(beanConfig);
                RegisterTypeInServiceCollection(services, interfaceBean.TInterface, beanData);
            });
            beanGroup.SingleBeans.ForEach(beanData => RegisterTypeInServiceCollection(services, beanData));
        }

        /// <summary>
        /// Register a bean (class marked as bean) with interface in service collection
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="tinterface">Type of the interface where the class is annotated with the bean</param>
        /// <param name="beanData">Bean's data</param>
        private static void RegisterTypeInServiceCollection(IServiceCollection services, Type tinterface, BeanData beanData)
        {
            Type realInterfaceType = GetRealTypeFromBaseType(tinterface);
            Type realBeanType = GetRealTypeFromBaseType(beanData.TBean);
            if (beanData.Scope == ScopeType.TRANSIENT) services.AddTransient(realInterfaceType, realBeanType);
            else if (beanData.Scope == ScopeType.SCOPED) services.AddScoped(realInterfaceType, realBeanType);
            else services.AddSingleton(realInterfaceType, realBeanType);
        }

        /// <summary>
        /// Register a bean (class marked as bean) without an interface in service collection
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="beanData">Bean's data</param>
        private static void RegisterTypeInServiceCollection(IServiceCollection services, BeanData beanData)
        {
            Type realBeanType = GetRealTypeFromBaseType(beanData.TBean);
            if (beanData.Scope == ScopeType.TRANSIENT) services.AddTransient(realBeanType);
            else if (beanData.Scope == ScopeType.SCOPED) services.AddScoped(realBeanType);
            else services.AddSingleton(realBeanType);
        }

        /// <summary>
        /// Get real type from a base type,
        /// Because a generic class/interface has different definition type
        /// </summary>
        /// <param name="type">Base Type</param>
        /// <returns></returns>
        private static Type GetRealTypeFromBaseType(Type type)
        {
            if (type.IsGenericType) return type.GetGenericTypeDefinition();
            return type;
        }

    }
}
