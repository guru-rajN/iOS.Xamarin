// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ExtAppraisalApp
{
    [Register ("AppraisedViewController")]
    partial class AppraisedViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel address { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel APNSSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AppValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ExpDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VehicleDetails { get; set; }

        [Action ("Map_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Map_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (address != null) {
                address.Dispose ();
                address = null;
            }

            if (APNSSummary != null) {
                APNSSummary.Dispose ();
                APNSSummary = null;
            }

            if (AppValue != null) {
                AppValue.Dispose ();
                AppValue = null;
            }

            if (ExpDate != null) {
                ExpDate.Dispose ();
                ExpDate = null;
            }

            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (VehicleDetails != null) {
                VehicleDetails.Dispose ();
                VehicleDetails = null;
            }
        }
    }
}