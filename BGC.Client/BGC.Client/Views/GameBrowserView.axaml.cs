using Avalonia.Controls;
using Avalonia.Input;
using BGC.Client.ViewModels;

namespace BGC.Client.Views
{
    public partial class GameBrowserView : UserControl
    {
        public GameBrowserView()
        {
            InitializeComponent();

            this.PointerPressed += OnPointerPressed;
            this.PointerReleased += OnPointerReleased;
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var p = e.GetPosition(null);
            GameBrowserViewModel.SetEventLog(new ViewModels.Common.PointerEventLog()
            {
                EventType = ViewModels.Common.PointerEventType.Press,
                X = p.X,
                Y = p.Y,
            });
        }

        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            var p = e.GetPosition(null);
            GameBrowserViewModel.SetEventLog(new ViewModels.Common.PointerEventLog()
            {
                EventType = ViewModels.Common.PointerEventType.Release,
                X = p.X,
                Y = p.Y,
            });
        }
    }
}