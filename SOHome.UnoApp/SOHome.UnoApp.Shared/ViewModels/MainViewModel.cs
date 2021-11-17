using Microsoft.Toolkit.Mvvm.Input;

using SOHome.Common.Services;
using SOHome.UnoApp.Services;

using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOHome.UnoApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        protected IMessageService MessageService { get; }
        public ICommand LoginCommand { get; }

        public MainViewModel(IMessageService messageService)
        {
            MessageService = messageService;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            NavigationService.Navigate(typeof(DashboardPage));
            await Task.CompletedTask;
        }

        public string Message { get => MessageService.GetMessage(); }
    }
}
