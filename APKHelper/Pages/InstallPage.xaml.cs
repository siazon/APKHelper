using APKHelper.Helpers;
using APKHelper.ViewModels;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.AppLifecycle;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKHelper.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstallPage : Page
    {
        internal InstallViewModel Provider;

        public InstallPage() { 
            InitializeComponent();

#if !DEBUG
            string _path = string.Empty;
#else
            string _path = "";// @"C:\Users\siazon\Downloads\com.tencent.mtt_12.1.5.5044_12155500.apk";
#endif
            AppActivationArguments args = AppInstance.GetCurrent().GetActivatedEventArgs();
            switch (args.Kind)
            {
                case ExtendedActivationKind.File:
                    _path = (args.Data as IFileActivatedEventArgs).Files.First().Path;
                    break;
                default:
                    break;
            }
            if (Provider == null)
                Provider = new InstallViewModel(_path, this);
            DataContext = Provider;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
#if !DEBUG
            string _path = string.Empty;
#else
            string _path = "";// @"C:\Users\siazon\Downloads\com.tencent.mtt_12.1.5.5044_12155500.apk";
#endif
            AppActivationArguments args = AppInstance.GetCurrent().GetActivatedEventArgs();
            switch (args.Kind)
            {
                case ExtendedActivationKind.File:
                    _path = (args.Data as IFileActivatedEventArgs).Files.First().Path;
                    break;
                default:
                    break;
            }
            if(Provider==null)
            Provider = new InstallViewModel(_path, this);
            DataContext = Provider;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Provider.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           switch ((sender as FrameworkElement).Name)
            {
                case "ActionButton":
                    Provider.InstallAPP();
                    break;
                case "SecondaryActionButton":
                    Provider.OpenAPP();
                    break;
                case "CancelOperationButton":
                    Application.Current.Exit();
                    break;
            }
        }

        private async void InitialLoadingUI_Loaded(object sender, RoutedEventArgs e)
        {
            await Provider.Refresh();
        }

        private  void btnOpenApkFile_Click(object sender, RoutedEventArgs e)
        {
           



            Provider.OpenFile();
        }

        private  void MoreDetailsHyperLink_Click(object sender, RoutedEventArgs e)
        {
            CacheData.Ins.mainVM.ActionVisibility = Visibility.Collapsed;


            //var uri = new Uri("myapp2:");
            //var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
   
}
