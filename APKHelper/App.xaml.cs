using APKHelper.Helpers.Exceptions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.Windows.AppLifecycle;
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
      //  ActivationRegistrationManager.RegisterForFileTypeActivation(new string[] {"" },"", "",new string[] { "" },"");

            
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected  override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            //args.UWPLaunchActivatedEventArgs.Kind  Not this Kind
            Microsoft.Windows.AppLifecycle.AppInstance appInstance =
            Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent();
            var kind = appInstance.GetActivatedEventArgs().Kind;
          
            RegisterExceptionHandlingSynchronizationContext();
            ResourceLoader loader = ResourceLoader.GetForViewIndependentUse();
            m_window = new MainWindow()
            {
                Title = loader.GetString("AppName")
            };
            if (kind == ExtendedActivationKind.File)
            {
                m_window.OpenInstallModel(true);
            }
            else
                m_window.OpenInstallModel(false);

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
        private MainWindow m_window;
    }
}
