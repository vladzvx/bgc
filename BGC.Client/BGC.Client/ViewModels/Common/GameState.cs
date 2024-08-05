using System;

namespace BGC.Client.ViewModels.Common
{
    public class GameState
    {
        public long Id { get; set; }
        public string NameRu { get; init; } = string.Empty;
        public string NameEng { get; init; } = string.Empty;
        private DateTime? IssueDate { get; init; }
        public int PlayersMin { get; init; } = 1;
        public int? PlayersMax { get; init; }
        public int AgeMin { get; init; } = 1;
        public int? AgeMax { get; init; }
        public TimeSpan? GameDurationMin { get; init; }
        public TimeSpan? GameDurationMax { get; init; }
    }
}
