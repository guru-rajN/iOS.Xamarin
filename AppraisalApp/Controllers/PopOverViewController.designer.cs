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
    [Register ("PopOverViewController")]
    partial class PopOverViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem CancelBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem DoneBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField subtitleText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleText { get; set; }

        [Action ("CancelBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelBtn_Activated (UIKit.UIBarButtonItem sender);

        [Action ("DoneBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DoneBtn_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (CancelBtn != null) {
                CancelBtn.Dispose ();
                CancelBtn = null;
            }

            if (DoneBtn != null) {
                DoneBtn.Dispose ();
                DoneBtn = null;
            }

            if (subtitleText != null) {
                subtitleText.Dispose ();
                subtitleText = null;
            }

            if (titleText != null) {
                titleText.Dispose ();
                titleText = null;
            }
        }
    }
}