using System;
using System.Collections.Generic;
using AppraisalApp.Models;
using ExtAppraisalApp;
using Foundation;
using UIKit;

namespace AppraisalApp
{
    internal class ApprasialLogTVS : UITableViewSource
    {
        //protected string[] tableItems;
        private List<AppraisalLogEntity> apploglist;

        public ApprasialLogTVS(List<AppraisalLogEntity> apploglist)
        {
            this.apploglist = apploglist;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var amcell = (AppraisalLogCell)tableView.DequeueReusableCell("Cell_id", indexPath);
            var amfactoryOption = apploglist[indexPath.Row];
            amcell.UpdateCell(amfactoryOption);

            return amcell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return apploglist.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var result =apploglist[indexPath.Row];
            AppDelegate.appDelegate.storeId = result.Store_ID;
            AppDelegate.appDelegate.vehicleID = result.Vehicle_ID;
            AppDelegate.appDelegate.invtrId = result.Invtr_ID;
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("SplitViewControllerID");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;

        }
    }
}