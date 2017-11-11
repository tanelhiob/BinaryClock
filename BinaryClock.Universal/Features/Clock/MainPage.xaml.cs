using Windows.UI.Xaml.Controls;
using System;
using System.Threading;

namespace BinaryClock.Universal.Features.Clock
{
    public sealed partial class MainPage : Page
    {
        private ClockViewModel _viewModel = new ClockViewModel();
        private Timer _timer;

        public MainPage()
        {
            _timer = new Timer(TimerCallback, null, 0, 1000);

            this.InitializeComponent();
            DataContext = _viewModel;
        }


        private async void TimerCallback(object state)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () => _viewModel.LoadDateTime(DateTime.Now));
        }
    }
}
