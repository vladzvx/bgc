namespace BGC.Common.Catalog.Models
{
    public class GetGamesByFilterResponse
    {
        public GameReduced[] Games { get; set; } = Array.Empty<GameReduced>();
    }
}
