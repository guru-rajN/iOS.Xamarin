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
    [Register ("FactoryOptionViewController")]
    partial class FactoryOptionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView FactoryOptionTableView { get; set; }

        [Action ("BtnSave_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSave_Activated(UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnSave != null) {
                BtnSave.Dispose ();
                BtnSave = null;
            }

            if (FactoryOptionTableView != null) {
                FactoryOptionTableView.Dispose ();
                FactoryOptionTableView = null;
            }
        }
    }
}