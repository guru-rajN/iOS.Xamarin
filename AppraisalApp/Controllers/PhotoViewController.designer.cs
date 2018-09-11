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
    [Register ("PhotoViewController")]
    partial class PhotoViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView AdditionalPhotosContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel carLooklabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PhotosContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem PhotosSaveBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl PhotosSegment { get; set; }

        [Action ("PhotosSaveBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhotosSaveBtn_Activated (UIKit.UIBarButtonItem sender);

        [Action ("PhotosSegment_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhotosSegment_Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (AdditionalPhotosContainer != null) {
                AdditionalPhotosContainer.Dispose ();
                AdditionalPhotosContainer = null;
            }

            if (carLooklabel != null) {
                carLooklabel.Dispose ();
                carLooklabel = null;
            }

            if (PhotosContainer != null) {
                PhotosContainer.Dispose ();
                PhotosContainer = null;
            }

            if (PhotosSaveBtn != null) {
                PhotosSaveBtn.Dispose ();
                PhotosSaveBtn = null;
            }

            if (PhotosSegment != null) {
                PhotosSegment.Dispose ();
                PhotosSegment = null;
            }
        }
    }
}