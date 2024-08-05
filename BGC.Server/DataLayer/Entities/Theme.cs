using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("themes")]
    public class Theme
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
        public virtual ICollection<GameTheme> GameThemes { get; set; } = new List<GameTheme>();
    }
}
