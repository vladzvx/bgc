using System.Windows.Input;

namespace BGC.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; init; }
    }
}