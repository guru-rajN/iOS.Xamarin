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
        UIKit.UIView AdditionAMFO { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl AdditionSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView AditionAMFOScroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView AMFO { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Btn_SaveAfterMarket { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MasterAdditionalAMFO { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView masterAMFO { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl ReconditionSegment { get; set; }

        [Action ("AfterMarketSegmentValue_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AfterMarketSegmentValue_Changed (UIKit.UISegmentedControl sender);

        [Action ("Btn_SaveAfterMarket_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btn_SaveAfterMarket_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SegmentValue_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SegmentValue_Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (AdditionAMFO != null) {
                AdditionAMFO.Dispose ();
                AdditionAMFO = null;
            }

            if (AdditionSegment != null) {
                AdditionSegment.Dispose ();
                AdditionSegment = null;
            }

            if (AditionAMFOScroll != null) {
                AditionAMFOScroll.Dispose ();
                AditionAMFOScroll = null;
            }

            if (AMFO != null) {
                AMFO.Dispose ();
                AMFO = null;
            }

            if (Btn_SaveAfterMarket != null) {
                Btn_SaveAfterMarket.Dispose ();
                Btn_SaveAfterMarket = null;
            }

            if (MasterAdditionalAMFO != null) {
                MasterAdditionalAMFO.Dispose ();
                MasterAdditionalAMFO = null;
            }

            if (masterAMFO != null) {
                masterAMFO.Dispose ();
                masterAMFO = null;
            }

            if (ReconditionSegment != null) {
                ReconditionSegment.Dispose ();
                ReconditionSegment = null;
            }
        }
    }
}