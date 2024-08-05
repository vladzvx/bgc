using System.ComponentModel.DataAnnotations.Schema;

namespace BGC.Server.DataLayer.Entities
{
    [Table("authors")]
    public class Author
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<GameAuthor> GameAuthors { get; set; } = new List<GameAuthor>();
    }
}
