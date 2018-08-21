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

        public int rowSelected = 0;

        private Vehicle vehicleDetails;
        private VinVehicleDetailsKBB decodeVinDetails;

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

            vehicleDetails = GetVehicleData();// get vehicle details service

            if (null != vehicleDetails)
            {
                if (vehicleDetails.InvtrType.Equals("Used"))
                    decodeVinDetails = DecodeVin(vehicleDetails.VIN, (int)vehicleDetails.Mileage, vehicleDetails.StoreID, 10);
                else
                    decodeVinDetails = DecodeVin(vehicleDetails.VIN, (int)vehicleDetails.Mileage, vehicleDetails.StoreID, 20);

                if (null != vehicleDetails)
                {
                    vinNumber.Text = vehicleDetails.VIN;
                    yearValue.Text = vehicleDetails.Year.ToString();
                    makeValue.Text = vehicleDetails.Make;

                    if (string.IsNullOrEmpty(vehicleDetails.Model))
                    {

                        // add value from decode vin
                        // ConfigureItemSelection(modelValue, decodeVinDetails.DecodeVinVehicleDetails.Model);

                    }
                    else
                    {
                        modelValue.Text = vehicleDetails.Model;

                    }

                    if (string.IsNullOrEmpty(vehicleDetails.Trim))
                    {

                        if (decodeVinDetails.KBBVinVehicleDetails.data != null)
                        {
                            decodeVinDetails.DecodeVinVehicleDetails.Series = new List<IDValues>();
                            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
                            {

                                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                                {
                                    var idvalues = new IDValues();
                                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.displayName;
                                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.trimId.ToString();
                                    decodeVinDetails.DecodeVinVehicleDetails.Series.Add(idvalues);

                                }
                            }
                        }


                    }
                    else
                    {
                        trimValue.Text = vehicleDetails.Trim;

                    }


                    if (string.IsNullOrEmpty(trimValue.ToString()))
                    {
                        for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                        {
                            if (trimValue.ToString() == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.displayName)
                            {
                                LoadDropdownData(i);
                            }

                        }
                    }
                }


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
            rowSelected = indexPath.Row;
            this.PerformSegue("popOverSegue", this);

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.Identifier.Equals("popOverSegue"))
            {

                UINavigationController navigationController = (UINavigationController)segue.DestinationViewController;
                PopOverViewController popOverViewController = (PopOverViewController)navigationController.ViewControllers[0];

                if (null != popOverViewController)
                {
                    if (rowSelected == 3)
                    {
                        popOverViewController.title = "Model";
                    }
                    else if (rowSelected == 4)
                    {
                        popOverViewController.title = "Series/Trim";
                    }
                }

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
        private VinVehicleDetailsKBB DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType)
        {
            try
            {
                return ServiceFactory.getWebServiceHandle().DecodeVin(VIN, Mileage, StoreId, InventoryType);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
                return null;
            }
        }

        private KBBColorDetails GetKBBColors(int trimId)
        {
            try
            {
                return ServiceFactory.getWebServiceHandle().GetKBBColors(trimId);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
                return null;
            }

        }


        private void LoadDropdownData(int index)
        {
            if (decodeVinDetails.DecodeVinVehicleDetails.Engine.Count > 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Engine = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.Transmission.Count > 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Transmission = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.DriveTrain.Count > 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.DriveTrain = new List<IDValues>();
            }

            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count > 1)
            {
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[i].engineId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.Engine.Add(idvalues);

                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count == 1)
            {
                engineValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[0].displayName; //assign the engine value
                vehicleDetails.Engine = engineValue.Text;
                vehicleDetails.KBBEngineId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[0].engineId;
            }

            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count > 1)
            {
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[i].drivetrainId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.DriveTrain.Add(idvalues);

                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count == 1)
            {
                drivetrainValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[0].displayName; //assign the drivetrain value
                vehicleDetails.DriveTrain = drivetrainValue.Text;
                vehicleDetails.KBBDrivetrainId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[0].drivetrainId;
            }

            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count > 1)
            {
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[i].transmissionId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.Transmission.Add(idvalues);

                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count == 1)
            {
                transmissionValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].displayName; //assign the transmision
                vehicleDetails.Transmission = transmissionValue.Text;
                vehicleDetails.KBBEngineId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].transmissionId;
            }


        }
    }

}

