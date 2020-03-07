using MrCoto.BeanDiscoveryExample.Queries;
using MrCoto.BeanDiscoveryExample.Repositories;
using MrCoto.BeanDiscoveryExample.Services;
using MrCoto.BeanDiscoveryExampleExtra;
using Microsoft.AspNetCore.Mvc;

namespace MrCoto.BeanDiscoveryExample.Controllers
{
    [ApiController]
    [Route("api/magic")]
    public class MagicController : ControllerBase
    {
        private IMagicService _magicService;
        private IQueryMessage _queryMessage;
        private ILangRepository _langRepository;
        private PowerfulQuery _powerfulQuery;

        public MagicController(
            IMagicService magicService, 
            IQueryMessage queryMessage,
            ILangRepository langRepository,
            PowerfulQuery powerfulQuery
        )
        {
            _magicService = magicService;
            _queryMessage = queryMessage;
            _langRepository = langRepository;
            _powerfulQuery = powerfulQuery;
        }

        [HttpGet]
        public string Magic() => $"{_magicService.Magic()} {_queryMessage.Message()} [{_langRepository.sayHi()}] [{_powerfulQuery.power()}]";
    }
}