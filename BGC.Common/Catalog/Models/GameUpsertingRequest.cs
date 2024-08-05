namespace BGC.Common.Catalog.Models
{
    public class GameUpsertingRequest : GameReduced
    {
        public long[] GenresIds { get; set; } = Array.Empty<long>();
        public long[] ThemesIds { get; set; } = Array.Empty<long>();
        public long[] OwnersIds { get; set; } = Array.Empty<long>();
        public long[] AuthorsIds { get; set; } = Array.Empty<long>();
        public Rating[] Ratings { get; set; } = Array.Empty<Rating>();
    }
}
