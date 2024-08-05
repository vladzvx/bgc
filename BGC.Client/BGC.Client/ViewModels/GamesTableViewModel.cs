using BGC.Client.ViewModels.Common;
using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using Avalonia.Controls;

namespace BGC.Client.ViewModels
{
    public class GamesTableViewModel : ViewModelBase
    {
        public ObservableCollection<GameForTable> Games { get;}

        public GamesTableViewModel()
        {

            var gameForTables = new GameForTable[]
            {
                new GameForTable(){NameRu = "Game1", Id=1},
                new GameForTable(){NameRu = "Game2", Id=2},
                new GameForTable(){NameRu = "Game3", Id=3}
            };
            Games = new ObservableCollection<GameForTable>(gameForTables);
        }
    }
}