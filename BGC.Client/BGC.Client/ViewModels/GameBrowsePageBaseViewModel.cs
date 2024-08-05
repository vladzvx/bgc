using BGC.Client.ViewModels.Common;
using ReactiveUI;
using System;

namespace BGC.Client.ViewModels
{
    public class GameBrowsePageBaseViewModel : ViewModelBase
    {
        public GameState? GameState { get; private set; }

        public void UpdateState(GameState gameState)
        {
            GameState = gameState;
            foreach (var field in Fields)
            {
                this.RaisePropertyChanged(field);
            }
        }

        internal virtual string[] Fields { get; set; } = Array.Empty<string>();
    }
}