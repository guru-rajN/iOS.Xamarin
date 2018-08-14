using System;
using System.Collections.Generic;
using CoreGraphics;
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
            DetailTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            Vehicle vehicle = GetVehicleData();

            if(null != vehicle){
                if (vehicle.InvtrType.Equals("Used"))
                    DecodeVin(vehicle.VIN, (int)vehicle.Mileage, vehicle.StoreID, 10);
                else
                    DecodeVin(vehicle.VIN, (int)vehicle.Mileage, vehicle.StoreID, 20);


                vinNumber.Text = vehicle.VIN;
                yearValue.Text = vehicle.Year.ToString();
                makeValue.Text = vehicle.Make;

            }

           
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

        // Get all the vehicle details : the item which will have null value, it means it will have multiple values
        // that we need to fetch from decode vin service
        private Vehicle GetVehicleData()
        {
            try
            {
                Vehicle vehicle = ServiceFactory.getWebServiceHandle().GetVehicleDetails(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId);
                return vehicle;
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
                return null;
            }
        }

        // Decode VIN detials
        private void DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType){
            try
            {
                ServiceFactory.getWebServiceHandle().DecodeVin(VIN, Mileage, StoreId,InventoryType);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
            }
        }


    }
}

