using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using ExtAppraisalApp.Services;

namespace ExtAppraisalApp
{
    public partial class MasterViewController : UITableViewController
    {

        public DetailViewController DetailViewController { get; set; }

        DataSource dataSource;


        List<string> ItemList = new List<string>()
        {
            "Upload",
            "Conditions",
            "History",
            "AfterMarket",
            "Factory Options",
            "Information"
        };

        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "2017 Toyota Yaris iA";

            // Perform any additional setup after loading the view, typically from a nib.
            //NavigationItem.LeftBarButtonItem = EditButtonItem;

            //var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            //addButton.AccessibilityLabel = "addButton";
            //NavigationItem.RightBarButtonItem = addButton;

            //DetailViewController = (DetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;


            TableView.TableFooterView = new UIView(new CGRect(0,0,0,0));

            TableView.Source = dataSource = new DataSource(this);

            foreach(object item in ItemList){
                dataSource.Objects.Insert(0, item);
            }
       

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

            if (segue.Identifier == "showDetail")
            {
                var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = dataSource.Objects[indexPath.Row];

                controller.SetDetailItem(item);
                controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }

        partial void MasterViewCloseBtn_Activated(UIBarButtonItem sender)
        {
            this.DismissViewController(true, null);
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly List<object> objects = new List<object>();
            readonly MasterViewController controller;

            public DataSource(MasterViewController controller)
            {
                this.controller = controller;
            }

            public IList<object> Objects
            {
                get { return objects; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                if (indexPath.Row == 0)
                {
                    var cell = (InformationCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);
                    var options = objects[indexPath.Row].ToString();
                    cell.UpdateElements(options);
                    return cell;
                }
                else if (indexPath.Row == 1)
                {
                    var cell = (FactoryOptionsCell)tableView.DequeueReusableCell("FactoryOptionCell", indexPath);
                    var options = objects[indexPath.Row].ToString();
                    cell.UpdateElements(options);
                    return cell;
                }
                else if (indexPath.Row == 3)
                {
                    var cell = (HistoryCell)tableView.DequeueReusableCell("HistoryCell", indexPath);
                    var options = objects[indexPath.Row].ToString();
                    cell.UpdateElements(options);
                    return cell;
                }
                else if (indexPath.Row == 4)
                {
                    var cell = (ReconditionOptionCell)tableView.DequeueReusableCell("ReconditionOptionCell", indexPath);
                    var options = objects[indexPath.Row].ToString();
                    cell.UpdateElements(options);
                    return cell;
                }
                else
                {
                    var cell = (AfterMarketCell)tableView.DequeueReusableCell("AfterMarketCell", indexPath);
                    var options = objects[indexPath.Row].ToString();
                    cell.UpdateElements(options);
                    return cell;
                }
            }


            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                //if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    //controller.DetailViewController.SetDetailItem(objects[indexPath.Row]);
            }
        }
    }
}
