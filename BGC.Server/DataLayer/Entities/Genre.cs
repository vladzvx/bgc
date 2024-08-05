using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("genres")]
    public class Genre
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
