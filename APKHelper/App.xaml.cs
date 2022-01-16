using APKHelper.Helpers.Exceptions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKHelper
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            UnhandledException += Application_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Getdll();
        }
        public Type Getdll()
        {
            Type type = null;
            var document = System.Xml.Linq.XDocument.Load($"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)}/Products.xml");
            string path = $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)}/APK.Datagrid.dll";


            var AllProducts = from AllProduct in document.Descendants("Assemblies") select AllProduct;
            foreach (var assembly in AllProducts)
            {
                var qualifiedInfo = assembly.Attribute("QualifiedInfo").Value;
                var className = assembly.Attribute("ConfigurationFile").Value;
                var products = from product in document.Descendants("Assembly") select product;

                foreach (var item in products)
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFile(path);
                    var name = item.Attribute("Name").Value;
                    string className1 = $"{name}.{className}";
                    var assemblyQualifiedInfo = $"{name}.{className},{name},{qualifiedInfo}";
                    type = asm.GetType(className1);
                    if (type != null)
                    {
                        //Activator.CreateInstance(type);


                        //获取类
                       // type = asm.GetType(name + ".TestPage");
                    }
                }
            }
            return type;
        }
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            RegisterExceptionHandlingSynchronizationContext();
            ResourceLoader loader = ResourceLoader.GetForViewIndependentUse();
            m_window = new MainWindow()
            {
                Title = loader.GetString("AppName")
            };
            m_window.Activate();
        }
        private void Application_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            //SettingsHelper.LogManager.GetLogger("UnhandledException").Error($"\n{e.Exception.Message}\n{e.Exception.HResult}\n{e.Exception.StackTrace}\nHelperLink: {e.Exception.HelpLink}", e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            //SettingsHelper.LogManager.GetLogger("UnhandledException").Error(e.ExceptionObject.ToString());
        }

        /// <summary>
        /// Should be called from OnActivated and OnLaunched
        /// </summary>
        private void RegisterExceptionHandlingSynchronizationContext()
        {
            ExceptionHandlingSynchronizationContext
                .Register()
                .UnhandledException += SynchronizationContext_UnhandledException;
        }

        private void SynchronizationContext_UnhandledException(object sender, APKHelper.Helpers.Exceptions.UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            //SettingsHelper.LogManager.GetLogger("UnhandledException").Error($"\n{e.Exception.Message}\n{e.Exception.HResult}(0x{Convert.ToString(e.Exception.HResult, 16)})\n{e.Exception.StackTrace}\nHelperLink: {e.Exception.HelpLink}", e.Exception);
        }
        private Window m_window;
    }
}
