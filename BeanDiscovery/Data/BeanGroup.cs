using System;
using System.Collections.Generic;
using System.Linq;

namespace MrCoto.BeanDiscovery.Data
{
    /// <summary>
    /// This class generate two group of classes.
    /// 
    /// - Classes that implements some interface (InterfaceBeans)
    /// - Classes without interface implementation (SingleBeans)
    /// 
    /// </summary>
    public class BeanGroup
    {
        /// <summary>
        /// Group of each bean (class marked as bean) per interface
        /// </summary>
        public List<BeanCollection> InterfaceBeans { get; }

        /// <summary>
        /// List of each bean (class marked as bean) without interface
        /// </summary>
        public List<BeanData> SingleBeans { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BeanGroup()
        {
            InterfaceBeans = new List<BeanCollection>();
            SingleBeans = new List<BeanData>();
        }

        /// <summary>
        /// Add a Bean to interface group collection
        /// </summary>
        /// <param name="tinterface">Type of the interface where the class is annotated with the bean attribute</param>
        /// <param name="tbean">Type of the class annotated with the bean attribute</param>
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

        /// <summary>
        /// Add a Bean to SingleBeans List
        /// </summary>
        /// <param name="tbean">Type of the class annotated with the bean attribute</param>
        public void Add(Type tbean) => SingleBeans.Add(new BeanData(tbean));

    }
}
