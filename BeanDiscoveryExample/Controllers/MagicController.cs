using BeanDiscoveryExample.Repositories;
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
        private ILangRepository _langRepository;

        public MagicController(
            IMagicService magicService, 
            IQueryMessage queryMessage,
            ILangRepository langRepository
        )
        {
            _magicService = magicService;
            _queryMessage = queryMessage;
            _langRepository = langRepository;
        }

        [HttpGet]
        public string Magic() => $"{_magicService.Magic()} {_queryMessage.Message()} [{_langRepository.sayHi()}]";
    }
}