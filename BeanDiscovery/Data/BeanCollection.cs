using MrCoto.BeanDiscovery.Config.Data;
using MrCoto.BeanDiscovery.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrCoto.BeanDiscovery.Data
{
    /// <summary>
    /// List of beans (classes marked as bean) with same interface.
    /// </summary>
    public class BeanCollection
    {
        /// <summary>
        /// Type of the interface where the class is annotated with the bean
        /// </summary>
        public Type TInterface { get; protected set; }

        /// <summary>
        /// List of each bean's data
        /// </summary>
        public List<BeanData> BeanList { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tinterface">Type of the interface where the class is annotated with the bean</param>
        public BeanCollection(Type tinterface)
        {
            TInterface = tinterface;
            BeanList = new List<BeanData>();
        }

        /// <summary>
        /// Add new bean to BeanList property
        /// <exception cref="MrCoto.BeanDiscovery.Data.Exceptions.BeanPresentException">
        /// Thrown when bean is already present in BeanList.
        /// </exception>
        /// </summary>
        /// <param name="tbean">Type of the class that is marked with Bean Attribute.</param>
        public void AddBean(Type tbean)
        {
            var beanData = new BeanData(tbean);
            if (BeanList.Any(x => x.BeanName == beanData.BeanName))
                throw new BeanPresentException(TInterface, beanData.BeanName);
            BeanList.Add(beanData);
        }

        /// <summary>
        /// Find a Bean given a custom bean configuration.
        /// If the configuration says that no exception should be thrown,
        /// then the first bean of the list is returned (unless list is empty)
        /// <exception cref="MrCoto.BeanDiscovery.Data.Exceptions.NotFoundBeanException">
        /// Thrown when a bean is not found.
        /// </exception>
        /// </summary>
        /// <param name="beanConfig">Bean Configuration that specifies how bean will be resolved.</param>
        /// <returns>Found Bean's data</returns>
        public BeanData FindBean(BeanConfig beanConfig)
        {
            var beanData = BeanList.FirstOrDefault(x => x.BeanName == beanConfig.BeanName);
            if (beanData != null) return beanData;
            if (beanConfig.ThrowExceptionIfNotFound)
                throw new NotFoundBeanException(TInterface, beanConfig.BeanName);
            beanData = BeanList.FirstOrDefault();
            if (beanData != null) return beanData;
            throw new NotFoundBeanException(TInterface, beanConfig.BeanName);
        }

    }
}
