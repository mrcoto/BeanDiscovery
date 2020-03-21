using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    /**
    * This class simulates this case:
    * IInterfaceA { }
    * IInterfaceB : IInterfaceA { }
    * BeanClass : IInterfaceB
    */
    [Bean]
    class SubSubBeanGeneric : ISubSubBeanGeneric
    {
        public string WhoAmI() => "SubSubBeanGeneric";
    }
}
