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
    public class OrderInfo : INotifyPropertyChanged, IDisposable
    {
        private double _OrderID;
        private string _CustomerID;
        private string _productName;
        private double _unitPrice;
        private DateTimeOffset _orderDate;
        private double _freight;
        private long _contactNumber;
        private string _shipcity;
        private string _shipCountry;
        private double _quantity;
        private DateTimeOffset shippedDate;
        private string _shipAddress;
        private string _shipName;
        private double _discount;
        private double _NoOfOrders;
        private int _supplierID;
        private double _unitsInStock;
        private TimeSpan _deliveryDelay;
        private string _shipPostalCode;
        private bool _isShipped;
        private double _productID;
        private string _CompanyName;
        private double _Expense;
        private string imageLink;
        private int _employeeID;
        private ObservableCollection<OrderInfo> orderDetails;
        static int count = 0;
        private List<OrderInfo> orderList;

        public OrderInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="cusid">The custmer iD.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="NoOfOrders">The no of orders.</param>
        /// <param name="country">The country.</param>
        /// <param name="ShipCity">The ship city ID.</param>
        public OrderInfo(int ord, string cusid, string productName, int NoOfOrders, string country, int shipCityID)
        {
            this._OrderID = ord;
            this._CustomerID = cusid;
            this._shipCountry = country;
            this._shipCityID = shipCityID;
            this._productName = productName;
            this._NoOfOrders = NoOfOrders;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="prod">The prod.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="quan">The quan.</param>
        /// <param name="disc">The disc.</param>
        public OrderInfo(int ord, int prod, decimal unit, Int16 quan, double disc, string cusid, DateTime ordDt, string city)
        {
            this._discount = disc;
            this._OrderID = ord;
            this._productID = prod;
            this._quantity = quan;
            this._unitPrice = (double)unit;
            this._CustomerID = cusid;
            this._orderDate = ordDt;
            this.ShipCity = city;
            this._deliveryDelay = ordDt.AddDays(quan - 1) - ordDt;
            if (count % 3 == 0)
                this.imageLink = "US.jpg";
            else if (count % 2 == 0)
                this.imageLink = "UK.jpg";
            else
                this.imageLink = "Japan.jpg";
            this._supplierID = count % 3 == 0 ? 1 : count % 3;
            count++;

        }
        public ObservableCollection<OrderInfo> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }
            set
            {
                this.orderDetails = value;
                RaisePropertyChangedEvent();
            }
        }

        public List<OrderInfo> OrderList
        {
            get
            {
                return this.orderList;
            }
            set
            {
                this.orderList = value;
                RaisePropertyChangedEvent();
            }
        }

        public double OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
                RaisePropertyChangedEvent();
            }
        }
        public double ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                RaisePropertyChangedEvent();
            }
        }

        public int ShipCityID
        {
            get
            {
                return _shipCityID;
            }
            set
            {
                _shipCityID = value;
                RaisePropertyChangedEvent();
            }
        }
        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
                RaisePropertyChangedEvent();
            }
        }

        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
                RaisePropertyChangedEvent();
            }
        }

        public int SupplierID
        {
            get
            {
                return _supplierID;
            }
            set
            {
                _supplierID = value;
                RaisePropertyChangedEvent();
            }
        }

        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                RaisePropertyChangedEvent();
            }
        }

        public double UnitsInStock
        {
            get
            {
                return this._unitsInStock;
            }
            set
            {
                this._unitsInStock = value;
                RaisePropertyChangedEvent();
            }
        }

        public double Expense
        {
            get
            {
                return this._Expense;
            }
            set
            {
                this._Expense = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>The freight.</value>
        public double Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                _freight = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double NoOfOrders
        {
            get
            {
                return _NoOfOrders;
            }
            set
            {
                _NoOfOrders = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ImageLink.
        /// </summary>    
        public string ImageLink
        {
            get
            {
                return imageLink;
            }
            set
            {
                imageLink = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTimeOffset OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                RaisePropertyChangedEvent();
            }
        }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        public long ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                _contactNumber = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ShipAddress.
        /// </summary>
        /// <value>
        /// The ShipAddress.
        /// </value>
        public string ShipAddress
        {
            get
            {
                return _shipAddress;
            }
            set
            {
                _shipAddress = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ShipCity.
        /// </summary>
        /// <value>
        /// The ShipCity.
        /// </value>
        public string ShipCity
        {
            get
            {
                return _shipcity;
            }
            set
            {
                _shipcity = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ShipCountry.
        /// </summary>
        /// <value>
        /// The ShipCity.
        /// </value>
        public string ShipCountry
        {
            get
            {
                return _shipCountry;
            }
            set
            {
                _shipCountry = value;
                RaisePropertyChangedEvent();
            }
        }

        public bool IsShipped
        {
            get { return _isShipped; }
            set
            {
                _isShipped = value;
                RaisePropertyChangedEvent();
            }
        }

        public string ShipName
        {
            get { return _shipName; }
            set
            {
                _shipName = value;
                RaisePropertyChangedEvent();
            }
        }

        public DateTimeOffset ShippedDate
        {
            get { return shippedDate; }
            set
            {
                shippedDate = value;
                RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>The ship postal code.</value>
        public string ShipPostalCode
        {
            get
            {
                return _shipPostalCode;
            }
            set
            {
                _shipPostalCode = value;
                RaisePropertyChangedEvent();
            }
        }


        public TimeSpan DeliveryDelay
        {
            get
            {
                return _deliveryDelay;
            }
            set
            {
                _deliveryDelay = value;
                RaisePropertyChangedEvent();
            }
        }

        private bool _isChecked;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is checked; otherwise, <c>false</c>.
        /// </value>
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChangedEvent();
            }
        }

        public string _name;
        private int _shipCityID;

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
            if (OrderDetails != null)
            {
                foreach (var orderDetail in OrderDetails)
                    (orderDetail as OrderInfo).Dispose();

                OrderDetails.Clear();
            }

            if (OrderList != null)
            {
                foreach (var order in OrderList)
                    (order as OrderInfo).Dispose();

                    OrderList.Clear();
            }

        }
        #endregion
    }

}
