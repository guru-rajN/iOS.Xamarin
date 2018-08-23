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
    [Register ("ReconditionOptionCell")]
    partial class ReconditionOptionCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReconditionCellLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ReconditionCellLabel != null) {
                ReconditionCellLabel.Dispose ();
                ReconditionCellLabel = null;
            }
        }
    }
}