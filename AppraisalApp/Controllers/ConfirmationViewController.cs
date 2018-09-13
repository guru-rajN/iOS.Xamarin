using Foundation;
using System;
using UIKit;
using AppraisalApp.Models;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using System.IO;

namespace ExtAppraisalApp
{
    public partial class ConfirmationViewController : UIViewController
    {
        public ConfirmationViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"SaveClicked", SaveDetails);
            base.ViewDidLoad();
        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"SaveClicked");
            base.ViewDidDisappear(animated);
        }

        private void SaveDetails(NSNotification obj)
        {
            // TO-DO : API calls integration

            ConfirmationMsg.Text = "We will get back to you.";

            SummaryMsg.Text = "Thank you for your appraisal submission. You have reached our appraisal center after hours however, we have added your appraisal request to the top of our queue and we will return a value to you as soon as we open tomorrow at 9am Eastern. Thank you.";


            dropSqlite();
            deletePhoto();
            saveDeviceToken();
            SaveOfferAPI();
        }

        private void SaveOfferAPI()
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