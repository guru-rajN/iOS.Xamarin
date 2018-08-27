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
    [Register ("AfterMarketViewController")]
    partial class AfterMarketViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView AfterMarketTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Btn_SaveAfterMarket { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl ReconditionSegment { get; set; }

        [Action ("ReconditionSaveBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ReconditionSaveBtn_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SegmentValue_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SegmentValue_Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (AfterMarketTableView != null) {
                AfterMarketTableView.Dispose ();
                AfterMarketTableView = null;
            }

            if (Btn_SaveAfterMarket != null) {
                Btn_SaveAfterMarket.Dispose ();
                Btn_SaveAfterMarket = null;
            }

            if (ReconditionSegment != null) {
                ReconditionSegment.Dispose ();
                ReconditionSegment = null;
            }
        }
    }
}