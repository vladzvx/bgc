using BGC.Client.ViewModels.Common;
using ReactiveUI;
using System.Windows.Input;

namespace BGC.Client.ViewModels
{
    public class GameBrowsePage1ViewModel : GameBrowsePageBaseViewModel
    {
        public string? Title1 => GameState?.NameRu;

        internal override string[] Fields { get; set; } = { "Title1" };




        public ICommand Command { get; }
        public GameBrowsePage1ViewModel()
        {
            UpdateState(new GameState()
            {
                NameRu = "Игра престолов",
                NameEng = "Game of thrones",
                Id = 2,
            });
            Command = ReactiveCommand.Create(Act);
        }

        private void Act()
        {
            var old = GameState;
            var st = new GameState()
            {
                Id = old?.Id ?? 1,
                NameRu = old?.NameRu + "_",
                NameEng = old?.NameEng ?? string.Empty,
            };
            UpdateState(st);
        }
    }
}