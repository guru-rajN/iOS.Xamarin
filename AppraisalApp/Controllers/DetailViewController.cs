using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class DetailViewController : UIViewController
    {
        public object DetailItem { get; set; }

    
            

        protected DetailViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void SetDetailItem(object newDetailItem)
        {
            if (DetailItem != newDetailItem)
            {
                DetailItem = newDetailItem;

                // Update the view
                ConfigureView();
            }
        }

        void ConfigureView()
        {
            // Update the user interface for the detail item
            //if (IsViewLoaded && DetailItem != null)
            //detailDescriptionLabel.Text = DetailItem.ToString();
            //VehicleInfoTableView.Source = new DetailSource(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            ConfigureView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public class DetailSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly Dictionary<string,string> objects = new Dictionary<string,string>();
            readonly DetailViewController controller;

            public DetailSource(DetailViewController controller)
            {
                this.controller = controller;
            }

            public Dictionary<string,string> Objects
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
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);
                var infos = objects[indexPath.Row.ToString()];
                cell.TextLabel.Text = "VIN";
                cell.DetailTextLabel.Text = "123456789";
                return cell;
            }


            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                //if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                //controller.DetailViewController.SetDetailItem(objects[indexPath.Row]);
            }

           
        }


    }
}

