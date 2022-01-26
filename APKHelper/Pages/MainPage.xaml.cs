using APKCommon;
using APKHelper.Helpers;
using APKHelper.Pages.SettingsPages;
using APKHelper.Pages.ToolsPages;
using APKHelper.ViewModels;
using CommunityToolkit.WinUI.Helpers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        bool InstallModel = false;
        private bool HasBeenSmail;
        public Frame frame;
        MainViewModel Provider;

   

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            NavigationService.Frame = CoreAppFrame;
            Provider = new MainViewModel(this);
            DataContext = CacheData.Ins.mainVM = Provider;
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

            //CoreAppFrame.Navigate(typeof(InstallPage));
            // borInstall.Child = new InstallPage();
        }

        private void Frame_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            BasePage page = e.Content as BasePage;
            if (page != null)
                tbTitle.Text = page.Title;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (InstallModel)
                CoreAppFrame.Navigate(typeof(InstallPage));
            else
                CoreAppFrame.Navigate(typeof(SearchPage));
            CoreAppFrame.Navigated += Frame_Navigated;
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

        private void NavigationViewControl_PaneOpened(NavigationView sender, object args)
        {

            UpdateAppTitleMargin(sender);
        }

        private void NavigationViewControl_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            UpdateAppTitleMargin(sender);
        }
        private void UpdateAppTitleMargin(NavigationView sender)
        {
            const int smallLeftIndent = 0, largeLeftIndent = 34;

            //AppTitle.TranslationTransition = new Vector3Transition();

            //if (sender.IsPaneOpen == false && (sender.DisplayMode == NavigationViewDisplayMode.Expanded ||
            //    sender.DisplayMode == NavigationViewDisplayMode.Compact))
            //{
            //    AppTitle.Translation = new System.Numerics.Vector3(largeLeftIndent, 0, 0);
            //}
            //else
            //{
            //    AppTitle.Translation = new System.Numerics.Vector3(smallLeftIndent, 0, 0);
            //}
        }
        private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {

        }
        public void OpenInstallModel(bool isInstall)
        {
            InstallModel = isInstall;
            //if (isInstall)
            //    Provider.ActionVisibility = Visibility.Visible;
            //else
            //    Provider.ActionVisibility = Visibility.Collapsed;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CoreAppFrame.CanGoBack)
                CoreAppFrame.GoBack();
        }
    }
}
