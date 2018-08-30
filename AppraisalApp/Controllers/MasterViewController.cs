using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using ExtAppraisalApp.Services;

namespace ExtAppraisalApp
{
    public partial class MasterViewController : UITableViewController , DetailViewWorkerDelegate
    {

        public DetailViewController DetailViewController { get; set; }

        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "1999 Chevrolet";


            TableView.TableFooterView = new UIView(new CGRect(0,0,0,0));

            InfoDoneImg.Hidden = true;
            FactoryOptionsDoneImg.Hidden = true;
            AfterMarketDoneImg.Hidden = true;
            HistoryDoneImg.Hidden = true;
            ReconditionsDoneImg.Hidden = true;
            PhotosDoneImg.Hidden = true;


        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("row selected :: " + indexPath.Row);

        }

        public override void ViewWillAppear(bool animated)
        {
            ClearsSelectionOnViewWillAppear = SplitViewController.Collapsed;
            base.ViewWillAppear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            Console.WriteLine("segue identifier " + segue.Identifier);

            if (segue.Identifier == "infoDetail")
            {
                var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                var indexPath = TableView.IndexPathForSelectedRow;

                controller.SetDetailItem(this);
                controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }


        partial void MasterViewCloseBtn_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("LoginViewController");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;
        }

        public void UpdateDatas(bool show)
        {
            Console.WriteLine("updated .. Masterview");
            InfoDoneImg.Hidden = show;
        }
    }
}
