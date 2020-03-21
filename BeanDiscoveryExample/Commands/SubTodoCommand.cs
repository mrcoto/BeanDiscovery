using MrCoto.BeanDiscovery.Attributes;

namespace MrCoto.BeanDiscoveryExample.Commands
{
    [Command]
    public class SubTodoCommand : ISubTodoCommand
    {
        public string Store(TodoObject tobject) => "SubTodoCommand.Store()";
    }
}
