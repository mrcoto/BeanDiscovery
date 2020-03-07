using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("Spanish")]
    class SpanishLangBean : ILangBean
    {
        public string SayHi() => "Hola";
    }
}
