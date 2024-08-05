using System.ComponentModel.DataAnnotations.Schema;
namespace BGC.Server.DataLayer.Entities
{
    [Table("game_collection")]
    public class GameOwner
    {
        [Column("id_game")]
        public long GameId { get; set; }

        [Column("id_owner")]
        public long OwnerId { get; set; }
        public required Game Game { get; set; }
        public required Owner Owner { get; set; }
    }
}
