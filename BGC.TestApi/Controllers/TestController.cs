using BGC.Common.Catalog;
using BGC.Common.Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BGC.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;
        public TestController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [HttpGet]
        public async Task<DataForSelection> GetDataForSelection()
        {
            return await _catalogRepository.GetDataForSelection();
        }

        [HttpGet]
        public async Task<GetFullGameRespone> GetGameFull([FromQuery] long gameId)
        {
            return await _catalogRepository.GetGameFull(gameId);
        }

        [HttpPost]
        public async Task<GetFullGameRespone> UpsertGame([FromBody] GameUpsertingRequest game)
        {
            return await _catalogRepository.UpsertGame(game);
        }

        [HttpPost]
        public async Task<GetGamesByFilterResponse> GetGamesByFilter([FromBody] GamesFilter game)
        {
            return await _catalogRepository.GetGamesByFilter(game);
        }
    }
}
