namespace BGC.Common.Catalog.Models
{
    public class GameReduced
    {
        public long Id { get; set; }
        public string NameRu { get; set; } = string.Empty;
        public string NameEng { get; set; } = string.Empty;
        private DateTime? IssueDate { get; set; }
        public int PlayersMin { get; set; } = 1;
        public int? PlayersMax { get; set; }
        public int AgeMin { get; set; } = 1;
        public int? AgeMax { get; set; }
        public TimeSpan? GameDurationMin { get; set; }
        public TimeSpan? GameDurationMax { get; set; }
    }
}
