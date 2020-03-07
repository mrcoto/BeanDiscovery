using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("Spanish")]
    class Spanish2LangBean : ILangBean
    {
        public string SayHi() => "Hola 2";
    }
}
