#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

namespace APKCommon
{
    /// <summary>
    /// A model class represent a control information.
    /// </summary>
    public class ControlInfo : ITileInfo
    {
        /// <summary>
        /// Gets or set a name of control from <see cref="DemoControl"/> enum.
        /// </summary>
        public DemoControl Control { get; set; }

        /// <summary>
        /// Gets a value of name in string format converted from <see cref="DemoControl"/> enum.
        /// </summary>
        public string Name
        {
            get
            {
                return "test";// (string)new EnumDisplayNameConverter().Convert(Control, null, null, null);
            }
        }

        /// <summary>
        /// Gets or sets a value of <see cref="syncfusion.demoscommon.winui.ControlBadge"/>.
        /// </summary>
        public ControlBadge ControlBadge { get; set; }

        /// <summary>
        /// Gets or set a value of <see cref="winui.ControlCategory"/> where the control belong to its group.
        /// </summary>
        public ControlCategory ControlCategory { get; set; }

        /// <summary>
        /// Gets a value of category in string format converted from <see cref="winui.ControlCategory"/> enum.
        /// </summary>
        public string Category
        {
            get
            {
                return "test";//(string)new EnumDisplayNameConverter().Convert(ControlCategory, null, null, null);
            }
            set
            {
                throw new Exception("Set FeatureCategory for ControlInfo using API ControlCategory");
            }
        }

        /// <summary>
        /// Gets or set a value of description which explains about the control and its feature.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or set a value of glyph to represent the control.
        /// </summary>
        public string Glyph { get; set; }

        /// <summary>
        /// Gets a list of demo information falls under its <see cref="ControlInfo"/>.
        /// </summary>
        public List<DemoInfo> Demos { get; } = new List<DemoInfo>();

        /// <summary>
        /// Gets a value of badge which may be any of the <see cref="DemoTypes"/>.
        /// </summary>
        public string Badge
        {
            get
            {
                if (ControlBadge == ControlBadge.New)
                {
                    return Constants.New;
                }
                else if (ControlBadge == ControlBadge.Updated)
                {
                    return Constants.Updated;
                }
                else if(Demos != null)
                {
                    if (Demos.All(demo => demo.DemoType == DemoTypes.New))
                    {
                        return Constants.New;
                    }
                    else if (Demos.Any(demo => demo.DemoType == DemoTypes.New) || Demos.Any(demo => demo.DemoType == DemoTypes.Updated))
                    {
                        return Constants.Updated;
                    }
                }

                return string.Empty;
            }
        }
    }
}
