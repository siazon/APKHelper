using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Windows.Storage;

namespace APKUWPHelper.Helpers
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


            string image = "https://picsum.photos/364/202?image=883";
            int conversationId = 5;
            new ToastContentBuilder()

              // Arguments that are returned when the user clicks the toast or a button
              .AddArgument("action", MyToastActions.ViewConversation)
              .AddArgument("conversationId", conversationId)

              // Visual content
              .AddText(title)
              .AddText(content)
              .AddInlineImage(new Uri("https://i.bmp.ovh/imgs/2022/01/43070c2529bf6841.jpg"))
              .AddAppLogoOverride(new Uri("https://unsplash.it/64?image=1005"), ToastGenericAppLogoCrop.Circle)

              // Text box for typing a reply
              .AddInputTextBox("tbReply", "Type a reply")

              // Buttons
              .AddButton(new ToastButton()
                  .SetContent("Reply")
                  .AddArgument("action", MyToastActions.Reply)
                  .SetBackgroundActivation())

              .AddButton(new ToastButton()
                  .SetContent("Like")
                  .AddArgument("action", MyToastActions.Like)
                  .SetBackgroundActivation())

              .AddButton(new ToastButton()
                  .SetContent("View")
                  .AddArgument("action", MyToastActions.ViewImage)
                  .AddArgument("imageUrl", image))

              // And show the toast!
              .Show();


        }
        
      

    }

    public enum MyToastActions
    {
        /// <summary>
        /// View the conversation
        /// </summary>
        ViewConversation,

        /// <summary>
        /// Inline reply to a message
        /// </summary>
        Reply,

        /// <summary>
        /// Like a message
        /// </summary>
        Like,

        /// <summary>
        /// View the image included in the message
        /// </summary>
        ViewImage
    }
}
