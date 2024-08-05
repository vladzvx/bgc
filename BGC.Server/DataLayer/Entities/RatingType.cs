using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("rating_types")]
    public class RatingType
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("scale")]
        public string? Scale { get; set; }
        public virtual ICollection<GameRating>? GameRatings { get; set; }
    }
}
