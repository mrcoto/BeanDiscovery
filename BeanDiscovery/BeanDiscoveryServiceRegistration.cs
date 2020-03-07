﻿using MrCoto.BeanDiscovery.Config;
using MrCoto.BeanDiscovery.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MrCoto.BeanDiscovery
{
    public static class BeanDiscoveryServiceRegistration
    {
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

        private static void RegisterTypeInServiceCollection(IServiceCollection services, Type tinterface, BeanData beanData)
        {
            if (beanData.Scope == ScopeType.TRANSIENT) services.AddTransient(tinterface, beanData.TBean);
            else if (beanData.Scope == ScopeType.SCOPED) services.AddScoped(tinterface, beanData.TBean);
            else services.AddSingleton(tinterface, beanData.TBean);
        }

        private static void RegisterTypeInServiceCollection(IServiceCollection services, BeanData beanData)
        {
            if (beanData.Scope == ScopeType.TRANSIENT) services.AddTransient(beanData.TBean);
            else if (beanData.Scope == ScopeType.SCOPED) services.AddScoped(beanData.TBean);
            else services.AddSingleton(beanData.TBean);
        }

    }
}
