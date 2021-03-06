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
    [Register ("AppraisalLogViewController")]
    partial class AppraisalLogViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView AppraisalTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl AppraisalTypeSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnAddNew { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnCancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar VinSearch { get; set; }

        [Action ("BtnAddNew_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAddNew_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnCancel_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCancel_Activated (UIKit.UIBarButtonItem sender);

        [Action ("Segment_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Segment_Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (AppraisalTableView != null) {
                AppraisalTableView.Dispose ();
                AppraisalTableView = null;
            }

            if (AppraisalTypeSegment != null) {
                AppraisalTypeSegment.Dispose ();
                AppraisalTypeSegment = null;
            }

            if (BtnAddNew != null) {
                BtnAddNew.Dispose ();
                BtnAddNew = null;
            }

            if (BtnCancel != null) {
                BtnCancel.Dispose ();
                BtnCancel = null;
            }

            if (VinSearch != null) {
                VinSearch.Dispose ();
                VinSearch = null;
            }
        }
    }
}