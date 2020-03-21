using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Commands
{
    [Command]
    public class CrudCommand<T> : ICrudCommand<T> where T : class
    {
        public string Store(T tobject) => $"Store {tobject.GetType().Name}";
    }
}
