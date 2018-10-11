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
        UIKit.UIBarButtonItem DetailSaveBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DetailTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel drivetrainValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel engineValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel exteriorColorValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel interiorColorValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel interiorTypeValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel makeValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel mileageValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel modelValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel odometerValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell seriesTrimCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel transmissionValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel trimValue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel vinNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel yearValue { get; set; }

        [Action ("DetailSaveBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DetailSaveBtn_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (DetailSaveBtn != null) {
                DetailSaveBtn.Dispose ();
                DetailSaveBtn = null;
            }

            if (DetailTableView != null) {
                DetailTableView.Dispose ();
                DetailTableView = null;
            }

            if (drivetrainValue != null) {
                drivetrainValue.Dispose ();
                drivetrainValue = null;
            }

            if (engineValue != null) {
                engineValue.Dispose ();
                engineValue = null;
            }

            if (exteriorColorValue != null) {
                exteriorColorValue.Dispose ();
                exteriorColorValue = null;
            }

            if (interiorColorValue != null) {
                interiorColorValue.Dispose ();
                interiorColorValue = null;
            }

            if (interiorTypeValue != null) {
                interiorTypeValue.Dispose ();
                interiorTypeValue = null;
            }

            if (makeValue != null) {
                makeValue.Dispose ();
                makeValue = null;
            }

            if (mileageValue != null) {
                mileageValue.Dispose ();
                mileageValue = null;
            }

            if (modelValue != null) {
                modelValue.Dispose ();
                modelValue = null;
            }

            if (odometerValue != null) {
                odometerValue.Dispose ();
                odometerValue = null;
            }

            if (seriesTrimCell != null) {
                seriesTrimCell.Dispose ();
                seriesTrimCell = null;
            }

            if (transmissionValue != null) {
                transmissionValue.Dispose ();
                transmissionValue = null;
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