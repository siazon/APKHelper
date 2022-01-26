using APKServer;
using APKServer.Models;
using AdvancedSharpAdbClient;
using AdvancedSharpAdbClient.DeviceCommands;
using APKHelper.Controls.Dialogs;
using APKHelper.Helpers;
using APKHelper.Pages;
using APKHelper.Pages.SettingsPages;
using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PortableDownloader;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.System;
using System.Collections;
using APKHelper.Pages.ToolsPages;
using APKCommon;
using System.Xml.Linq;
using System.Reflection;

namespace APKHelper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        public List<object> RootMenuItems { get; } = new List<object>();
        private IList menuItems;
        public IList MenuItems
        {
            get { return menuItems; }
            private set
            {
                menuItems = value;
                RaisePropertyChanged(nameof(MenuItems));
            }
        }
        private object selectedRootMenuItem;
        public object SelectedRootMenuItem
        {
            get { return selectedRootMenuItem; }
            set
            {
                selectedRootMenuItem = value;
                RaisePropertyChanged(nameof(SelectedRootMenuItem));
                RootMenuItemSelectionChanged();
            }
        }
       
        private bool isThemeVisible;
        public bool IsThemeVisible
        {
            get { return isThemeVisible; }
            set
            {
                isThemeVisible = value;
                RaisePropertyChanged(nameof(IsThemeVisible));
            }
        }
        private string _AppTitleText;

        public string AppTitleText
        {
            get { return _AppTitleText; }
            set { _AppTitleText = value;
                RaisePropertyChanged(nameof(AppTitleText));
            }
        }
        private Visibility _actionVisibility;
        public Visibility ActionVisibility
        {
            get => _actionVisibility;
            set
            {

                _actionVisibility = value;
                RaisePropertyChanged(nameof(ActionVisibility));
            }
        }

        private DemoInfo demoInfo;
        public DemoInfo DemoInfo
        {
            get { return demoInfo; }
            set
            {
                demoInfo = value;
                RaisePropertyChanged(nameof(DemoInfo));
            }
        }
        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaisePropertyChanged(nameof(SelectedItem));
                    this.OnNavigationSelectionChanged();
                }
            }
        }
        private bool isHeaderVisible;
        public bool IsHeaderVisible
        {
            get { return isHeaderVisible; }
            set
            {
                isHeaderVisible = value;
                RaisePropertyChanged(nameof(IsHeaderVisible));
                IsSectionHeaderVisible = isHeaderVisible;
            }
        }
        private string header;
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }
        public bool IsSectionHeaderVisible { get; set; }
        public string SectionHeader { get; set; }
        private readonly ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("InstallPage");

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (name != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        }
        MainPage _page;
        // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        public MainViewModel(MainPage Page)
        {
            _page=Page;
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            // Dispose(disposing: false);
            InitiateDefaultValues();
        }
        private void InitiateDefaultValues()
        {
            RootMenuItems.Add(new BrowserModel() { Content = _loader.GetString("HomePage"), Name = _loader.GetString("HomePage"), Icon = "\uE10F" });
            if (DemoHelper.ShowCaseDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.Showcase, Name = Constants.Showcase, Icon = "\uE722" });

            RootMenuItems.Add(new BrowserModel() { Content = _loader.GetString("WebPage"), Name = _loader.GetString("WebPage"), Icon = "\uE8FD" });

            if (DemoHelper.WhatsNewDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.WhatsNew, Name = Constants.WhatsNewName, Icon = "\uE789" });

            this.MenuItems = DemoHelper.ControlInfos;
        }
    
        private void RootMenuItemSelectionChanged()
        {
            //Type type = Getdll();
            if (this.SelectedRootMenuItem == null)
            {
                return;
            }
            this.IsThemeVisible = false;
            this.SelectedItem = null;
            this.DemoInfo = null;

            var selectedItem = this.SelectedRootMenuItem as BrowserModel;
            if (selectedItem.Content.ToString() == _loader.GetString("HomePage"))
            {
                this.SectionHeader = Constants.Home;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SearchPage), this);
            }
           else if (selectedItem.Content.ToString() == _loader.GetString("WebPage"))
            {
                this.SectionHeader = Constants.Showcase;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(WebViewPage), this);
            }
            else if (selectedItem.Content.ToString() == Constants.AllControls || selectedItem.Content.ToString() == Constants.WhatsNew)
            {
                this.SectionHeader = selectedItem.Content.ToString() == Constants.AllControls ? Constants.AllControlsName : Constants.WhatsNewName;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(WebViewPage), this);
            }

            this.MenuItems = DemoHelper.ControlInfos;
        }
        private void OnNavigationSelectionChanged()
        {
            //Type type = Getdll();


            if (this.SelectedItem == null)
                return;

            this.SelectedRootMenuItem = null;

            if (this.SelectedItem is ControlInfo controlInfo)
            {
                this.IsThemeVisible = false;
                this.Header = controlInfo.Name;
                //this.IsHeaderVisible = true;
                NavigationService.Frame.Navigate(typeof(SearchPage));

            }
            else if (this.SelectedItem is DemoInfo demoInfo)
            {
                this.Header = demoInfo.Name;
                //this.IsHeaderVisible = true;
                this.IsThemeVisible = true;
                this.DemoInfo = demoInfo;
                NavigationService.Frame.Navigate(typeof(SearchPage), this);
            }
            else if ((this.SelectedItem as NavigationViewItem).Content.ToString() == Constants.Settings|| (this.SelectedItem as NavigationViewItem).Content.ToString()=="设置")
            {
                this.Header = Constants.Settings;
                this.IsThemeVisible = false;
                //this.IsHeaderVisible = true;
                NavigationService.Frame.Navigate(typeof(SettingsPage), this);
            }
        }

        public Type Getdll()
        {
            Type type = null;
            var document = XDocument.Load($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)}/Products.xml");
            string path = $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)}/APK.Datagrid.dll";


            var AllProducts = from AllProduct in document.Descendants("Assemblies") select AllProduct;
            foreach (var assembly in AllProducts)
            {
                var qualifiedInfo = assembly.Attribute("QualifiedInfo").Value;
                var className = assembly.Attribute("ConfigurationFile").Value;
                var products = from product in document.Descendants("Assembly") select product;

                foreach (var item in products)
                {
                    Assembly asm = Assembly.LoadFile(path);
                    var name = item.Attribute("Name").Value;
                    string className1 = $"{name}.{className}";
                    var assemblyQualifiedInfo = $"{name}.{className},{name},{qualifiedInfo}";
                    type = asm.GetType(className1);
                    if (type != null)
                    {
                        //Activator.CreateInstance(type);


                        //获取类
                        type = asm.GetType(name + ".TestPage");
                    }
                }
            }
            return type;
        }



        protected virtual void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}