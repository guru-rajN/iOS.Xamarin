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
    [Register ("MapsViewController")]
    partial class MapsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem MapClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl mapTypes { get; set; }

        [Action ("MapClose_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MapClose_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (MapClose != null) {
                MapClose.Dispose ();
                MapClose = null;
            }

            if (mapTypes != null) {
                mapTypes.Dispose ();
                mapTypes = null;
            }
        }
    }
}