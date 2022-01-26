using APKHelper.Helpers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using System.Collections.Generic;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKHelper.Controls
{
    public sealed partial class HotInfoControl : UserControl
    {
        public HotInfoControl()
        {
            InitializeComponent();
        }
      

        private List<string> _capabilitiesList;
        public List<string> CapabilitiesList
        {
            get => _capabilitiesList;
            set
            {
                if (value != _capabilitiesList)
                {
                    _capabilitiesList = value;
                    GetTextBlock();
                }
            }
        }

        private void GetTextBlock()
        {
            if (CapabilitiesList == null) { return; }
            for (int i = 0; i < CapabilitiesList.Count; i++)
            {
                if (RichTextBlockCapabilities.Children[i] is TextBlock txt)
                {
                    txt.Text = CapabilitiesList[i];
                }
                if (i > 2) break;
            }
            for (int i = 0; i < CapabilitiesList.Count; i++)
            {
                if (infolist.Children[i] is TextBlock txt)
                {
                    txt.Text = CapabilitiesList[i];
                }
                if (i > 6) break;
            }

        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            MoreButton.Visibility = Visibility.Collapsed;
            RichTextBlockCapabilities.Visibility = Visibility.Collapsed;
          infolist.Visibility=  RichTextBlockFullCapabilities.Visibility = Visibility.Visible;
            CapabilitiesHeight.Height = new GridLength(1, GridUnitType.Star);
            _ = RichTextBlockFullCapabilities.Focus(FocusState.Pointer);
        }

        private void Root_LostFocus(object sender, RoutedEventArgs e)
        {
            MoreButton.Visibility = Visibility.Visible;
            RichTextBlockCapabilities.Visibility = Visibility.Visible;
            infolist.Visibility = RichTextBlockFullCapabilities.Visibility = Visibility.Collapsed;
            CapabilitiesHeight.Height = new GridLength(1, GridUnitType.Auto);
        }
    }
}
