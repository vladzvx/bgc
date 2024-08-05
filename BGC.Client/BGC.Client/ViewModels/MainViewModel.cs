using ReactiveUI;
using System.Windows.Input;

namespace BGC.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ICommand LoginCommand { get; }

        private readonly ViewModelBase[] _views = new ViewModelBase[3];

        public MainViewModel()
        {
            LoginCommand = ReactiveCommand.Create(Login);
            var login = new LoginViewModel()
            {
                LoginCommand = LoginCommand,
            };
            _views[1] = login;
            _views[0] = new GamesTableViewModel();
            _views[2] = new GameBrowserViewModel();
            _currentView = _views[0];
        }

        public ViewModelBase CurrentScreen
        {
            get { return _currentView; }
            private set { this.RaiseAndSetIfChanged(ref _currentView, value); }
        }

        private void Login()
        {
            if (CurrentScreen != _views[1])
            {
                CurrentScreen = _views[1];
            }
        }
    }
}
