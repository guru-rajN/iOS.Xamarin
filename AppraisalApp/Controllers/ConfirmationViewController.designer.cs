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
        UIKit.UILabel ConfirmationMsg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SummaryMsg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ConfirmationMsg != null) {
                ConfirmationMsg.Dispose ();
                ConfirmationMsg = null;
            }

            if (SummaryMsg != null) {
                SummaryMsg.Dispose ();
                SummaryMsg = null;
            }
        }
    }
}