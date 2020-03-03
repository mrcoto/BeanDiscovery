using BeanDiscoveryExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeanDiscoveryExample.Controllers
{
    [ApiController]
    [Route("api/magic")]
    public class MagicController : ControllerBase
    {
        private IMagicService _magicService;

        public MagicController(IMagicService magicService)
        {
            _magicService = magicService;
        }

        [HttpGet]
        public string Magic() => _magicService.Magic();
    }
}