#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#if !WinUI_Desktop
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#endif

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomValidation : Page, IDisposable
    {
        public CustomValidation()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Occurs when the CurrentCellValidating of SfDataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnSfDataGridCurrentCellValidating(object sender, Syncfusion.UI.Xaml.DataGrid.CurrentCellValidatingEventArgs args)
        {
            if (args.Column.MappingName == "Discount" && (args.NewValue == null || string.IsNullOrEmpty(args.NewValue.ToString()) || Convert.ToDouble(args.NewValue) > 40))
            {
                args.ErrorMessage = "Discount should not exceed 40 percent.";
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Occurs when the RowValidating of SfDataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnSfDataGridRowValidating(object sender, Syncfusion.UI.Xaml.DataGrid.RowValidatingEventArgs args)
        {
            var data = args.RowData as OrderInfo;
            if ((data.Expense + data.Freight) < 3000)
            {
                args.ErrorMessages.Add("Expense", "Sum of Expense and Freight should be a minimum of 3000 to be eligible for Discount.");
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
        }
    }
}
