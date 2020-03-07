using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("Spanish")]
    class Spanish2LangBean : ILangBean
    {
        public string SayHi() => "Hola 2";
    }
}
