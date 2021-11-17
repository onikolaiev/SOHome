using SOHome.UnoApp.Services;
using SOHome.UnoApp.Views;

namespace SOHome.UnoApp.ViewModels
{
    public class ViewModelBase
    {
        private static NavigationServiceEx _instance;
        public static NavigationServiceEx NavigationService
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NavigationServiceEx();
                    _instance.Configure(typeof(DashboardPage));
                    _instance.Configure(typeof(ProfilePage));
                    _instance.Configure(typeof(ProductPage));
                }
                return _instance;
            }
        }
    }
}
