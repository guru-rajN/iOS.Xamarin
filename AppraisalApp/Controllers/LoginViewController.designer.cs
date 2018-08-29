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
        UIKit.UIImageView boxImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGetStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ComponentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView EchoParkLogo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GetStartBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LoginGirlImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LoginImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtZip { get; set; }

        [Action ("BtnGetStart_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnGetStart_TouchUpInside (UIKit.UIButton sender);

        [Action ("GetStartBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GetStartBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (boxImg != null) {
                boxImg.Dispose ();
                boxImg = null;
            }

            if (btnGetStart != null) {
                btnGetStart.Dispose ();
                btnGetStart = null;
            }

            if (ComponentView != null) {
                ComponentView.Dispose ();
                ComponentView = null;
            }

            if (EchoParkLogo != null) {
                EchoParkLogo.Dispose ();
                EchoParkLogo = null;
            }

            if (GetStartBtn != null) {
                GetStartBtn.Dispose ();
                GetStartBtn = null;
            }

            if (LoginGirlImg != null) {
                LoginGirlImg.Dispose ();
                LoginGirlImg = null;
            }

            if (LoginImg != null) {
                LoginImg.Dispose ();
                LoginImg = null;
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