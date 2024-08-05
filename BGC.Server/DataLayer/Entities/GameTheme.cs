using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("game_themes")]
    public class GameTheme
    {
        [Column("id_game")]
        public long GameId { get; set; }

        [Column("id_theme")]
        public long ThemeId { get; set; }
        public required Game Game { get; set; }
        public required Theme Theme { get; set; }
    }
}
