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
    [Register ("ConfirmationViewController")]
    partial class ConfirmationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConfirmationMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContactUsContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ContactUsPanelBottomConstraints { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContactUsPanelView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SummaryMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UpArrowBtn { get; set; }

        [Action ("UpArrowBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UpArrowBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ConfirmationMsg != null) {
                ConfirmationMsg.Dispose ();
                ConfirmationMsg = null;
            }

            if (ContactUsContainerView != null) {
                ContactUsContainerView.Dispose ();
                ContactUsContainerView = null;
            }

            if (ContactUsPanelBottomConstraints != null) {
                ContactUsPanelBottomConstraints.Dispose ();
                ContactUsPanelBottomConstraints = null;
            }

            if (ContactUsPanelView != null) {
                ContactUsPanelView.Dispose ();
                ContactUsPanelView = null;
            }

            if (SummaryMsg != null) {
                SummaryMsg.Dispose ();
                SummaryMsg = null;
            }

            if (UpArrowBtn != null) {
                UpArrowBtn.Dispose ();
                UpArrowBtn = null;
            }
        }
    }
}