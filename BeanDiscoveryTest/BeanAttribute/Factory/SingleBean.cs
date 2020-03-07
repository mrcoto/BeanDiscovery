using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean]
    class SingleBean
    {
        public string WhoAmI() => "SingleBean";
    }
}
