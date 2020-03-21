using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Commands
{
    [Command]
    public class TodoCommand : CrudCommand<TodoObject>, ITodoCommand
    {
    }
}
