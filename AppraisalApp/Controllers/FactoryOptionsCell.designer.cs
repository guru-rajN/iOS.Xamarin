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
    [Register ("FactoryOptionsCell")]
    partial class FactoryOptionsCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel factoryOptionCellLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView factoryOptionDoneImg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (factoryOptionCellLabel != null) {
                factoryOptionCellLabel.Dispose ();
                factoryOptionCellLabel = null;
            }

            if (factoryOptionDoneImg != null) {
                factoryOptionDoneImg.Dispose ();
                factoryOptionDoneImg = null;
            }
        }
    }
}