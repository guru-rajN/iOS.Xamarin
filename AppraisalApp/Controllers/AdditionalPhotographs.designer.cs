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
    [Register ("AdditionalPhotographs")]
    partial class AdditionalPhotographs
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView AddPhotoCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddPhotoCollectionView != null) {
                AddPhotoCollectionView.Dispose ();
                AddPhotoCollectionView = null;
            }
        }
    }
}