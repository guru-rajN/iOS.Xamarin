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
        UIKit.UIButton btnDial { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFAQ { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMailDial { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMainContactUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMainQA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConfirmationMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DownArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView HighContactUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView HighQA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SummaryMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UpArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewContactDetails { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewDownArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewFAQ { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewLine { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMainMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView VIewMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewUpArrow { get; set; }

        [Action ("BtnDial_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDial_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnFAQ_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFAQ_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnMail_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMail_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnMailDial_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMailDial_TouchUpInside (UIKit.UIButton sender);

        [Action ("DownArrow_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DownArrow_TouchUpInside (UIKit.UIButton sender);

        [Action ("UpArrow_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UpArrow_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDial != null) {
                btnDial.Dispose ();
                btnDial = null;
            }

            if (btnFAQ != null) {
                btnFAQ.Dispose ();
                btnFAQ = null;
            }

            if (btnMail != null) {
                btnMail.Dispose ();
                btnMail = null;
            }

            if (btnMailDial != null) {
                btnMailDial.Dispose ();
                btnMailDial = null;
            }

            if (btnMainContactUs != null) {
                btnMainContactUs.Dispose ();
                btnMainContactUs = null;
            }

            if (btnMainQA != null) {
                btnMainQA.Dispose ();
                btnMainQA = null;
            }

            if (ConfirmationMsg != null) {
                ConfirmationMsg.Dispose ();
                ConfirmationMsg = null;
            }

            if (DownArrow != null) {
                DownArrow.Dispose ();
                DownArrow = null;
            }

            if (HighContactUs != null) {
                HighContactUs.Dispose ();
                HighContactUs = null;
            }

            if (HighQA != null) {
                HighQA.Dispose ();
                HighQA = null;
            }

            if (SummaryMsg != null) {
                SummaryMsg.Dispose ();
                SummaryMsg = null;
            }

            if (UpArrow != null) {
                UpArrow.Dispose ();
                UpArrow = null;
            }

            if (ViewContactDetails != null) {
                ViewContactDetails.Dispose ();
                ViewContactDetails = null;
            }

            if (ViewDownArrow != null) {
                ViewDownArrow.Dispose ();
                ViewDownArrow = null;
            }

            if (ViewFAQ != null) {
                ViewFAQ.Dispose ();
                ViewFAQ = null;
            }

            if (ViewLine != null) {
                ViewLine.Dispose ();
                ViewLine = null;
            }

            if (viewMainMenu != null) {
                viewMainMenu.Dispose ();
                viewMainMenu = null;
            }

            if (VIewMainView != null) {
                VIewMainView.Dispose ();
                VIewMainView = null;
            }

            if (ViewUpArrow != null) {
                ViewUpArrow.Dispose ();
                ViewUpArrow = null;
            }
        }
    }
}