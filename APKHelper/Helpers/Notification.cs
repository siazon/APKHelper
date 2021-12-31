using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET;
using Windows.Storage;

namespace APKHelper.Helpers
{
   public class Notification
    {
        static ToastVisual visual { get; set; }
        static ToastActionsCustom actions { get; set; }
        static ToastContent toastContent { get; set; }

        static int conversationId { get; set; }
        static string image { get; set; }
        static string logo { get; set; }

        public static void send(string title, string content, string icon = null)
        {
            LoadVisual(title, content+ logo, icon); 
            LoadActions(); 
            LoadContent();

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        
        static void LoadVisual(string title, string content, string icon = null)
        {
            // In a real app, these would be initialized with actual data
             image = "https://i.bmp.ovh/imgs/2022/01/43070c2529bf6841.jpg";
             logo = ApplicationData.Current.LocalFolder.Path + @"/SplashScreen.scale-240.png";

            // Construct the visuals of the toast
            visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },

                        new AdaptiveText()
                        {
                            Text = content
                        },

                        new AdaptiveImage()
                        {
                            Source = image
                        }
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

        }

        static void LoadActions()
        {
            // In a real app, these would be initialized with actual data
            conversationId = 384928;

            // Construct the actions for the toast (inputs and buttons)
             actions = new ToastActionsCustom()
            {
                Inputs =
                    {
                        new ToastTextBox("tbReply")
                        {
                            PlaceholderContent = "Type a response"
                        }
                    },

                Buttons =
                    {
                        new ToastButton("Reply", new QueryString()
                        {
                            { "action", "reply" },
                            { "conversationId", conversationId.ToString() }

                        }.ToString())
                        {
                            ActivationType = ToastActivationType.Background,
                            ImageUri = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary + @"/logo.png",
 
                            // Reference the text box's ID in order to
                            // place this button next to the text box
                            TextBoxId = "tbReply"
                        },

                        new ToastButton("Like", new QueryString()
                        {
                            { "action", "like" },
                            { "conversationId", conversationId.ToString() }

                        }.ToString())
                        {
                            ActivationType = ToastActivationType.Background
                        },

                        new ToastButton("View", new QueryString()
                        {
                            { "action", "viewImage" },
                            { "imageUrl", image }

                        }.ToString())
                    }
            };
        }

        static void LoadContent()
        {
            // Now we can construct the final toast content
             toastContent = new ToastContent()
            {
                Visual = visual,
                Actions = actions,

                // Arguments when the user taps body of toast
                Launch = new QueryString()
                    {
                        { "action", "viewConversation" },
                        { "conversationId", conversationId.ToString() }

                    }.ToString()
            };

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());

            toast.ExpirationTime = System.DateTime.Now.AddDays(2);
            toast.Tag = "18365";
            toast.Group = "wallPosts";

        }

    }
}
