using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WMTPresentation.Menu;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WMTPresentation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MenuGrid_Tapped(null, null);
        }

        private void MenuGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuItem menu = LeftMenu.SelectedItem as MenuItem;

            if (menu != null)
            {
                if (menu.NavigateTo != null)
                {
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { ContentFrame.Navigate(menu.NavigateTo); });
                }
            }
        }
    }
}
