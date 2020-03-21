using Microsoft.AspNetCore.Mvc;
using MrCoto.BeanDiscoveryExample.Commands;

namespace MrCoto.BeanDiscoveryExample.Controllers
{
    [ApiController]
    [Route("api/magic_generic")]
    public class MagicGenericController
    {
        private ICrudCommand<TodoObject> _crudTodoCommand;
        private ITodoCommand _todoCommand;
        private ISubTodoCommand _subTodoCommand;
        private TodoObject _todo;

        public MagicGenericController(
            ICrudCommand<TodoObject> crudTodoCommand,
            ITodoCommand todoCommand,
            ISubTodoCommand subTodoCommand
        )
        {
            _crudTodoCommand = crudTodoCommand;
            _todoCommand = todoCommand;
            _subTodoCommand = subTodoCommand;
            _todo = new TodoObject();
        }

        [HttpGet]
        public string Magic() => $"{_crudTodoCommand.Store(_todo)} {_todoCommand.Store(_todo)} {_subTodoCommand.Store(_todo)}";
    }
}
