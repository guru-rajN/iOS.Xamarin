// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ExtAppraisalApp
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView VehicleInfoTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (VehicleInfoTableView != null) {
                VehicleInfoTableView.Dispose ();
                VehicleInfoTableView = null;
            }
        }
    }
}