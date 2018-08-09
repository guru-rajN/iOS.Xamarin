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
    [Register ("InformationCell")]
    partial class InformationCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel infoCellLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView infoDoneImg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (infoCellLabel != null) {
                infoCellLabel.Dispose ();
                infoCellLabel = null;
            }

            if (infoDoneImg != null) {
                infoDoneImg.Dispose ();
                infoDoneImg = null;
            }
        }
    }
}