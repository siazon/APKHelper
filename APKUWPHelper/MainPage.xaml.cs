﻿using APKUWPHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace APKUWPHelper
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainWindows : Page
    {
        InstallViewModel Provider;
        public MainWindows()
        {
            this.InitializeComponent();
            this.Loaded += MainWindows_Loaded;
           
        }

        private async void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            string _path = @"C:\Users\siazon\Downloads\com.tencent.mtt_12.1.5.5044_12155500.apk";
            Provider = new InstallViewModel(_path, this);
            await Provider.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Provider.InstallAPP();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Provider.OpenAPP();
        }
    }
}
