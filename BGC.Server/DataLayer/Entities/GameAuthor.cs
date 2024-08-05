using System.ComponentModel.DataAnnotations.Schema;
namespace BGC.Server.DataLayer.Entities
{
    [Table("game_authors")]
    public class GameAuthor
    {
        [Column("id_game")]
        public long GameId { get; set; }

        [Column("id_author")]
        public long AuthorId { get; set; }
        public required Game Game { get; set; }
        public required Author Author { get; set; }
    }
}
