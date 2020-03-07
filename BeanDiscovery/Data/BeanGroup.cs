using System;
using System.Collections.Generic;
using System.Linq;

namespace MrCoto.BeanDiscovery.Data
{
    public class BeanGroup
    {
        public List<BeanCollection> InterfaceBeans { get; }

        public List<BeanData> SingleBeans { get; }

        public BeanGroup()
        {
            InterfaceBeans = new List<BeanCollection>();
            SingleBeans = new List<BeanData>();
        }

        public void Add(Type tinterface, Type tbean)
        {
            var beanCollection = InterfaceBeans.FirstOrDefault(x => x.TInterface.Equals(tinterface));
            if (beanCollection == default(BeanCollection))
            {
                beanCollection = new BeanCollection(tinterface);
                InterfaceBeans.Add(beanCollection);
            }
            beanCollection.AddBean(tbean);
        }

        public void Add(Type tbean) => SingleBeans.Add(new BeanData(tbean));

    }
}
