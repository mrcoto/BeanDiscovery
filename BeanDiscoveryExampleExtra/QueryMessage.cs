using BeanDiscovery.Attributes;

namespace BeanDiscoveryExampleExtra
{
    [Query]
    public class QueryMessage : IQueryMessage
    {
        public string Message() => "OK!";
    }
}
