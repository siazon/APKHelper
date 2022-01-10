﻿using APKUWPHelper.Helpers;
using Microsoft.UI.Xaml;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace APKUWPHelper.Controls
{
    public sealed partial class CapabilitiesInfoControl : UserControl
    {
        public CapabilitiesInfoControl()
        {
            InitializeComponent();



        }
        public string HeadText
        {
            get => HeaderTextBlock.Text;
            set => HeaderTextBlock.Text = value ?? string.Empty;
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
            CapabilitiesInfoControl con=new CapabilitiesInfoControl();  


            if (CapabilitiesList == null) { return; }
            foreach (string capability in CapabilitiesList)
            {
                if (!string.IsNullOrEmpty(capability))
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(new Run { Text = $"• {capability.GetPermissionName()}" });
                    RichTextBlockFullCapabilities.Blocks.Add(paragraph);
                }
                if (RichTextBlockCapabilities.Blocks.Count < 3 && !string.IsNullOrEmpty(capability))
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(new Run { Text = $"• {capability.GetPermissionName()}" });
                    RichTextBlockCapabilities.Blocks.Add(paragraph);
                }
            }
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            MoreButton.Visibility = Visibility.Collapsed;
            Root.BorderThickness = new Thickness(1, 0, 0, 0);
            RichTextBlockCapabilities.Visibility = Visibility.Collapsed;
            RichTextBlockFullCapabilities.Visibility = Visibility.Visible;
            CapabilitiesHeight.Height = new GridLength(1, GridUnitType.Star);
            _ = RichTextBlockFullCapabilities.Focus(FocusState.Pointer);
        }

        private void Root_LostFocus(object sender, RoutedEventArgs e)
        {
            MoreButton.Visibility = Visibility.Visible;
            Root.BorderThickness = new Thickness(0, 0, 0, 0);
            RichTextBlockCapabilities.Visibility = Visibility.Visible;
            RichTextBlockFullCapabilities.Visibility = Visibility.Collapsed;
            CapabilitiesHeight.Height = new GridLength(1, GridUnitType.Auto);
        }
    }
}
