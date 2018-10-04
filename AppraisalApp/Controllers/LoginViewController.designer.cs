// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ExtAppraisalApp
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGetStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DealerBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EmailRadioBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GetStartBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GuestBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView GuestContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView InitialContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LoginGirlImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LoginImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView OverLayView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PhoneRadioBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtZip { get; set; }

        [Action ("BtnGetStart_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnGetStart_TouchUpInside (UIKit.UIButton sender);

        [Action ("DealerBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DealerBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("EmailRadioBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EmailRadioBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("GetStartBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GetStartBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("GuestBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GuestBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("PhoneRadioBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhoneRadioBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnGetStart != null) {
                btnGetStart.Dispose ();
                btnGetStart = null;
            }

            if (DealerBtn != null) {
                DealerBtn.Dispose ();
                DealerBtn = null;
            }

            if (EmailPhone != null) {
                EmailPhone.Dispose ();
                EmailPhone = null;
            }

            if (EmailRadioBtn != null) {
                EmailRadioBtn.Dispose ();
                EmailRadioBtn = null;
            }

            if (GetStartBtn != null) {
                GetStartBtn.Dispose ();
                GetStartBtn = null;
            }

            if (GuestBtn != null) {
                GuestBtn.Dispose ();
                GuestBtn = null;
            }

            if (GuestContainer != null) {
                GuestContainer.Dispose ();
                GuestContainer = null;
            }

            if (InitialContainer != null) {
                InitialContainer.Dispose ();
                InitialContainer = null;
            }

            if (LastNameTxt != null) {
                LastNameTxt.Dispose ();
                LastNameTxt = null;
            }

            if (LoginGirlImg != null) {
                LoginGirlImg.Dispose ();
                LoginGirlImg = null;
            }

            if (LoginImg != null) {
                LoginImg.Dispose ();
                LoginImg = null;
            }

            if (OverLayView != null) {
                OverLayView.Dispose ();
                OverLayView = null;
            }

            if (PhoneRadioBtn != null) {
                PhoneRadioBtn.Dispose ();
                PhoneRadioBtn = null;
            }

            if (scrollview != null) {
                scrollview.Dispose ();
                scrollview = null;
            }

            if (txtZip != null) {
                txtZip.Dispose ();
                txtZip = null;
            }
        }
    }
}