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

namespace APKHelper.Controls
{
    public sealed partial class FeatureButton : UserControl
    {
        private string _SubTitle;

        public string SubTitle
        {
            get { return _SubTitle; }
            set { _SubTitle = value;  
            txt.Text=value;
            }
        }
        private string _PicUrl;

        public string PicUrl
        {
            get { return _PicUrl; }
            set {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri(img.BaseUri, value);
                img.Source = bitmapImage;
                _PicUrl = value; }
        }
        private int _imgHeight;

        public int Imgheight
        {
            get { return _imgHeight; }
            set {
                grid.Height = value;
                _imgHeight = value; }
        }
        private Thickness _marge;

        public Thickness ImgMarge
        {
            get { return _marge; }
            set { 
                grid.Margin= value;
                _marge = value; }
        }


        public FeatureButton()
        {
            this.InitializeComponent();
        }
    }
}
