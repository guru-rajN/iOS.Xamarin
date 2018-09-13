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
    [Register ("PhotosCell")]
    partial class PhotosCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AddPhotoImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AddPhotoLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddPhotoImg != null) {
                AddPhotoImg.Dispose ();
                AddPhotoImg = null;
            }

            if (AddPhotoLabel != null) {
                AddPhotoLabel.Dispose ();
                AddPhotoLabel = null;
            }
        }
    }
}