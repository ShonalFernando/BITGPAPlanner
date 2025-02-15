using Planner.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planner.Client.View.Pages
{
    /// <summary>
    /// Interaction logic for VLEViewer.xaml
    /// </summary>
    public partial class VLEViewer : Page
    {
        WebtoolsProvider _webtoolsProvider;

        public VLEViewer()
        {
            InitializeComponent();
            _webtoolsProvider = new WebtoolsProvider();
            DataContext = _webtoolsProvider;
        }

        private void NavigateForward(object sender, RoutedEventArgs e)
        =>
            MainWebview.GoForward();
        

        private void GoBack(object sender, RoutedEventArgs e)
        =>
            MainWebview.GoBack();
        

        private void OpenWeb(object sender, RoutedEventArgs e)
        =>            MainWebview.Source = new Uri("https://www.bit.lk/");

        private void OpenVLE(object sender, RoutedEventArgs e)
        =>
            MainWebview.Source = new Uri("https://vle.bit.lk/");

        

        private void UpdateButtons(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            _webtoolsProvider.IsGoBackEnable = false;
            _webtoolsProvider.IsGoForwardEnable = false;
            _webtoolsProvider.IsVLEEnable = true;

            if (MainWebview.CanGoBack)
            {
                _webtoolsProvider.IsGoBackEnable = true;
            }

            if (MainWebview.CanGoForward)
            {
                _webtoolsProvider.IsGoForwardEnable = true;
            }

            ProgressViewer.IsIndeterminate = false;
        }

        private void StartLoader(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
            => ProgressViewer.IsIndeterminate = true;

        private void OpenPVLE(object sender, RoutedEventArgs e)
        => MainWebview.Source = new Uri("https://project.vle.bit.lk/");
    }
}
