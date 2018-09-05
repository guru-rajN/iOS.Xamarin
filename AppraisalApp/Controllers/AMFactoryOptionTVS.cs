using System;
using System.Collections.Generic;
using ExtAppraisalApp.Models;
using Foundation;
using UIKit;

namespace AppraisalApp
{
    internal class AMFactoryOptionTVS : UITableViewSource
    {
        private List<ReconQuestionsKBB> reconQuestions;

        public AMFactoryOptionTVS(List<ReconQuestionsKBB> reconQuestions)
        {
            this.reconQuestions = reconQuestions;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var amcell = (AfterMarketDetailCell)tableView.DequeueReusableCell("Cell_id", indexPath);
            var amfactoryOption = reconQuestions[indexPath.Row];
            amcell.UpdateCell(amfactoryOption);
            return amcell;
        }

   

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return reconQuestions.Count;
        }
    }
}