using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using System.Diagnostics;
using ExtAppraisalApp.DB;
using System.IO;
using ExtAppraisalApp.Models;

namespace ExtAppraisalApp
{
    public partial class MasterViewController : UITableViewController, WorkerDelegateInterface
    {

        public DetailViewController DetailViewController { get; set; }

        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            TableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            InfoDoneImg.Hidden = true;
            FactoryOptionsDoneImg.Hidden = true;
            AfterMarketDoneImg.Hidden = true;
            HistoryDoneImg.Hidden = true;
            ReconditionsDoneImg.Hidden = true;
            PhotosDoneImg.Hidden = true;

            NSIndexPath path = NSIndexPath.FromRowSection(0, 0);
            this.TableView.SelectRow(path, true, UITableViewScrollPosition.None);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("row selected :: " + indexPath.Row);

        }

        public override NSIndexPath WillSelectRow(UITableView tableView, NSIndexPath indexPath)
        {

            if (indexPath.Row == 1 && !AppDelegate.appDelegate.IsFactorySaved)
            {
                return null;
            }
            else if (indexPath.Row == 2 && !AppDelegate.appDelegate.IsAftermarketSaved)
            {
                return null;
            }
            else if (indexPath.Row == 3 && !AppDelegate.appDelegate.IsHistorySaved)
            {
                return null;
            }
            else if (indexPath.Row == 4 && !AppDelegate.appDelegate.IsReconditionsSaved)
            {
                return null;
            }
            else if (indexPath.Row == 5 && !AppDelegate.appDelegate.IsPhotosSaved)
            {
                return null;
            }

            return indexPath;
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
            if (segueIdentifier == "infoDetail")
            {

            }
            else if (segueIdentifier == "factoryDetail" && !AppDelegate.appDelegate.IsFactorySaved)
            {
                return false;

            }
            else if (segueIdentifier == "AfterMarketSegue" && !AppDelegate.appDelegate.IsAftermarketSaved)
            {
                return false;
            }
            else if (segueIdentifier == "historyDetails" && !AppDelegate.appDelegate.IsHistorySaved)
            {
                return false;
            }
            else if (segueIdentifier == "reconditionDetails" && !AppDelegate.appDelegate.IsReconditionsSaved)
            {
                return false;
            }
            else if (segueIdentifier == "photoDetails" && !AppDelegate.appDelegate.IsPhotosSaved)
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

            dropSqlite();
            deletePhoto();
        }

        public void UpdateDatas(bool show)
        {
            Console.WriteLine("updated .. Masterview");
            InfoDoneImg.Hidden = show;
            InfoDoneImg.Image = UIImage.FromBundle("done.png");
        }

        public void performNavigate(int index)
        {
            NSIndexPath path = NSIndexPath.FromRowSection((index - 1), 0);
            this.TableView.SelectRow(path, true, UITableViewScrollPosition.None);
            switch (index)
            {
                case 1:
                    this.PerformSegue("infoDetail", this);
                    this.TableView.AllowsSelection = true;
                    break;
                case 2:
                    this.PerformSegue("factoryDetail", this);
                    this.TableView.AllowsSelection = true;
                    break;
                case 3:
                    this.PerformSegue("AfterMarketSegue", this);
                    this.TableView.AllowsSelection = true;
                    break;
                case 4:
                    this.PerformSegue("historyDetails", this);
                    this.TableView.AllowsSelection = true;
                    break;
                case 5:
                    this.PerformSegue("reconditionDetails", this);
                    this.TableView.AllowsSelection = true;
                    break;
                case 6:
                    this.PerformSegue("photoDetails", this);
                    this.TableView.AllowsSelection = true;
                    break;
                default:
                    this.PerformSegue("infoDetail", this);
                    this.TableView.AllowsSelection = true;
                    break;
            }

        }

        public void ShowDoneIcon(int index)
        {
            switch (index)
            {
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

        public void ShowPartialDoneIcon(int index)
        {
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

        private void deletePhoto()
        {

            var documentsDirectory = Environment.GetFolderPath
                                             (Environment.SpecialFolder.Personal);
            string buttonName = "right.png";
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "left.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "front.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "back.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "seat.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "seats.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "dashboard.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "rim.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "VIN.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "VIN.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);
            buttonName = "odometer.png";
            pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            System.IO.File.Delete(pngFilename);


        }

        private void dropSqlite()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            var conn = new SQLite.SQLiteConnection(DbPath);
            conn.DropTable<ReconditionValue>();
            conn.DropTable<HistoryValue>();
        }
    }
}
