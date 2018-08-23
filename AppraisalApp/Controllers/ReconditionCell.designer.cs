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
    [Register ("ReconditionCell")]
    partial class ReconditionCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReconditionDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReconditionHeader { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ReconditionDescription != null) {
                ReconditionDescription.Dispose ();
                ReconditionDescription = null;
            }

            if (ReconditionHeader != null) {
                ReconditionHeader.Dispose ();
                ReconditionHeader = null;
            }
        }
    }
}