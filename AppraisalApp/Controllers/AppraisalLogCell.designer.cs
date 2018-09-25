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

namespace AppraisalApp
{
    [Register ("AppraisalLogCell")]
    partial class AppraisalLogCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel appraisalDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Mileage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sacComment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Trim { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Vin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel YearMakeModel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (appraisalDate != null) {
                appraisalDate.Dispose ();
                appraisalDate = null;
            }

            if (ContainerView != null) {
                ContainerView.Dispose ();
                ContainerView = null;
            }

            if (Mileage != null) {
                Mileage.Dispose ();
                Mileage = null;
            }

            if (sacComment != null) {
                sacComment.Dispose ();
                sacComment = null;
            }

            if (Trim != null) {
                Trim.Dispose ();
                Trim = null;
            }

            if (Vin != null) {
                Vin.Dispose ();
                Vin = null;
            }

            if (YearMakeModel != null) {
                YearMakeModel.Dispose ();
                YearMakeModel = null;
            }
        }
    }
}