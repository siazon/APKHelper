#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
#if WinUI_Desktop
using System.ComponentModel;
#endif

namespace APK.Datagrid
{
    public class Employee :  INotifyPropertyChanged, IDisposable
    {
        private double _EmployeeID;
        private string _Name;
        private int _age;
        private string _designation;
        private string _location;
        private long _NationalIDNumber;
        private int _ContactID;
        private string _LoginID;
        private int _ManagerID;
        private string _Title;
        private DateTimeOffset _BirthDate;
        private string _MaritalStatus;
        private string _Gender;
        private DateTimeOffset _HireDate;
        private int _SickLeaveHours;
        private double _Salary;
        private bool employeeStatus;
        private int _rating;
        private string _email;
        private string _contactnos;
        private string _city;
        private DateTimeOffset? _CheckInTime;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public double EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public long NationalIDNumber
        {
            get
            {
                return this._NationalIDNumber;
            }
            set
            {
                this._NationalIDNumber = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the Designation.
        /// </summary>
        /// <value>The designation.</value>
        public string Designation
        {
            get
            {
                return this._designation;
            }
            set
            {
                this._designation = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public int ContactID
        {
            get
            {
                return this._ContactID;
            }
            set
            {
                this._ContactID = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the BirthDate.
        /// </summary>
        /// <value>The BirthDate.</value>
        public DateTimeOffset BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                this._BirthDate = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the MaritalStatus.
        /// </summary>
        /// <value>The MaritalStatus.</value>
        public string MaritalStatus
        {
            get
            {
                return this._MaritalStatus;
            }
            set
            {
                this._MaritalStatus = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>The Gender.</value>
        public string Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the HireDate.
        /// </summary>
        /// <value>The HireDate.</value>
        public DateTimeOffset HireDate
        {
            get
            {
                return this._HireDate;
            }
            set
            {
                this._HireDate = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the CheckInTime.
        /// </summary>
        /// <value>The CheckInTime.</value>
        public DateTimeOffset? CheckInTime
        {
            get
            {
                return this._CheckInTime;
            }
            set
            {
                this._CheckInTime = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the SickLeaveHours.
        /// </summary>
        /// <value>The SickLeaveHours.</value>
        public int SickLeaveHours
        {
            get
            {
                return this._SickLeaveHours;
            }
            set
            {
                this._SickLeaveHours = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>The Salary.</value>
        [Range(2000, 5000, ErrorMessage = "The “Salary” field can range from 2000 through 5000.")]
        public double Salary
        {
            get
            {
                return this._Salary;
            }
            set
            {
                this._Salary = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the LoginID.
        /// </summary>
        /// <value>The LogID.</value>
        public string LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                _LoginID = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ManagerID.
        /// </summary>
        /// <value>The ManagerID.</value>
        public int ManagerID
        {
            get
            {
                return _ManagerID;
            }
            set
            {
                _ManagerID = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the EmployeeStatus.
        /// </summary>
        /// <value>The EmployeeStatus.</value>
        public bool EmployeeStatus
        {
            get
            {
                return employeeStatus;
            }
            set
            {
                employeeStatus = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        /// <value>The Rating.</value>
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the EMail.
        /// </summary>
        /// <value>The EMail.</value>
        public string EMail
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ContactNo.
        /// </summary>
        /// <value>The ContactNo.</value>
        [StringLength(14, ErrorMessage = "The “ContactNo” field must be a string with a maximum length of 14.")]
        public string ContactNo
        {
            get { return _contactnos; }
            set
            {
                _contactnos = value; 
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>The City.</value>
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChangedEvent();
            }
        }

        #region INotifyDataErrorInfo

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (name != null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        }




        #endregion

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
