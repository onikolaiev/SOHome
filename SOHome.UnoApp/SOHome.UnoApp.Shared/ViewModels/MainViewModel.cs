using SOHome.Common.Services;

namespace SOHome.UnoApp.ViewModels
{
    public class MainViewModel
    {
        protected IMessageService MessageService { get; }

        public MainViewModel(IMessageService messageService)
        {
            MessageService = messageService;
        }
        public string Message { get => MessageService.GetMessage(); }
    }
}
