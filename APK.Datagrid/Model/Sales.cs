#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK.Datagrid
{
    public class Sales : INotifyPropertyChanged, IDisposable
    {
        private string _name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS1;

        /// <summary>
        /// Gets or sets the Q s1.
        /// </summary>
        /// <value>The Q s1.</value>
        public double QS1
        {
            get
            {
                return _qS1;
            }
            set
            {
                _qS1 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS2;

        /// <summary>
        /// Gets or sets the Q s2.
        /// </summary>
        /// <value>The Q s2.</value>
        public double QS2
        {
            get
            {
                return _qS2;
            }
            set
            {
                _qS2 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS3;

        /// <summary>
        /// Gets or sets the Q s3.
        /// </summary>
        /// <value>The Q s3.</value>
        public double QS3
        {
            get
            {
                return _qS3;
            }
            set
            {
                _qS3 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS4;

        /// <summary>
        /// Gets or sets the Q s4.
        /// </summary>
        /// <value>The Q s4.</value>
        public double QS4
        {
            get
            {
                return _qS4;
            }
            set
            {
                _qS4 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS5;

        /// <summary>
        /// Gets or sets the Q s5.
        /// </summary>
        /// <value>The Q s6.</value>
        public double QS5
        {
            get
            {
                return _qS5;
            }
            set
            {
                _qS5 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _qS6;

        /// <summary>
        /// Gets or sets the Q s6.
        /// </summary>
        /// <value>The Q s6.</value>
        public double QS6
        {
            get
            {
                return _qS6;
            }
            set
            {
                _qS6 = value;
                RaisePropertyChangedEvent();
            }
        }

        private double _total;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                RaisePropertyChangedEvent();
            }
        }

        private int _year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                RaisePropertyChangedEvent();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (name != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {

        }

        #endregion
    }
}
