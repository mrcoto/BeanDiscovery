using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("Spanish")]
    class SpanishLangBean : ILangBean
    {
        public string SayHi() => "Hola";
    }
}
