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
    [Register ("AMOptionViewController")]
    partial class AMOptionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView AMOptionTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnClose { get; set; }

        [Action ("BtnClose_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnClose_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (AMOptionTableView != null) {
                AMOptionTableView.Dispose ();
                AMOptionTableView = null;
            }

            if (BtnClose != null) {
                BtnClose.Dispose ();
                BtnClose = null;
            }
        }
    }
}