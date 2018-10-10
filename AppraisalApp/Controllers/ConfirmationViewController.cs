using Foundation;
using System;
using UIKit;
using AppraisalApp.Models;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using System.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using ExtAppraisalApp.Utilities;

namespace ExtAppraisalApp
{
    public partial class ConfirmationViewController : UIViewController
    {
        partial void btnMainQA_TouchUpInside(UIButton sender)
        {
            VIewMainView.Hidden = false;
            HighContactUs.Hidden = true;
            HighQA.Hidden = false;
            ViewContactDetails.Hidden = true;
            ViewFAQ.Hidden = false;

        }

        partial void BtnMainContactUs_TouchUpInside(UIButton sender)
        {
            VIewMainView.Hidden = false;
            HighQA.Hidden = true;
            HighContactUs.Hidden = false;
            ViewContactDetails.Hidden = false;
            ViewFAQ.Hidden = true;

        }

        partial void BtnDial_TouchUpInside(UIButton sender)
        {
            try
            {
                global::Xamarin.Forms.Forms.Init();
                Device.OpenUri(new Uri(String.Format("tel:{0}", "+18666576642")));
            }
            catch (ArgumentNullException Ex)
            {
                // Number was null or white space
            }
        }

        partial void BtnMail_TouchUpInside(UIButton sender)
        {
            global::Xamarin.Forms.Forms.Init();

            var address = "chidu.soraba@gmail.com";

            Device.OpenUri(new Uri($"mailto:{ address}?subject=Feedback&body=A message for you consideration." + "%0D%0A" +  //line break 
                                   ""));
        }

        partial void BtnFAQ_TouchUpInside(UIButton sender)
        {
            HighContactUs.Hidden = true;
            HighQA.Hidden = false;
            ViewContactDetails.Hidden = true;
            ViewFAQ.Hidden = false;
        }

        partial void BtnMailDial_TouchUpInside(UIButton sender)
        {
            HighQA.Hidden = true;
            HighContactUs.Hidden = false;
            ViewContactDetails.Hidden = false;
            ViewFAQ.Hidden = true;


        }



        partial void DownArrow_TouchUpInside(UIButton sender)
        {
            VIewMainView.Hidden = true;
        }

        partial void UpArrow_TouchUpInside(UIButton sender)
        {
            VIewMainView.Hidden = false;
        }

        public ConfirmationViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"SaveClicked", notify: delegate (NSNotification obj) { SaveDetails(obj); });
            base.ViewDidLoad();
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(ShowPopUp);
            ViewUpArrow.AddGestureRecognizer(tapGesture);
            UITapGestureRecognizer tapGesture1 = new UITapGestureRecognizer(HidePopUp);
            ViewDownArrow.AddGestureRecognizer(tapGesture1);
            UITapGestureRecognizer tapGestureMail = new UITapGestureRecognizer(ShowMail);
            lblMail.AddGestureRecognizer(tapGestureMail);

            UITapGestureRecognizer tapGestureContact = new UITapGestureRecognizer(DialContact);
            lblDial.AddGestureRecognizer(tapGestureContact);
            // lblDial.

            viewcellmail.AddGestureRecognizer(tapGestureMail);
            viewcelldial.AddGestureRecognizer(tapGestureContact);
        }
        public void ShowMail()
        {
            global::Xamarin.Forms.Forms.Init();

            var address = "support@sonic.net";

            Device.OpenUri(new Uri($"mailto:{ address}?subject=Feedback&body=A message for you consideration." + "%0D%0A" +  //line break 
                                   "Line2"));

        }
        public void DialContact()
        {
            global::Xamarin.Forms.Forms.Init();
            Device.OpenUri(new Uri(String.Format("tel:{0}", "+18666576642")));


        }
        public void ShowPopUp()
        {
            VIewMainView.Hidden = false;
        }
        public void HidePopUp()
        {
            VIewMainView.Hidden = true;
        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"SaveClicked");
            base.ViewDidDisappear(animated);
        }

        private async Task SaveDetails(NSNotification obj)
        {
            // TO-DO : API calls integration

            ConfirmationMsg.Text = "We will get back to you.";

            SummaryMsg.Text = "Thank you for submitting your appraisal information. Once we appraise your Trade,the value will be valid for 14 days or 500 miles from the date of submission. At the time of delivery or transfer of ownership, CarCash reserves the right to verify that the information you have submitted is accurate and to adjust the value offered if we feel that your vehicle does not match the description you have provided.";
            dropSqlite();
            deletePhoto();
            // saveDeviceToken();
            var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
            Utility.ShowLoadingIndicator(splitViewController.View, "Saving...", true);
            await CallService();
            Utility.HideLoadingIndicator(splitViewController.View);
            deletePhoto();

        }


        Task CallService()
        {
            return Task.Factory.StartNew(() =>
            {
                Save_Offer();
                saveDeviceToken();
            });
        }

        private void Save_Offer()
        {
            OfferResponse offerResponse = new OfferResponse();
            SIMSResponseData responseStatus;
            offerResponse.vehicleId = AppDelegate.appDelegate.vehicleID;
            offerResponse.storeId = AppDelegate.appDelegate.storeId;
            offerResponse.invtrId = AppDelegate.appDelegate.invtrId;
            offerResponse.ProspectId = AppDelegate.appDelegate.prospectId;
            offerResponse.TrimId = AppDelegate.appDelegate.trimId;
            offerResponse.UserName = "ExtAppraisalApp";

            string DeviceToken = AppDelegate.appDelegate.AppleDeviceToken;
            responseStatus = ServiceFactory.ServiceOffer.getWebServiceHandle().SaveOffer(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, "ExterAppraisalApp", AppDelegate.appDelegate.prospectId, AppDelegate.appDelegate.trimId);
        }

        private void saveDeviceToken()
        {
            APNSRespone aPNSRespone = new APNSRespone();
            SIMSResponseData responseStatus;
            aPNSRespone.VehicleId = AppDelegate.appDelegate.vehicleID;
            aPNSRespone.StoreId = AppDelegate.appDelegate.storeId;
            aPNSRespone.InvtrId = AppDelegate.appDelegate.invtrId;
            aPNSRespone.Token = AppDelegate.appDelegate.AppleDeviceToken;

            string DeviceToken = AppDelegate.appDelegate.AppleDeviceToken;
            responseStatus = ServiceFactory.ServiceAPNS.getWebServiceHandle().SaveAPNSDeviceToken(aPNSRespone);
        }

        private void deletePhoto()
        {

            var documentsDirectory = Environment.GetFolderPath
                                             (Environment.SpecialFolder.Personal);
            string buttonName = "right.png";
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "left.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "front.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "back.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "seat.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "seats.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "dashboard.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "rim.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "VIN.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "VIN.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "odometer.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "additional-photo-" + 0 + ".png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "additional-photo-" + 1 + ".png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "additional-photo-" + 2 + ".png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);

            System.IO.File.Delete(pngFilename);
            AppDelegate.appDelegate.LeftCarImageUploaded = false;
            AppDelegate.appDelegate.RightCarImageUploaded = false;
            AppDelegate.appDelegate.SeatCarImageUploaded = false;
            AppDelegate.appDelegate.BackSeatImageUploaded = false;
            AppDelegate.appDelegate.FrontCarImageUploaded = false;
            AppDelegate.appDelegate.BackCarImageUploaded = false;
            AppDelegate.appDelegate.DashBoardImageUploaded = false;
            AppDelegate.appDelegate.VINImageUplaoded = false;
            AppDelegate.appDelegate.RimImageUploaded = false;
            AppDelegate.appDelegate.OdometerImageUploaded = false;
            AppDelegate.appDelegate.photoButtonClicked = null;
            AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos = null;
            AppDelegate.appDelegate.BackCarImageURL = null;
            AppDelegate.appDelegate.FrontCarImageURL = null;
            AppDelegate.appDelegate.SeatCarImageURL = null;
            AppDelegate.appDelegate.BackSeatImageURL = null;
            AppDelegate.appDelegate.OdometerImageURL = null;
            AppDelegate.appDelegate.DashBoardImageURL = null;
            AppDelegate.appDelegate.LeftCarImageURL = null;
            AppDelegate.appDelegate.RightCarImageURL = null;
            AppDelegate.appDelegate.VINImageURL = null;
            AppDelegate.appDelegate.RimImageURL = null;
            AppDelegate.appDelegate.AdditionalPhoto0 = null;
            AppDelegate.appDelegate.AdditionalPhoto1 = null;
            AppDelegate.appDelegate.AdditionalPhoto2 = null;
            AppDelegate.appDelegate.photoAcesss = false;

            AppDelegate.appDelegate.reconResponse = null;
            AppDelegate.appDelegate.APNSAlertStore = null;
            AppDelegate.appDelegate.APNSAlertLon = null;
            AppDelegate.appDelegate.APNSAlertLat = null;
            AppDelegate.appDelegate.APNSAlertAddressa = null;
            AppDelegate.appDelegate.APNSAlertAddressb = null;
            AppDelegate.appDelegate.APNSAlertZip = null;
            AppDelegate.appDelegate.APNSAlert = null;
        }

        private void dropSqlite()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.DropTable<ReconditionValue>();
            conn.DropTable<HistoryValue>();
        }
    }
}