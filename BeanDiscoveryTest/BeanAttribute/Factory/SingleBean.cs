using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean]
    class SingleBean
    {
        public string WhoAmI() => "SingleBean";
    }
}
