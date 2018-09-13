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
        UIKit.UILabel APNSSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AppValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ExpDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VehicleDetails { get; set; }

        void ReleaseDesignerOutlets ()
        {
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

            if (VehicleDetails != null) {
                VehicleDetails.Dispose ();
                VehicleDetails = null;
            }
        }
    }
}