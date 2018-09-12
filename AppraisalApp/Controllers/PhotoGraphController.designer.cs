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
    [Register ("PhotoGraphController")]
    partial class PhotoGraphController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Back { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Dashboard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Front { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Left { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Odometer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Right { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Rim { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Seat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Seats { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton VIN { get; set; }

        [Action ("Back_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Back_TouchUpInside (UIKit.UIButton sender);

        [Action ("Dashboard_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Dashboard_TouchUpInside (UIKit.UIButton sender);

        [Action ("Front_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Front_TouchUpInside (UIKit.UIButton sender);

        [Action ("Left_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Left_TouchUpInside (UIKit.UIButton sender);

        [Action ("Odometer_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Odometer_TouchUpInside (UIKit.UIButton sender);

        [Action ("Right_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Right_TouchUpInside (UIKit.UIButton sender);

        [Action ("Rim_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Rim_TouchUpInside (UIKit.UIButton sender);

        [Action ("Seat_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Seat_TouchUpInside (UIKit.UIButton sender);

        [Action ("Seats_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Seats_TouchUpInside (UIKit.UIButton sender);

        [Action ("VIN_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void VIN_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Back != null) {
                Back.Dispose ();
                Back = null;
            }

            if (Dashboard != null) {
                Dashboard.Dispose ();
                Dashboard = null;
            }

            if (Front != null) {
                Front.Dispose ();
                Front = null;
            }

            if (Left != null) {
                Left.Dispose ();
                Left = null;
            }

            if (Odometer != null) {
                Odometer.Dispose ();
                Odometer = null;
            }

            if (Right != null) {
                Right.Dispose ();
                Right = null;
            }

            if (Rim != null) {
                Rim.Dispose ();
                Rim = null;
            }

            if (Seat != null) {
                Seat.Dispose ();
                Seat = null;
            }

            if (Seats != null) {
                Seats.Dispose ();
                Seats = null;
            }

            if (VIN != null) {
                VIN.Dispose ();
                VIN = null;
            }
        }
    }
}