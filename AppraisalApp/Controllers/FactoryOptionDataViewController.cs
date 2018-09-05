using AppraisalApp.Models;
using ExtAppraisalApp;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppraisalApp
{
    public partial class FactoryOptionDataViewController : UIViewController
    {
 
        partial void BtnClose_Activated(UIBarButtonItem sender)
        {
            this.DismissModalViewController(true);
        }

        public FactoryOptionDataViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            List<FactoryOptionsKBB> factoryOptionKBBList = new List<FactoryOptionsKBB>();
            foreach (var option in AppDelegate.appDelegate.fctoption)
            {
                if (option.Caption == AppDelegate.appDelegate.FactoryOptionSelected)
                {

                    foreach (var question in option.questions)
                    {
                        // FactoryOptionsKBB factoryOption = new FactoryOptionsKBB(); 
                        factoryOptionKBBList.Add(question);

                    }
                }
            }
            FactoryOptionTableView.Source = new FactoryOptionTVS(factoryOptionKBBList);
            FactoryOptionTableView.TableFooterView = new UIView(CoreGraphics.CGRect.Empty); 
            FactoryOptionTableView.RowHeight = UITableView.AutomaticDimension;
            FactoryOptionTableView.EstimatedRowHeight = 40f;
            FactoryOptionTableView.ReloadData();
        }
    }
}