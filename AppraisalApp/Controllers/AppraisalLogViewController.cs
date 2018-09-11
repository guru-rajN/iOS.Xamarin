using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppraisalApp.Models;
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
        partial void BtnCancel_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("LoginViewController");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;

        }

        partial void BtnAddNew_Activated(UIBarButtonItem sender)
        {
            this.PerformSegue("decodeSegue", this);

        }

        List<AppraisalLogEntity> apploglist = new List<AppraisalLogEntity>();

        partial void Segment_Changed(UISegmentedControl sender)
        {
            string segmentID = AppraisalTypeSegment.SelectedSegment.ToString();
            if (segmentID == "0")
            {
                var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
                AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                AppraisalTableView.EstimatedRowHeight = 40f;
                AppraisalTableView.ReloadData();
            }
            else
            {
                var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status != "CA");
                AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
                AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

                AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
                AppraisalTableView.EstimatedRowHeight = 40f;
                AppraisalTableView.ReloadData();
            }
        }


        public AppraisalLogViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            apploglist=ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);


            var completedVehicle = apploglist.FindAll((AppraisalLogEntity obj) => obj.Status == "CA");
            AppraisalTableView.Source = new ApprasialLogTVS(completedVehicle);
               
            AppraisalTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
            AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
            AppraisalTableView.EstimatedRowHeight = 40f;
            AppraisalTableView.ReloadData();
        }
    }
}