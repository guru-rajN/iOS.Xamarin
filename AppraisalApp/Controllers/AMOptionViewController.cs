using ExtAppraisalApp;
using ExtAppraisalApp.Models;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppraisalApp
{
    public partial class AMOptionViewController : UIViewController
    {


        partial void BtnClose_Activated(UIBarButtonItem sender)
        {
            this.DismissModalViewController(true);
        }

        public AMOptionViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            List<ReconQuestionsKBB> reconQuestions = new List<ReconQuestionsKBB>();

            foreach (var option in AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions.data)
            {
                if (option.Caption == AppDelegate.appDelegate.AMFactoryOptionSelected)
                {

                    foreach (var question in option.questions)
                    {
                        reconQuestions.Add(question);
                    }
                }
            }

            AMOptionTableView.Source = new AMFactoryOptionTVS(reconQuestions);
            AMOptionTableView.RowHeight = UITableView.AutomaticDimension;
            AMOptionTableView.EstimatedRowHeight = 40f;
            AMOptionTableView.ReloadData();
        }
    }
}