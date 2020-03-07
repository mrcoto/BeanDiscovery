using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExampleExtra
{
    [Query]
    public class QueryMessage : IQueryMessage
    {
        public string Message() => "OK!";
    }
}
