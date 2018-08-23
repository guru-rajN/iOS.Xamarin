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
    [Register ("ReconditionViewController")]
    partial class ReconditionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem ReconditionSaveBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl ReconditionSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ReconditionTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel selectionAlertLabel { get; set; }

        [Action ("ReconditionSaveBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ReconditionSaveBtn_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SegmentValue_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SegmentValue_Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (ReconditionSaveBtn != null) {
                ReconditionSaveBtn.Dispose ();
                ReconditionSaveBtn = null;
            }

            if (ReconditionSegment != null) {
                ReconditionSegment.Dispose ();
                ReconditionSegment = null;
            }

            if (ReconditionTableView != null) {
                ReconditionTableView.Dispose ();
                ReconditionTableView = null;
            }

            if (selectionAlertLabel != null) {
                selectionAlertLabel.Dispose ();
                selectionAlertLabel = null;
            }
        }
    }
}