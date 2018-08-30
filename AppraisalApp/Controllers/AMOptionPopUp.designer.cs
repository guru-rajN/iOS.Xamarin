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
    [Register ("AMOptionPopUp")]
    partial class AMOptionPopUp
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnCancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnSave { get; set; }

        [Action ("BtnCancel_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCancel_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnSave_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSave_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnCancel != null) {
                BtnCancel.Dispose ();
                BtnCancel = null;
            }

            if (BtnSave != null) {
                BtnSave.Dispose ();
                BtnSave = null;
            }
        }
    }
}