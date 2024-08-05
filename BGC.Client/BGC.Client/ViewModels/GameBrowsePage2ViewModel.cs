namespace BGC.Client.ViewModels
{
    public class GameBrowsePage2ViewModel : GameBrowsePage1ViewModel
    {
        public string? Title2 => GameState?.NameEng;

        internal override string[] Fields { get; set; } = { "Title2" };
    }
}