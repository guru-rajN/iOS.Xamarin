using AppraisalApp.Models;
using AppraisalApp.Utilities;
using CoreGraphics;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            //Utility.ShowLoadingIndicator(this.SplitViewController.View, "Saving...", true);

            SaveFactoryOptions(AppDelegate.appDelegate.vehicleID,AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId);

            // Navigate to Aftermarket
            if (null == masterViewController)
            {
                if (!UserInterfaceIdiomIsPhone)
                    masterViewController = (MasterViewController)((UINavigationController)SplitViewController.ViewControllers[0]).TopViewController;
            }

            ViewWorker viewWorker = new ViewWorker();
            viewWorker.WorkerDelegate = (ExtAppraisalApp.Utilities.WorkerDelegateInterface)masterViewController;

            if (!AppDelegate.appDelegate.IsAllDataSaved)
            {
                if (!AppDelegate.appDelegate.IsFactorySaved)
                {
                    viewWorker.PerformNavigation(3);
                    if (AppDelegate.appDelegate.IsFactoryOptions && AppDelegate.appDelegate.WizardPageNo < 2)
                        viewWorker.ShowPartialDoneImg(3);

                    viewWorker.ShowDoneImg(2);

                    if (UserInterfaceIdiomIsPhone)
                    {
                        var dictionary = new NSDictionary(new NSString("1"), new NSString("FactoryOptions"));

                        NSNotificationCenter.DefaultCenter.PostNotificationName((Foundation.NSString)"MenuSelection", null, dictionary);
                    }
                }
                else
                {
                    viewWorker.PerformNavigation(3);
                }
            }
            else
            {
                var storyboard = UIStoryboard.FromName("Main", null);
                SummaryViewController summaryViewController = (SummaryViewController)storyboard.InstantiateViewController("SummaryViewController");
                UINavigationController uINavigationController = new UINavigationController(summaryViewController);
                uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
                uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
                this.NavigationController.PresentViewController(uINavigationController, true, null);
            }

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
            FactoryOptionTableView.RowHeight = UITableView.AutomaticDimension;
            if (!AppDelegate.appDelegate.IsAllDataSaved)
            {
                if (UserInterfaceIdiomIsPhone)
                {
                    BtnSave.Title = "Save";
                }
                else
                {
                    BtnSave.Title = "Next";
                }

            }
            else
            {
                BtnSave.Title = "Save";
            }

            Utility.ShowLoadingIndicator(this.SplitViewController.View, "Retrieving...", true);

            GetFactoryOptionsKBB(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, AppDelegate.appDelegate.trimId);


        }

       
        Task GetFactoryOptionsKBB(long Vehicle_ID,short store_ID,short Invtr_ID,int Trim_ID)
        {
            return Task.Factory.StartNew(() => { 
                if(AppDelegate.appDelegate.fctoption == null || AppDelegate.appDelegate.fctoption.Count ==0){
                    AppDelegate.appDelegate.fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(Vehicle_ID, store_ID, Invtr_ID, Trim_ID);
                }
           
                InvokeOnMainThread(() =>
                {
                    Utility.HideLoadingIndicator(this.SplitViewController.View);
                    var width = View.Bounds.Width;
                    var height = View.Bounds.Height;

                    table = new UITableView(new CGRect(0, 0, width, height));
                    table.AutoresizingMask = UIViewAutoresizing.All;

                    table.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

                    List<string> tableItems = new List<string>();
                    foreach (var category in AppDelegate.appDelegate.fctoption)
                    {
                        if(category.Caption == "Seats" || category.Caption =="Steering" || category.Caption =="Lighting and Mirrors"){
                            
                        }
                        else{
                            string str = category.Caption;
                            tableItems.Add(str);
                        }
                    }
                    table.Source = new TableSource(tableItems.ToArray(), this);
                    table.TableFooterView = new UIView(CoreGraphics.CGRect.Empty);
                    Add(table);

                });

            });
                    

        }
        Task SaveFactoryOptions(long Vehicle_ID, short store_ID, short Invtr_ID){
            return Task.Factory.StartNew(() => {
                SIMSResponseData responseStatus;
                VehicleFactoryOptionsKBB vehicleFactoryOptions = new VehicleFactoryOptionsKBB();
               
                    
                    vehicleFactoryOptions.VehicleId = Vehicle_ID;
                    vehicleFactoryOptions.StoreId = store_ID;
                    vehicleFactoryOptions.InvtrId = Invtr_ID;


                    List<FactoryOptionsKBB> listfactory = new List<FactoryOptionsKBB>();
                    foreach (var items in AppDelegate.appDelegate.fctoption)
                    {
                        foreach (var item in items.questions)
                        {
                            FactoryOptionsKBB factory = new FactoryOptionsKBB();
                            factory.categoryName = item.categoryName;
                            factory.displayName = item.displayName;
                            factory.isSelected = item.isSelected;
                            factory.optionId = item.optionId;
                            factory.optionKindId = "KBB";
                            listfactory.Add(factory);


                        }
                    }

                    vehicleFactoryOptions.data = listfactory;
                    responseStatus = ServiceFactory.getWebServiceHandle().SaveFactoryOptions(vehicleFactoryOptions);

                //InvokeOnMainThread(() =>
                //{
                //    Utility.HideLoadingIndicator(this.SplitViewController.View);
                //});


            });
          
        }
    }
}