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
    [Register ("AfterMarketDetailCell")]
    partial class AfterMarketDetailCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelElement { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch switchElement { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelElement != null) {
                LabelElement.Dispose ();
                LabelElement = null;
            }

            if (switchElement != null) {
                switchElement.Dispose ();
                switchElement = null;
            }
        }
    }
}