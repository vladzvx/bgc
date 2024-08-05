using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("game_ratings")]
    public class GameRating
    {
        [Column("id_game")]
        public long GameId { get; set; }

        [Column("id_rating_type")]
        public long RatingTypeId { get; set; }

        [Column("rating")]
        public decimal Rating { get; set; }
        public Game? Game { get; set; }
        public RatingType? RatingType { get; set; }
    }
}
