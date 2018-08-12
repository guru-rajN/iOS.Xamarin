// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ExtAppraisalApp
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bodyStyleValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DetailTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel driveTrainValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel engineValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel exteriorColorValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel makeValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel modelValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell seriesTrimCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel trimValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel vinNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel yearValue { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bodyStyleValue != null) {
                bodyStyleValue.Dispose ();
                bodyStyleValue = null;
            }

            if (DetailTableView != null) {
                DetailTableView.Dispose ();
                DetailTableView = null;
            }

            if (driveTrainValue != null) {
                driveTrainValue.Dispose ();
                driveTrainValue = null;
            }

            if (engineValue != null) {
                engineValue.Dispose ();
                engineValue = null;
            }

            if (exteriorColorValue != null) {
                exteriorColorValue.Dispose ();
                exteriorColorValue = null;
            }

            if (makeValue != null) {
                makeValue.Dispose ();
                makeValue = null;
            }

            if (modelValue != null) {
                modelValue.Dispose ();
                modelValue = null;
            }

            if (seriesTrimCell != null) {
                seriesTrimCell.Dispose ();
                seriesTrimCell = null;
            }

            if (trimValue != null) {
                trimValue.Dispose ();
                trimValue = null;
            }

            if (vinNumber != null) {
                vinNumber.Dispose ();
                vinNumber = null;
            }

            if (yearValue != null) {
                yearValue.Dispose ();
                yearValue = null;
            }
        }
    }
}