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
    [Register ("FactoryOptionDataViewController")]
    partial class FactoryOptionDataViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView FactoryOptionTableView { get; set; }

        [Action ("BtnClose_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnClose_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnClose != null) {
                BtnClose.Dispose ();
                BtnClose = null;
            }

            if (FactoryOptionTableView != null) {
                FactoryOptionTableView.Dispose ();
                FactoryOptionTableView = null;
            }
        }
    }
}