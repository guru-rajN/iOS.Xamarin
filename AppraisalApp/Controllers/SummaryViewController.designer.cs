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
    [Register ("SummaryViewController")]
    partial class SummaryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView AppraisedContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem EditButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SubmitBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SummaryContainerView { get; set; }

        [Action ("EditButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EditButton_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SubmitBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitBtn_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (AppraisedContainerView != null) {
                AppraisedContainerView.Dispose ();
                AppraisedContainerView = null;
            }

            if (EditButton != null) {
                EditButton.Dispose ();
                EditButton = null;
            }

            if (SubmitBtn != null) {
                SubmitBtn.Dispose ();
                SubmitBtn = null;
            }

            if (SummaryContainerView != null) {
                SummaryContainerView.Dispose ();
                SummaryContainerView = null;
            }
        }
    }
}