﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AppraisalApp.Models;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Models;
using Firebase.Core;
using Foundation;
using UIKit;

namespace ExtAppraisalApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate, IUISplitViewControllerDelegate
    {
        // class-level declarations
        bool IsLoggedIn = false;
        public string AlertSA = null;


        public override UIWindow Window
        {
            get;
            set;
        }
        public bool photoAcesss = false;
        public PhotoGetResponse.Datum getphotoResponses = new PhotoGetResponse.Datum();
        //Photographs Online URL
        public string LeftCarImageURL;
        public string RightCarImageURL;
        public string SeatCarImageURL;
        public string BackSeatImageURL;
        public string FrontCarImageURL;
        public string BackCarImageURL;
        public string DashBoardImageURL;
        public string VINImageURL;
        public string RimImageURL;
        public string OdometerImageURL;
        public string AdditionalPhoto0;
        public string AdditionalPhoto1;
        public string AdditionalPhoto2;
        public string photoButtonClicked = null;
        public static AppDelegate appDelegate { get; private set; }
        public string DeviceToken = null;
        public string APNSAlert = null;
        public long vehicleID { get; set; }
        public short storeId { get; set; }
        public short invtrId { get; set; }
        public int trimId { get; set; }
        public int mileage { get; set; }
        public List<FactoryOptionsSection> fctoption = new List<FactoryOptionsSection>();
        public string FactoryOptionSelected { get; set; }
        public string AMFactoryOptionSelected { get; set; }

        public List<FactoryOptionsKBB> factoryOptionsKBB = new List<FactoryOptionsKBB>();
        public string prospectId { get; set; }
        public AfterMarketOptions afterMarketOptions = new AfterMarketOptions();
        public List<ReconResponse.Datum> reconResponse = new List<ReconResponse.Datum>();

        public Vehicle cacheVehicleDetails { get; set; } // Change after SQL database 

        public VinVehicleDetailsKBB cacheDecodeVinDetails { get; set; }

        public KBBColorDetails cacheExteriorColorDetails { get; set; }
        public string FirebaseKey = "AIzaSyCYW0MK5MLd3xoxvXqoLHLWVHWmtILY1uw";
        public string FirebaseValue = "extappraisalapp-c7d3d.firebaseio.com";

        public bool IsZipCodeValid = false;

        public bool IsInfoSaved = false;
        public bool IsFactorySaved = false;
        public bool IsAftermarketSaved = false;
        public bool IsHistorySaved = false;
        public bool IsReconditionsSaved = false;
        public bool IsPhotosSaved = false;

        public bool IsAllDataSaved = false;

        public string AppleDeviceToken = null;

        public string APNSAlertStore = null;
        public string APNSAlertLon = null;
        public string APNSAlertLat = null;
        public string APNSAlertAddressa = null;
        public string APNSAlertAddressb = null;
        public string APNSAlertZip = null;
        public string SACvalue = null;
        public bool APNSSACDB = false;
        //Photographs validations
        public bool LeftCarImageUploaded = false;
        public bool RightCarImageUploaded = false;
        public bool SeatCarImageUploaded = false;
        public bool BackSeatImageUploaded = false;
        public bool FrontCarImageUploaded = false;
        public bool BackCarImageUploaded = false;
        public bool DashBoardImageUploaded = false;
        public bool VINImageUplaoded = false;
        public bool RimImageUploaded = false;
        public bool OdometerImageUploaded = false;

        public bool IsFactoryOptions = false;
        public bool IsHistory = false;
        public bool IsPhotos = false;
        public int WizardPageNo = 0;
        public bool IsCustomer = false;

        public string Phone = null;
        public string Email = null;
        public string Subject = null;
        public string Body = null;


        public string GuestLastName;
        public string GuestEmail;
        public string GuestPhone;

        public List<CustomerAppraisalLogEntity> CustomerAppraisalLogs;
        public List<AppraisalLogEntity> AppraisalsLogs;
        public bool CustomerLogin = false;
        public bool DealerLogin = false;


        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            try{                 AppDelegate.appDelegate = this;                 NSString[] keys = { new NSString(FirebaseKey) } ;                 NSObject[] values = { new NSString(FirebaseValue) } ;                 var parameters = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values, keys, keys.Length);                 Firebase.Analytics.Loader loader1 = new Firebase.Analytics.Loader();                 Firebase.InstanceID.Loader loader2 = new Firebase.InstanceID.Loader();                  App.Configure();                 //Firebase.Core.App.Configure();                 Firebase.Analytics.Analytics.LogEvent("first_open", parameters);               }             catch(Exception ex)             {                 Console.WriteLine(ex);             } 
            // Override point for customization after application launch.
            AppDelegate.appDelegate = this;

            GetCustomerLoginRecords();
            GetDealerLoginRecords();

            if (CustomerLogin || DealerLogin)
            {
                var storyboard = UIStoryboard.FromName("Main", null);
                var splitViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
                Window.RootViewController = splitViewController;
            }
            else
            {
                if (!IsLoggedIn)
                {
                    var storyboard = UIStoryboard.FromName("Main", null);
                    var loginViewController = storyboard.InstantiateViewController("LoginViewController");
                    Window.RootViewController = loginViewController;
                }
                else
                {
                    var splitViewController = (UISplitViewController)Window.RootViewController;
                    var navigationController = (UINavigationController)splitViewController.ViewControllers[1];
                    navigationController.TopViewController.NavigationItem.LeftBarButtonItem = splitViewController.DisplayModeButtonItem;
                    splitViewController.WeakDelegate = this;
                    Window.RootViewController = splitViewController;
                }
            }



            // If not required for your application you can safely delete this method
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                                   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                                   new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }


            return true;
        }


        private void GetCustomerLoginRecords()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.CreateTable<CustomerValue>();

            var existingRecord = (conn.Table<CustomerValue>().Where(c => c.id == 1)).SingleOrDefault();

            if (null != existingRecord)
            {
                CustomerLogin = existingRecord.CustomerLogin;
                GuestLastName = existingRecord.CustomerLastName;
                GuestEmail = existingRecord.CustomerEmail;
                GuestPhone = existingRecord.CustomerPhone;
                storeId = existingRecord.StoreId;
            }

        }

        private void GetDealerLoginRecords()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.CreateTable<DealerValue>();

            var existingRecord = (conn.Table<DealerValue>().Where(c => c.id == 1)).SingleOrDefault();

            if (null != existingRecord)
            {
                DealerLogin = existingRecord.DealerLogin;
                storeId = existingRecord.StoreId;
            }

        }


        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        [Export("splitViewController:collapseSecondaryViewController:ontoPrimaryViewController:")]
        public bool CollapseSecondViewController(UISplitViewController splitViewController, UIViewController secondaryViewController, UIViewController primaryViewController)
        {
            if (secondaryViewController.GetType() == typeof(UINavigationController) &&
                ((UINavigationController)secondaryViewController).TopViewController.GetType() == typeof(DetailViewController) &&
                ((DetailViewController)((UINavigationController)secondaryViewController).TopViewController).DetailItem == null)
            {
                // Return YES to indicate that we have handled the collapse by doing nothing; the secondary controller will be discarded.
                return true;
            }
            return false;
        }

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            if (UserInterfaceIdiomIsPhone)
            {
                return UIInterfaceOrientationMask.Portrait;
            }
            else
            {
                return UIInterfaceOrientationMask.All;
            }

        }

        public override void RegisteredForRemoteNotifications( UIApplication application, NSData deviceToken)
        {
            // Get current device token
            var DeviceToken = deviceToken.Description;

            if (!string.IsNullOrWhiteSpace(DeviceToken))
            {
                DeviceToken = DeviceToken.Trim('<').Trim('>');
            }

            AppleDeviceToken = DeviceToken;
            //UIAlertView ALERT = new UIAlertView(null, DeviceToken.ToString(), null, "ok", null);

            //ALERT.Show();
            // Get previous device token

            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

            // Has the token changed?
            if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
            {
                //TODO: Put your own logic here to notify your server that the device token has changed/been created!
            }

            // Save new device token
            NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)

        {

            NSDictionary aps = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;
            // NSDictionary add = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;



            string alert = string.Empty;
            string message = string.Empty;
            string lon = string.Empty;
            string lat = string.Empty;
            string addressa = string.Empty;
            string addressb = string.Empty;
            string zip = string.Empty;

            if (aps.ContainsKey(new NSString("alert")))

                alert = (aps[new NSString("alert")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("store")))

                message = (aps[new NSString("store")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("lon")))

                lon = (aps[new NSString("lon")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("lat")))

                lat = (aps[new NSString("lat")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("addressa")))

                addressa = (aps[new NSString("addressa")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("addressb")))

                addressb = (aps[new NSString("addressb")] as NSString).ToString();

            if (aps.ContainsKey(new NSString("zip")))

                zip = (aps[new NSString("zip")] as NSString).ToString();
            

            if (!string.IsNullOrEmpty(alert))
            {

                APNSAlert = alert.ToString();
                APNSAlertStore = message.ToString();
                APNSAlertLat = lat.ToString();
                APNSAlertLon = lon.ToString();
                APNSAlertAddressa = addressa.ToString();
                APNSAlertAddressb = addressb.ToString();
                APNSAlertZip = zip.ToString();
                var dictionary = new NSDictionary(new NSString("1"), new NSString(APNSAlert));
                NSNotificationCenter.DefaultCenter.PostNotificationName("PushNotify", null, dictionary);
                NSNotificationCenter.DefaultCenter.PostNotificationName("ShowPushNotifyData", null);
            }

        }




        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            //new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
        }
    }
}
