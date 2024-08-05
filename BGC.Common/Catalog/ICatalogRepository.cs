using BGC.Common.Catalog.Models;

namespace BGC.Common.Catalog
{
    public interface ICatalogRepository
    {
        public Task<GetGamesByFilterResponse> GetGamesByFilter(GamesFilter filter);
        public Task<GetFullGameRespone> GetGameFull(long ig);
        public Task<DataForSelection> GetDataForSelection();
        public Task<GetFullGameRespone> UpsertGame(GameUpsertingRequest gameFull);
    }
}
