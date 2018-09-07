using System;
using System.Collections.Generic;
using AppraisalApp.Models;
using Foundation;
using UIKit;

namespace AppraisalApp
{
    internal class ApprasialLogTVS : UITableViewSource
    {
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
    }
}