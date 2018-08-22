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
    [Register ("HistoryViewController")]
    partial class HistoryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField label1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField label2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Save { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl Segment1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl Segment2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl Segment3 { get; set; }

        [Action ("label2_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void label2_Change (UIKit.UITextField sender);

        [Action ("Label2_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Label2_Change (UIKit.UITextField sender);

        [Action ("Save_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Save_Activated (UIKit.UIBarButtonItem sender);

        [Action ("Segment1_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Segment1_Change (UIKit.UISegmentedControl sender);

        [Action ("Segment2_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Segment2_Change (UIKit.UISegmentedControl sender);

        [Action ("Segment3_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Segment3_Change (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (label1 != null) {
                label1.Dispose ();
                label1 = null;
            }

            if (label2 != null) {
                label2.Dispose ();
                label2 = null;
            }

            if (label3 != null) {
                label3.Dispose ();
                label3 = null;
            }

            if (Save != null) {
                Save.Dispose ();
                Save = null;
            }

            if (Segment1 != null) {
                Segment1.Dispose ();
                Segment1 = null;
            }

            if (Segment2 != null) {
                Segment2.Dispose ();
                Segment2 = null;
            }

            if (Segment3 != null) {
                Segment3.Dispose ();
                Segment3 = null;
            }
        }
    }
}