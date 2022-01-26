using APKCommon;
using APKHelper.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKHelper.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page, INotifyPropertyChanged, BasePage
    {
        private string _imageuri = @"D:\SourceCode\APK\APKHelper\APKHelper (Package)\bin\x64\Debug\AppX\APKHelper\Assets\Image\system.png";
        public string Title => "APK 文件安装程序";
        public string imageuri
        {
            get { return _imageuri; }
            set { _imageuri = value; RaisePropertyChangedEvent(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (name != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        }

        public SearchPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.Loaded += SearchPage_Loaded;
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            imageuri = @"/Assets/Images/game.png";
            btnInstall.PicUrl = @"/Assets/Images/gift.png";
            btnInstall.SubTitle = "Installer";
            btnInstall.Height = 100;

            btnSetting.PicUrl = @"/Assets/Images/relax.png";
            btnSetting.SubTitle = "DeviceManager";
            btnSetting.Height = 100;

            btnADBSetting.PicUrl = @"/Assets/Images/game.png";
            btnADBSetting.SubTitle = "Settings";
            btnADBSetting.Height = 100;

            btnMore.PicUrl = @"/Assets/Images/list.png";
            btnMore.SubTitle = "More";
            btnMore.Height = 100;
            FeatureButton btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/baidu.png",
                SubTitle = "baidu"

            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);

            btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/qq.png",
                SubTitle = "qq"
            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);

            btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/alipay.png",
                SubTitle = "alipay"
            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);
            btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/tiktok.png",
                SubTitle = "tiktok"
            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);

            btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/didi.png",
                SubTitle = "didi"
            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);

            btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"/Assets/Images/plus.png",
                SubTitle = "add"
            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Add(btn);
            List<string> strlist = new List<string>();
            strlist.Add("开端烂尾");
            strlist.Add("微信小老虎");
            strlist.Add("加班文化为何屡禁不止");
            strlist.Add("奥米克戎的妹妹");
            strlist.Add("南方小年仪式感");
            strlist.Add("中亚五国建交30周年");
            strlist.Add("男子回家相亲排除1小时");
            strlist.Add("吃瓜吃到自己身上");
            AppCapabilities.CapabilitiesList = strlist;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
          

            //BitmapImage bitmapImage = new BitmapImage();
            //bitmapImage.UriSource = new Uri(img.BaseUri, "/Assets/Images/RoundCorner.png");
            //img.Source = bitmapImage;
            //btnSetting.PicUrl = @"/Assets/Images/RoundCorner.png";

        }

        private void Btn_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            FeatureButton btn = new FeatureButton()
            {
                Height = 60,
                ImgMarge = new Thickness(10, 0, 10, 0),
                PicUrl = @"https://mat1.gtimg.com/qqcdn/qqindex2021/favicon.ico",
                SubTitle = "tencent"

            };
            btn.PointerPressed += Btn_PointerPressed;
            HotApp.Children.Insert(HotApp.Children.Count-1, btn);
        }

        private void btnInstall_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var temo = NavigationService.Frame.CanGoBack;
            switch (((UserControl)sender).Name)
            {
                case "btnInstall":
                    NavigationService.Frame.Navigate(typeof(InstallPage));
                    break;
                case "btnSetting":
                    NavigationService.Frame.Navigate(typeof(SettingsPages.SettingsPage));
                    break;
                case "btnADBSetting":
                    NavigationService.Frame.Navigate(typeof(ToolsPages.ApplicationsPage));
                    break;
                case "btnMore":
                    NavigationService.Frame.Navigate(typeof(SettingsPages.WebViewPage));
                    break;
                default:
                    break;
            }
        }
    }
}
