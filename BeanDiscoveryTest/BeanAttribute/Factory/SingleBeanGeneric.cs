using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean]
    public class SingleBeanGeneric<T>
    {
        public string WhoAmI() => "SingleBeanGeneric:" + typeof(T).Name;
    }
}
