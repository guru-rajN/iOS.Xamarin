using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppraisalApp.Models;
using CoreGraphics;
using ExtAppraisalApp;
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

        }

        partial void BtnAddNew_Activated(UIBarButtonItem sender)
        {
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // hide keyboard on touch outside area
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(g);

            VinSearch.Text = VinSearch.Text.ToUpper();
            VinSearch.TextChanged += (sender, e) =>
            {
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

            };

            VinSearch.ShouldBeginEditing += VinSearch_ShouldBeginEditing;
            VinSearch.ShouldEndEditing += VinSearch_ShouldEndEditing;
            VinSearch.CancelButtonClicked += VinSearch_CancelButtonClicked;
            VinSearch.TintColor = UIColor.FromRGB(95, 135, 95);

            AppraisalTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            AppraisalTableView.RowHeight = 120f;
            AppraisalTableView.EstimatedRowHeight = 120.0f;
            AppraisalTableView.BackgroundColor = UIColor.LightGray;

            if (AppDelegate.appDelegate.CustomerLogin)
            {
                if (null != AppDelegate.appDelegate.CustomerAppraisalLogs && AppDelegate.appDelegate.CustomerAppraisalLogs.Count > 0)
                {
                    CustomerAppLogsList = AppDelegate.appDelegate.CustomerAppraisalLogs;
                    var completedVehicle = CustomerAppLogsList.FindAll((CustomerAppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new CustomerApprasialLogTVS(completedVehicle);
                }else{
                    CustomerAppLogsList = ServiceFactory.getWebServiceHandle().FetchCustomerAppraisalLogs(AppDelegate.appDelegate.GuestLastName, AppDelegate.appDelegate.GuestEmail, AppDelegate.appDelegate.GuestPhone);
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
                    apploglist = ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);
                    var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                    AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);  
                }


            }

            AppraisalTableView.ReloadData();
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