using System.Collections.Generic;
using AppraisalApp.Models;
using ExtAppraisalApp.Models;
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
        public override UIWindow Window
        {
            get;
            set;
        }
        public static AppDelegate appDelegate { get; private set; }
        public string DeviceToken = null;
        public long vehicleID { get; set; }
        public short storeId { get; set; }
        public short invtrId { get; set; }
        public int trimId { get; set; }
        public int mileage { get; set; }
        public IEnumerable<FactoryOptionsSection> fctoption = new List<FactoryOptionsSection>();
        public string FactoryOptionSelected { get; set; }
        public string AMFactoryOptionSelected { get; set; }

        public List<FactoryOptionsKBB> factoryOptionsKBB = new List<FactoryOptionsKBB>();
        public string prospectId { get; set; }
        public AfterMarketOptions afterMarketOptions = new AfterMarketOptions();

        public Vehicle cacheVehicleDetails { get; set; } // Change after SQL database 

        public VinVehicleDetailsKBB cacheDecodeVinDetails { get; set; }

        public KBBColorDetails cacheExteriorColorDetails { get; set; }

        public bool IsZipCodeValid = false;

        public bool IsInfoSaved = false;
        public bool IsFactorySaved = false;
        public bool IsAftermarketSaved = false;
        public bool IsHistorySaved = false;
        public bool IsReconditionsSaved = false;
        public bool IsPhotosSaved = false;

        public bool IsAllDataSaved = false;

        public string AppleDeviceToken = null;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            // Override point for customization after application launch.
            AppDelegate.appDelegate = this;

            if (!IsLoggedIn)
            {
                var storyboard = UIStoryboard.FromName("Main", null);
                var loginViewController = storyboard.InstantiateViewController("LoginViewController");
                //loginViewController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
                //this.ro(loginViewController, null);
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
            if(UserInterfaceIdiomIsPhone){
                return UIInterfaceOrientationMask.Portrait;
            }else{
                return UIInterfaceOrientationMask.All;
            }

        }

        public override void RegisteredForRemoteNotifications(
        UIApplication application, NSData deviceToken)
        {
            // Get current device token
            var DeviceToken = deviceToken.Description;

            if (!string.IsNullOrWhiteSpace(DeviceToken))
            {
                DeviceToken = DeviceToken.Trim('<').Trim('>');
            }

            AppleDeviceToken = DeviceToken;
            UIAlertView ALERT = new UIAlertView(null, DeviceToken.ToString(), null, "ok", null);

            ALERT.Show();
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
        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            //new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
        }
    }
}

