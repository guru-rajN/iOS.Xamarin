using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppraisalApp.Models;
using CoreGraphics;
using ExtAppraisalApp;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace AppraisalApp
{
    public partial class AppraisalLogViewController : UIViewController
    {
        void VinSearch_CancelButtonClicked(object sender, EventArgs e)
        {
            VinSearch.EndEditing(true);
            VinSearch.Text = "";

            string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();

            if (segmentID == "0")
            {
                if (AppDelegate.appDelegate.CustomerLogin){

                    var Appcompleted = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(Appcompleted);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();  
                }else{
                    var Appcompleted = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(Appcompleted);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();  
                }

            }
            else
            {
                if (AppDelegate.appDelegate.CustomerLogin){
                    var appPending = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status != "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(appPending);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData(); 
                }else{
                    var appPending = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(appPending);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData(); 
                }

            }
        }


        bool VinSearch_ShouldEndEditing(UISearchBar searchBar)
        {
            VinSearch.SetShowsCancelButton(false, true);
            return true;
        }


        bool VinSearch_ShouldBeginEditing(UISearchBar searchBar)
        {
            VinSearch.SetShowsCancelButton(true, true);
            return true;
        }


        partial void BtnCancel_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("LoginViewController");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;

            dropDB();

        }

        private void dropDB()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.DropTable<CustomerValue>();
            conn.DropTable<DealerValue>();
        }

        partial void BtnAddNew_Activated(UIBarButtonItem sender)
        {
            AppDelegate.appDelegate.vehicleID = 0;
            AppDelegate.appDelegate.invtrId = 0;
            // Navigate DecodeView
            var storyboard = UIStoryboard.FromName("Main", null);
            DecodeViewController decodeViewController = (DecodeViewController)storyboard.InstantiateViewController("DecodeViewController");
            UINavigationController uINavigationController = new UINavigationController(decodeViewController);
            uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
            this.NavigationController.PresentViewController(uINavigationController, true, null);

        }

        List<AppraisalLogEntity> apploglist = new List<AppraisalLogEntity>();
        List<CustomerAppraisalLogEntity> CustomerAppLogsList = new List<CustomerAppraisalLogEntity>();

        partial void Segment_Changed(UISegmentedControl sender)
        {
            string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
            if (segmentID == "0")
            {
                if (AppDelegate.appDelegate.CustomerLogin){ 
                    var completedVehicle = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(completedVehicle);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();
                }else{
                    var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();
                }

            }
            else
            {
                if(AppDelegate.appDelegate.CustomerLogin){
                    var completedVehicle = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status != "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(completedVehicle);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();
                }else{
                    var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                    AppraisalTableView.RowHeight = 120f;
                    AppraisalTableView.EstimatedRowHeight = 120.0f;
                    AppraisalTableView.BackgroundColor = UIColor.LightGray;
                    AppraisalTableView.ReloadData();
                }

            }
        }


        public AppraisalLogViewController(IntPtr handle) : base(handle)
        {
        }

        async public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"ShowPushNotifyData", ShowAPNSView);

            // hide keyboard on touch outside area
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(g);

            VinSearch.Text = VinSearch.Text.ToUpper();
            VinSearch.TextChanged += (sender, e) =>
            {
                if(AppDelegate.appDelegate.CustomerLogin){

                    if (VinSearch.Text.Length > 0)
                    {
                        var VinSearchEntity = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.VIN.Contains(VinSearch.Text.Trim()));
                        AppraisalTableView.Source = new CustomerApprasialLogTVS(VinSearchEntity);
                        AppraisalTableView.RowHeight = 120f;
                        AppraisalTableView.EstimatedRowHeight = 120.0f;
                        AppraisalTableView.BackgroundColor = UIColor.LightGray;
                        AppraisalTableView.ReloadData();
                    }//Method get called when search started 
                    else
                    {
                        string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
                        if (segmentID == "0")
                        {
                            var Appcompleted = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                            AppraisalTableView.Source = new CustomerApprasialLogTVS(Appcompleted);
                            AppraisalTableView.RowHeight = 120f;
                            AppraisalTableView.EstimatedRowHeight = 120.0f;
                            AppraisalTableView.BackgroundColor = UIColor.LightGray;
                            AppraisalTableView.ReloadData();
                        }
                        else
                        {
                            var appPending = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status != "CA");
                            AppraisalTableView.Source = new CustomerApprasialLogTVS(appPending);
                            AppraisalTableView.RowHeight = 120f;
                            AppraisalTableView.EstimatedRowHeight = 120.0f;
                            AppraisalTableView.BackgroundColor = UIColor.LightGray;
                            AppraisalTableView.ReloadData();
                        }
                    }

                }else{
                    
                    if (VinSearch.Text.Length > 0)
                    {
                        var VinSearchEntity = apploglist.FindAll((AppraisalLogEntity obj) => obj.VIN.Contains(VinSearch.Text.Trim()));
                        AppraisalTableView.Source = new ApprasialLogTVS(VinSearchEntity);
                        AppraisalTableView.RowHeight = 120f;
                        AppraisalTableView.EstimatedRowHeight = 120.0f;
                        AppraisalTableView.BackgroundColor = UIColor.LightGray;
                        AppraisalTableView.ReloadData();
                    }//Method get called when search started 
                    else
                    {
                        string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
                        if (segmentID == "0")
                        {
                            var Appcompleted = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                            AppraisalTableView.Source = new ApprasialLogTVS(Appcompleted);
                            AppraisalTableView.RowHeight = 120f;
                            AppraisalTableView.EstimatedRowHeight = 120.0f;
                            AppraisalTableView.BackgroundColor = UIColor.LightGray;
                            AppraisalTableView.ReloadData();
                        }
                        else
                        {
                            var appPending = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                            AppraisalTableView.Source = new ApprasialLogTVS(appPending);
                            AppraisalTableView.RowHeight = 120f;
                            AppraisalTableView.EstimatedRowHeight = 120.0f;
                            AppraisalTableView.BackgroundColor = UIColor.LightGray;
                            AppraisalTableView.ReloadData();
                        }
                    }
                }
            };

            VinSearch.ShouldBeginEditing += VinSearch_ShouldBeginEditing;
            VinSearch.ShouldEndEditing += VinSearch_ShouldEndEditing;
            VinSearch.CancelButtonClicked += VinSearch_CancelButtonClicked;
            VinSearch.TintColor = UIColor.FromRGB(95, 135, 95);

            AppraisalTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            AppraisalTableView.RowHeight = 120f;
            AppraisalTableView.EstimatedRowHeight = 120.0f;
            AppraisalTableView.BackgroundColor = UIColor.LightGray;

            GetCustomerLoginRecords();
            GetDealerLoginRecords();

            if (AppDelegate.appDelegate.CustomerLogin)
            {
                if (null != AppDelegate.appDelegate.CustomerAppraisalLogs && AppDelegate.appDelegate.CustomerAppraisalLogs.Count > 0)
                {
                    CustomerAppLogsList = AppDelegate.appDelegate.CustomerAppraisalLogs;
                    var completedVehicle = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(completedVehicle);

                }else{
                    Utility.ShowLoadingIndicator(this.View, "", true);

                    CustomerAppLogsList = await CallGuestAppraisalLogService(AppDelegate.appDelegate.GuestLastName, AppDelegate.appDelegate.GuestEmail, AppDelegate.appDelegate.GuestPhone);

                    Utility.HideLoadingIndicator(this.View);

                    var completedVehicle = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(completedVehicle);
                }
            }
            else
            {
                if(null != AppDelegate.appDelegate.AppraisalsLogs && AppDelegate.appDelegate.AppraisalsLogs.Count > 0)
                {
                    apploglist = AppDelegate.appDelegate.AppraisalsLogs;
                    var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);  

                }else{
                    

                    Utility.ShowLoadingIndicator(this.View, "", true);

                    apploglist = await CallDealerAppraisalLogService();

                    Utility.HideLoadingIndicator(this.View);

                    var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);  
                }


            }

            AppraisalTableView.ReloadData();
        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"ShowPushNotifyData");
            base.ViewDidDisappear(animated);
        }

        private void ShowAPNSView(NSNotification obj)
        {

            try
            {

                UIStoryboard board = UIStoryboard.FromName("Main", null);
                APNSViewController ctrl = (APNSViewController)board.InstantiateViewController("APNSViewController");
                UINavigationController navigationController = new UINavigationController(ctrl);
                navigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
                navigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
                AppDelegate.appDelegate.Window.RootViewController.PresentViewController(navigationController, true, null);

            }
            catch (Exception exc)
            {
                Debug.WriteLine("Exception occurred :: " + exc.Message);
            }



        }

        private void GetCustomerLoginRecords()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.CreateTable<CustomerValue>();

            var existingRecord = (conn.Table<CustomerValue>().Where(c => c.id == 1)).SingleOrDefault();

            if(null != existingRecord){
                AppDelegate.appDelegate.CustomerLogin = existingRecord.CustomerLogin;
                AppDelegate.appDelegate.GuestLastName = existingRecord.CustomerLastName;
                AppDelegate.appDelegate.GuestEmail = existingRecord.CustomerEmail;
                AppDelegate.appDelegate.GuestPhone = existingRecord.CustomerPhone;
                AppDelegate.appDelegate.storeId = existingRecord.StoreId;
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
                AppDelegate.appDelegate.DealerLogin = existingRecord.DealerLogin;
                AppDelegate.appDelegate.storeId = existingRecord.StoreId;
            }

        }


        Task<List<CustomerAppraisalLogEntity>> CallGuestAppraisalLogService(string lastname, string email, string phone)
        {

            return Task<List<CustomerAppraisalLogEntity>>.Factory.StartNew(() =>
            {
                List<CustomerAppraisalLogEntity> customerAppraisalLogs = new List<CustomerAppraisalLogEntity>();
                customerAppraisalLogs = ServiceFactory.getWebServiceHandle().FetchCustomerAppraisalLogs(lastname, email, phone);

                return customerAppraisalLogs;


            });
        }

        Task<List<AppraisalLogEntity>> CallDealerAppraisalLogService()
        {
            return Task<List<AppraisalLogEntity>>.Factory.StartNew(() =>
            {
                List<AppraisalLogEntity> dealerAppraisalLogs = new List<AppraisalLogEntity>();
                dealerAppraisalLogs = ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);

                return dealerAppraisalLogs;


            });
        }

        internal class CustomerApprasialLogTVS : UITableViewSource
        {
            //protected string[] tableItems;
            private List<CustomerAppraisalLogEntity> apploglist;

            public CustomerApprasialLogTVS(List<CustomerAppraisalLogEntity> apploglist)
            {
                this.apploglist = apploglist;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var amcell = (AppraisalLogCell)tableView.DequeueReusableCell("Cell_id", indexPath);
                var amfactoryOption = apploglist[indexPath.Row];
                amcell.UpdateCustomerCell(amfactoryOption);

                return amcell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return apploglist.Count;
            }
            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var result = apploglist[indexPath.Row];
                AppDelegate.appDelegate.storeId = result.Store_ID;
                AppDelegate.appDelegate.vehicleID = result.Vehicle_ID;
                AppDelegate.appDelegate.invtrId = result.Invtr_ID;
                AppDelegate.appDelegate.cacheVehicleDetails = null;
                AppDelegate.appDelegate.afterMarketOptions = null;
                AppDelegate.appDelegate.fctoption = null;
                AppDelegate.appDelegate.mileage = Convert.ToInt32(result.Mileage);
                var storyboard = UIStoryboard.FromName("Main", null);
                var loginViewController = storyboard.InstantiateViewController("SplitViewControllerID");
                AppDelegate.appDelegate.Window.RootViewController = loginViewController;

            }
        }
    }
}