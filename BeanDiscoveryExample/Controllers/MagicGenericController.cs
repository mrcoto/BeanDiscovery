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
        private TodoObject _todo;

        public MagicGenericController(
            ICrudCommand<TodoObject> crudTodoCommand,
            ITodoCommand todoCommand
        )
        {
            _crudTodoCommand = crudTodoCommand;
            _todoCommand = todoCommand;
            _todo = new TodoObject();
        }

        [HttpGet]
        public string Magic() => $"{_crudTodoCommand.Store(_todo)} {_todoCommand.Store(_todo)}";
    }
}
