using System;
using System.Collections.Generic;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class DetailViewController : UITableViewController
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

            GetVehicleData();
            //Vehicle vehicle = new Vehicle();

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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("indexPath :: " + indexPath.Row);
            if(indexPath.Row == 0){
                
            }else if(indexPath.Row == 1){
                
            }

        }

        private void GetVehicleData()
        {
            try
            {
                ServiceFactory.getWebServiceHandle().GetVehicleDetails(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
            }
        }

        private void DecodeVin(){
            try
            {
               // ServiceFactory.getWebServiceHandle().DecodeVin(vehicle.VIN, Vehicle);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
            }
        }


    }
}

