using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;

namespace ExtAppraisalApp
{
    public partial class MasterViewController : UITableViewController , WorkerDelegateInterface
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

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if(segueIdentifier == "infoDetail"){
                
            }else if(segueIdentifier == "factoryDetail"){
                return false;
                
            }else if (segueIdentifier == "AfterMarketSegue")
            {
                return false;
            }else if (segueIdentifier == "historyDetails")
            {
                return false;
            }else if (segueIdentifier == "reconditionDetails")
            {
                return false;
            }else if (segueIdentifier == "photoDetails")
            {
                return false;
            }

            return true;

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
            InfoDoneImg.Image = UIImage.FromBundle("done.png");
        }

        public void performNavigate(int index)
        {
            Console.WriteLine("inside perform Navigation");
            switch(index){
                case 1 :
                    this.PerformSegue("infoDetail", this);
                    break;
                case 2:
                    this.PerformSegue("factoryDetail", this);
                    break;
                case 3:
                    this.PerformSegue("AfterMarketSegue", this);
                    break;
                case 4:
                    this.PerformSegue("historyDetails", this);
                    break;
                case 5:
                    this.PerformSegue("reconditionDetails", this);
                    break;
                case 6:
                    this.PerformSegue("photoDetails", this);
                    break;
                default:
                    this.PerformSegue("infoDetail", this);
                    break;
            }

        }

        public void ShowDoneIcon(int index)
        {
            switch (index){
                case 1:
                    InfoDoneImg.Hidden = false;
                    InfoDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                case 2:
                    FactoryOptionsDoneImg.Hidden = false;
                    FactoryOptionsDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                case 3:
                    AfterMarketDoneImg.Hidden = false;
                    AfterMarketDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                case 4:
                    HistoryDoneImg.Hidden = false;
                    HistoryDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                case 5:
                    ReconditionsDoneImg.Hidden = false;
                    ReconditionsDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                case 6:
                    PhotosDoneImg.Hidden = false;
                    PhotosDoneImg.Image = UIImage.FromBundle("done.png");
                    break;
                default:
                    break;

            }
        }

        public void ShowPartialDoneIcon(int index){
            switch (index)
            {
                case 1:
                    InfoDoneImg.Hidden = false;
                    InfoDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                case 2:
                    FactoryOptionsDoneImg.Hidden = false;
                    FactoryOptionsDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                case 3:
                    AfterMarketDoneImg.Hidden = false;
                    AfterMarketDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                case 4:
                    HistoryDoneImg.Hidden = false;
                    HistoryDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                case 5:
                    ReconditionsDoneImg.Hidden = false;
                    ReconditionsDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                case 6:
                    PhotosDoneImg.Hidden = false;
                    PhotosDoneImg.Image = UIImage.FromBundle("partial_done.png");
                    break;
                default:
                    break;

            }
        }
    }
}
