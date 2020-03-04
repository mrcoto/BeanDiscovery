using BeanDiscoveryExample.Services;
using BeanDiscoveryExampleExtra;
using Microsoft.AspNetCore.Mvc;

namespace BeanDiscoveryExample.Controllers
{
    [ApiController]
    [Route("api/magic")]
    public class MagicController : ControllerBase
    {
        private IMagicService _magicService;
        private IQueryMessage _queryMessage;

        public MagicController(IMagicService magicService, IQueryMessage queryMessage)
        {
            _magicService = magicService;
            _queryMessage = queryMessage;
        }

        [HttpGet]
        public string Magic() => _magicService.Magic() + " " + _queryMessage.Message();
    }
}