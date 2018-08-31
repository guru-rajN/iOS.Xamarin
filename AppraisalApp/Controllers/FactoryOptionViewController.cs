using AppraisalApp.Models;
using AppraisalApp.Utilities;
using CoreGraphics;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class FactoryOptionViewController : UIViewController
    {
        private MasterViewController masterViewController;

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        partial void BtnSave_Activated(UIBarButtonItem sender)
        {
            SaveFactoryOptions();

            // Navigate to Aftermarket
            if (null == masterViewController)
            {
                if (!UserInterfaceIdiomIsPhone)
                    masterViewController = (MasterViewController)((UINavigationController)SplitViewController.ViewControllers[0]).TopViewController;
            }

            ViewWorker viewWorker = new ViewWorker();
            viewWorker.WorkerDelegate = (ExtAppraisalApp.Utilities.WorkerDelegateInterface)masterViewController;
            viewWorker.PerformNavigation(3);
            viewWorker.ShowPartialDoneImg(3);
            viewWorker.ShowDoneImg(2);

            AppDelegate.appDelegate.IsFactorySaved = true;


        }

        UITableView table;
        IEnumerable<FactoryOptionsSection> fctoption = new List<FactoryOptionsSection>();
        public FactoryOptionViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {

       

            base.ViewDidLoad();
            var width = View.Bounds.Width;
            var height = View.Bounds.Height;

            table = new UITableView(new CGRect(0, 0, width, height));
            table.AutoresizingMask = UIViewAutoresizing.All;

            table.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            AppDelegate.appDelegate.fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, 432110);
            List<string> tableItems = new List<string>();
            foreach(var category in AppDelegate.appDelegate.fctoption){
                string str = category.Caption;
                tableItems.Add(str);
            }
          
            table.Source = new TableSource(tableItems.ToArray(), this);
            Add(table);




        }

        public void SaveFactoryOptions(){
            SIMSResponseData responseStatus;
            VehicleFactoryOptionsKBB vehicleFactoryOptions = new VehicleFactoryOptionsKBB();
            vehicleFactoryOptions.VehicleId = AppDelegate.appDelegate.vehicleID;
            vehicleFactoryOptions.StoreId = AppDelegate.appDelegate.storeId;
            vehicleFactoryOptions.InvtrId = AppDelegate.appDelegate.invtrId;

            vehicleFactoryOptions.data = AppDelegate.appDelegate.factoryOptionsKBB;

            //Logic to add the Selected Factory options

            responseStatus= ServiceFactory.getWebServiceHandle().SaveFactoryOptions(vehicleFactoryOptions);
        }


    }
}