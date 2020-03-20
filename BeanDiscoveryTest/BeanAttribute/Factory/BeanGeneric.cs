using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean]
    public class BeanGeneric<T> : IBeanGeneric<T> where T : class
    {
        public string WhoAmI() => "BeanGeneric:" + typeof(T).Name;
    }
}
