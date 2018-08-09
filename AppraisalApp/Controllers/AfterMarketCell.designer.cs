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
    [Register ("AfterMarketCell")]
    partial class AfterMarketCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel afterMarketCellLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView afterMarketDoneImg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (afterMarketCellLabel != null) {
                afterMarketCellLabel.Dispose ();
                afterMarketCellLabel = null;
            }

            if (afterMarketDoneImg != null) {
                afterMarketDoneImg.Dispose ();
                afterMarketDoneImg = null;
            }
        }
    }
}