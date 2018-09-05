using System;
using System.Collections.Generic;
using AppraisalApp.Models;
using Foundation;
using UIKit;

namespace AppraisalApp
{
    internal class FactoryOptionTVS : UITableViewSource
    {
        private List<FactoryOptionsKBB> factoryOptionKBBList;

        public FactoryOptionTVS(List<FactoryOptionsKBB> factoryOptionKBBList)
        {
            this.factoryOptionKBBList = factoryOptionKBBList;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (FactoryOptionsDetailCell)tableView.DequeueReusableCell("Cell_id", indexPath);
            var factoryOption = factoryOptionKBBList[indexPath.Row];
            cell.UpdateCell(factoryOption);
            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return factoryOptionKBBList.Count;
        }
    }
}