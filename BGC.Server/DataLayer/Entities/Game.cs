using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("games")]
    public class Game
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name_ru")]
        public string NameRu { get; set; } = string.Empty;

        [Column("name_eng")]
        public string NameEng { get; set; } = string.Empty;

        [Column("issue_date")]
        public DateTime? IssueDate { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }

        [Column("players_min")]
        public int PlayersMin { get; set; } = 1;

        [Column("players_max")]
        public int? PlayersMax { get; set; }

        [Column("age_min")]
        public int AgeMin { get; set; } = 1;

        [Column("age_max")]
        public int? AgeMax { get; set; }

        [Column("game_time_min")]
        public TimeSpan? GameDurationMin { get; set; }

        [Column("game_time_max")]
        public TimeSpan? GameDurationMax { get; set; }
        public virtual ICollection<Theme> Themes { get; set; } = new List<Theme>();
        public virtual ICollection<GameTheme> GameThemes { get; set; } = new List<GameTheme>();
        public virtual ICollection<GameRating> GameRatings { get; set; } = new List<GameRating>();
        public virtual ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<GameAuthor> GameAuthors { get; set; } = new List<GameAuthor>();
        public ICollection<Owner> Owners { get; set; } = new List<Owner>();
        public ICollection<GameOwner> GameOwners { get; set; } = new List<GameOwner>();
    }
}
