using APKHelper.Helpers;
using APKHelper.Pages.SettingsPages;
using APKHelper.Pages.ToolsPages;
using CommunityToolkit.WinUI.Helpers;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKHelper.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool HasBeenSmail;

        public MainPage()
        {
            InitializeComponent();
            UIHelper.MainPage = this;
            UIHelper.DispatcherQueue = DispatcherQueue.GetForCurrentThread();
            if (UIHelper.HasTitleBar)
            {
                UIHelper.MainWindow.ExtendsContentIntoTitleBar = true;
            }
            else
            {
                CustomTitleBar.HorizontalAlignment = HorizontalAlignment.Stretch;
                AppWindow AppWindow = UIHelper.GetAppWindowForCurrentWindow();
                AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
                UIHelper.CheckTheme();
            }
            UIHelper.MainWindow.SetTitleBar(CustomTitleBar);
            _ = CoreAppFrame.Navigate(typeof(InstallPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as FrameworkElement).Name)
            {
                case "AboutButton":
                    _ = CoreAppFrame.Navigate(typeof(SettingsPage));
                    break;
                default:
                    break;
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (UIHelper.HasTitleBar)
                {
                    if (XamlRoot.Size.Width <= 240)
                    {
                        if (!HasBeenSmail)
                        {
                            HasBeenSmail = true;
                            UIHelper.MainWindow.SetTitleBar(null);
                        }
                    }
                    else if (HasBeenSmail)
                    {
                        HasBeenSmail = false;
                        UIHelper.MainWindow.SetTitleBar(CustomTitleBar);
                    }
                    CustomTitleBar.Width = XamlRoot.Size.Width - 120;
                }
            }
            catch { }
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            switch ((args.SelectedItem as NavigationViewItem).Content.ToString())
            {
                case "安装":
                    CoreAppFrame.Navigate(typeof(InstallPage));
                    break;
                case "应用":
                    CoreAppFrame.Navigate(typeof(ApplicationsPage));
                    break;
                case "正在运行":
                    CoreAppFrame.Navigate(typeof(ApplicationsPage));
                    break;
                case "文件":
                    CoreAppFrame.Navigate(typeof(ProcessesPage));
                    break;
                case "设备":
                    CoreAppFrame.Navigate(typeof(ApplicationsPage));
                    break;
                case "设置":
                    CoreAppFrame.Navigate(typeof(SettingsPage));
                    break;
            }
        }
    }
}
