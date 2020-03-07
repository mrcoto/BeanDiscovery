using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("English")]
    class EnglishLangBean : ILangBean
    {
        public string SayHi() => "Hello";
    }
}
