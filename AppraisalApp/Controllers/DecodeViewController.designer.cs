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
    [Register ("DecodeViewController")]
    partial class DecodeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnCancel { get; set; }

       
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnDecode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDecodeVin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnScan { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView decodeActivity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell lblMileage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell lblVin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtMileage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtVin { get; set; }

        [Action ("BtnCancel_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCancel_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnCancel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCancel_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnDecode_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDecode_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnDecodeVin_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDecodeVin_TouchUpInside (UIKit.UIButton sender);

        [Action ("txtEmail_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtEmail_Changed (UIKit.UITextField sender);

        [Action ("txtFirstName_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtFirstName_Changed (UIKit.UITextField sender);

        [Action ("txtLastName_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtLastName_Changed (UIKit.UITextField sender);

        [Action ("txtMileage_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtMileage_Changed (UIKit.UITextField sender);

        [Action ("txtPhone_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtPhone_Changed (UIKit.UITextField sender);

        [Action ("txtVin_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtVin_Changed (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCancel != null) {
                btnCancel.Dispose ();
                btnCancel = null;
            }

            if (btnCancel != null) {
                btnCancel.Dispose ();
                btnCancel = null;
            }

            if (BtnDecode != null) {
                BtnDecode.Dispose ();
                BtnDecode = null;
            }

            if (btnDecodeVin != null) {
                btnDecodeVin.Dispose ();
                btnDecodeVin = null;
            }

            if (btnScan != null) {
                btnScan.Dispose ();
                btnScan = null;
            }

            if (decodeActivity != null) {
                decodeActivity.Dispose ();
                decodeActivity = null;
            }

            if (lblEmail != null) {
                lblEmail.Dispose ();
                lblEmail = null;
            }

            if (lblFirstName != null) {
                lblFirstName.Dispose ();
                lblFirstName = null;
            }

            if (lblLastName != null) {
                lblLastName.Dispose ();
                lblLastName = null;
            }

            if (lblMileage != null) {
                lblMileage.Dispose ();
                lblMileage = null;
            }

            if (lblPhone != null) {
                lblPhone.Dispose ();
                lblPhone = null;
            }

            if (lblVin != null) {
                lblVin.Dispose ();
                lblVin = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtFirstName != null) {
                txtFirstName.Dispose ();
                txtFirstName = null;
            }

            if (txtLastName != null) {
                txtLastName.Dispose ();
                txtLastName = null;
            }

            if (txtMileage != null) {
                txtMileage.Dispose ();
                txtMileage = null;
            }

            if (txtPhone != null) {
                txtPhone.Dispose ();
                txtPhone = null;
            }

            if (txtVin != null) {
                txtVin.Dispose ();
                txtVin = null;
            }
        }
    }
}