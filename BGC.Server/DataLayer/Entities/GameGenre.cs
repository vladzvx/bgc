using System.ComponentModel.DataAnnotations.Schema;
namespace BGC.Server.DataLayer.Entities
{
    [Table("game_genres")]
    public class GameGenre
    {
        [Column("id_game")]
        public long GameId { get; set; }

        [Column("id_genre")]
        public long GenreId { get; set; }
        public required Game Game { get; set; }
        public required Genre Genre { get; set; }
    }
}
