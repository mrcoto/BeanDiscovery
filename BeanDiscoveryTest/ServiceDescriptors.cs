using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrCoto.BeanDiscoveryTest
{
    public static class ServiceDescriptors
    {
        public static List<ServiceDescriptor> ServiceDescriptorList;
        public static void Generate(IServiceCollection services)
        {
            ServiceDescriptorList = new List<ServiceDescriptor>();
            var enumerator = services.GetEnumerator();
            while (enumerator.MoveNext())
                ServiceDescriptorList.Add(enumerator.Current);
        }

        public static ServiceLifetime GetServiceLifetime(Type tservice)
        {
            return ServiceDescriptorList.First(descriptor => descriptor.ServiceType == tservice).Lifetime;
        }
    }
}
