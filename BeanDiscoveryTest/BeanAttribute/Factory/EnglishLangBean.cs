using BeanDiscovery.Attributes;

namespace BeanDiscoveryTest.BeanAttribute.Factory
{
    [Bean("English")]
    class EnglishLangBean : ILangBean
    {
        public string SayHi() => "Hello";
    }
}
