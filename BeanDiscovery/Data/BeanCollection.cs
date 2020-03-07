using BeanDiscovery.Config.Data;
using BeanDiscovery.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeanDiscovery.Data
{
    public class BeanCollection
    {
        public Type TInterface { get; protected set; }
        public List<BeanData> BeanList { get; }

        public BeanCollection(Type tinterface)
        {
            TInterface = tinterface;
            BeanList = new List<BeanData>();
        }

        public void AddBean(Type tbean)
        {
            var beanData = new BeanData(tbean);
            if (BeanList.Any(x => x.BeanName == beanData.BeanName))
                throw new BeanPresentException(TInterface, beanData.BeanName);
            BeanList.Add(beanData);
        }

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
