namespace BGC.Common.Catalog.Models
{
    public class DataForSelection
    {
        public GameReduced[] Games { get; set; } = Array.Empty<GameReduced>();
        public Genre[] Genres { get; set; } = Array.Empty<Genre>();
        public Theme[] Themes { get; set; } = Array.Empty<Theme>();
        public Owner[] Owners { get; set; } = Array.Empty<Owner>();
        public Author[] Authors { get; set; } = Array.Empty<Author>();
        public Rating[] Ratings { get; set; } = Array.Empty<Rating>();
    }
}
