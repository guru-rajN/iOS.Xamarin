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
        public AppraisalLogViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            List<AppraisalLogEntity> apploglist = new List<AppraisalLogEntity>();
            apploglist=ServiceFactory.getWebServiceHandle().FetchAppraisalLog(AppDelegate.appDelegate.storeId);


            AppraisalTableView.Source = new ApprasialLogTVS(apploglist);
            //AppraisalTableView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            //AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
            //AppraisalTableView.ScrollEnabled = true;
            //AppraisalTableView.ShowsVerticalScrollIndicator = true;
            //AppraisalTableView.ShowsHorizontalScrollIndicator = true;
            //AppraisalTableView.ReloadData();


            //AppraisalTableView.DataSource = new ApprasialLogTVS(apploglist);
            //AppraisalTableView.Delegate = new ApprasialLogTVS(apploglist);
            AppraisalTableView.RowHeight = UITableView.AutomaticDimension;
            AppraisalTableView.EstimatedRowHeight = 40f;
            AppraisalTableView.ReloadData();
        }
    }
}