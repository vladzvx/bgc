using BGC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGC.Client.ViewModels.Common
{
    public class GameForTable
    {
        public string Name => NameRu ?? NameEng;
        public string Age => DataConverter.GetAge(AgeMin, AgeMax);
        public string Players => DataConverter.GetPlayers(PlayersMin, PlayersMax);
        public string Duration => DataConverter.GetDuration(GameDurationMin, GameDurationMax);


        public long Id { get; init; }
        public string NameRu { get; init; } = string.Empty;
        public string NameEng { get; init; } = string.Empty;
        public int PlayersMin { get; init; } = 1;
        public int? PlayersMax { get; init; }
        public int AgeMin { get; init; } = 1;
        public int? AgeMax { get; init; }
        public TimeSpan? GameDurationMin { get; init; }
        public TimeSpan? GameDurationMax { get; init; }
    }
}
