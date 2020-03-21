namespace MrCoto.BeanDiscoveryExample.Commands
{
    public interface ICrudCommand<T> where T : class
    {
        string Store(T tobject);
    }
}
