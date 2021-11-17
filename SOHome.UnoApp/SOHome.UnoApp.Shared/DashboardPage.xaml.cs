using SOHome.UnoApp.Helpers;
using SOHome.UnoApp.Views;

using System;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SOHome.UnoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            this.Loaded += DashboardPageLoaded;
        }

        private void DashboardPageLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
