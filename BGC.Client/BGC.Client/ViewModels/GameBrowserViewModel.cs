using BGC.Client.ViewModels.Common;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace BGC.Client.ViewModels
{
    public class GameBrowserViewModel : ViewModelBase
    {
        #region static pointer dispatching

        private readonly static object _lock = new();
        private static PointerEventLog? _pressLog = null;
        internal static PointerEventLog? PressLog
        {
            get
            {
                lock (_lock)
                {
                    return _pressLog;
                }
            }
            set
            {
                lock (_lock)
                {
                    _pressLog = value;
                }
            }
        }

        private static Action? SetPage1Action;
        private static Action? SetPage2Action;

        internal static void SetEventLog(PointerEventLog pointerEventLog)
        {
            if (pointerEventLog.EventType == PointerEventType.Press)
            {
                PressLog = pointerEventLog;
            }
            else if (pointerEventLog.EventType == PointerEventType.Release && PressLog != null)
            {
                var dx = pointerEventLog.X - PressLog.X;
                var dt = pointerEventLog.Timestamp - PressLog.Timestamp;
                if (dt > TimeSpan.FromSeconds(0.1))
                {
                    try
                    {
                        if (dx > 30)
                        {
                            //свайп влево
                            SetPage1Action?.Invoke();
                        }
                        if (dx < -30)
                        {
                            //свайп вправо
                            SetPage2Action?.Invoke();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        #endregion


        private GameBrowsePageBaseViewModel _currentPage;
        public ICommand SetPage1Command { get; }
        public ICommand SetPage2Command { get; }

        private readonly GameBrowsePageBaseViewModel[] _pages = new GameBrowsePageBaseViewModel[2];

        public GameBrowserViewModel()
        {
            _pages[0] = new GameBrowsePage1ViewModel();
            _pages[1] = new GameBrowsePage2ViewModel(); ;

            _currentPage = _pages[0];
            SetPage1Command = ReactiveCommand.Create(SetPage1);
            SetPage2Command = ReactiveCommand.Create(SetPage2);
            SetPage1Action += SetPage1;
            SetPage2Action += SetPage2;
        }

        public GameBrowsePageBaseViewModel CurrentPage
        {
            get { return _currentPage; }
            private set { this.RaiseAndSetIfChanged(ref _currentPage, value); }
        }

        private void SetPage1()
        {
            if (CurrentPage != _pages[0])
            {
                CurrentPage = _pages[0];
            }
        }

        private void SetPage2()
        {
            if (CurrentPage != _pages[1])
            {
                CurrentPage = _pages[1];
            }
        }
    }
}