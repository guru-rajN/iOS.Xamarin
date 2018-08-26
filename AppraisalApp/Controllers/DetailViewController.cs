using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class DetailViewController : UITableViewController, IWorkerDelegate
    {

        public object DetailItem { get; set; }

        public int rowSelected = 0;

        private Vehicle vehicleDetails;
        private VinVehicleDetailsKBB decodeVinDetails;
        private MasterViewController masterViewController;

        private const string REQUIRED = "Required";

        bool engineValueMultiple = false;
        bool drivetrainvalueMultiple = false;
        bool modelValueMultiple = false;
        bool exteriorColorValueMultiple = false;
        bool transmissionvalueMultiple = false;
        bool trimValueMultiple = false;

        protected DetailViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public DetailViewController()
        {
        }

        public void SetDetailItem(MasterViewController masterViewController)
        {
            this.masterViewController = masterViewController;
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

                    mileageValue.Text = AppDelegate.appDelegate.mileage.ToString();
                    vehicleDetails.Mileage = AppDelegate.appDelegate.mileage;

                    bodyStyleValue.Text = REQUIRED;
                    odometerValue.Text = REQUIRED;
                    interiorColorValue.Text = REQUIRED;
                    interiorTypeValue.Text = REQUIRED;
                    engineValue.Text = REQUIRED;
                    drivetrainValue.Text = REQUIRED;
                    transmissionValue.Text = REQUIRED;
                    trimValue.Text = REQUIRED;
                    exteriorColorValue.Text = REQUIRED;

                    mileageValue.TextColor = UIColor.Black;

                    vehicleDetails.KBBMakeId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].make.makeId;

                    // First time load check if model is multiple(null) or single
                    if (decodeVinDetails.KBBVinVehicleDetails.data != null)
                    {
                        decodeVinDetails.DecodeVinVehicleDetails.Model = new List<IDValues>();
                        if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
                        {
                            modelValueMultiple = true;
                            modelValue.Text = REQUIRED;

                            for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                            {
                                var idvalues = new IDValues();
                                idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.displayName;
                                idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.modelId.ToString();
                                decodeVinDetails.DecodeVinVehicleDetails.Model.Add(idvalues);

                            }

                            removeDuplicateModels(decodeVinDetails.DecodeVinVehicleDetails.Model);
                        }
                        else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count == 1)
                        {
                            modelValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].model.displayName;
                            vehicleDetails.Model = modelValue.Text;
                            modelValue.TextColor = UIColor.Black;
                            vehicleDetails.KBBModelId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].model.modelId;

                            trimValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].trim.displayName;
                            vehicleDetails.Trim = trimValue.Text;
                            trimValue.TextColor = UIColor.Black;
                            vehicleDetails.KBBTrimId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].trim.trimId;
                            LoadDropdownDataFromTrim(0);
                            LoadExteriorColorsFromTrim();
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

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            rowSelected = indexPath.Row;

            if (rowSelected == 3 && modelValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 4 && trimValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 5 && engineValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 6 && odometerValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 8 && bodyStyleValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 9 && drivetrainValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 10 && transmissionValue.Text.Equals(REQUIRED))
            {
                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 11 && exteriorColorValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 12 && interiorColorValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 13 && interiorTypeValue.Text.Equals(REQUIRED))
            {

                this.PerformSegue("popOverSegue", this);
            }

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
                    if (rowSelected == 3 && modelValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Model";
                        if (modelValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Model;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 4 && trimValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Series/Trim";
                        if (trimValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Series;
                            popOverViewController.setData(this);
                        }


                    }
                    else if (rowSelected == 5 && engineValue.Text.Equals(REQUIRED))
                    {

                        popOverViewController.title = "Engine";

                        if (engineValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Engine;
                            popOverViewController.setData(this);
                        }

                    }
                    else if (rowSelected == 6 && odometerValue.Text.Equals(REQUIRED))
                    {

                        popOverViewController.title = "Odometer";

                        if (decodeVinDetails.DecodeVinVehicleDetails.OdometerOptions != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.OdometerOptions;
                            popOverViewController.setData(this);
                        }


                    }
                    else if (rowSelected == 8 && bodyStyleValue.Text.Equals(REQUIRED))
                    {

                        popOverViewController.title = "Body Style";
                        if (decodeVinDetails.DecodeVinVehicleDetails.BodyStyle != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.BodyStyle;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 9 && drivetrainValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Drive train";

                        if (drivetrainvalueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.DriveTrain;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 10 && transmissionValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Transmission";

                        if (transmissionvalueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Transmission;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 11 && exteriorColorValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Exterior Color";
                        if (exteriorColorValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.ExteriorColor;
                            popOverViewController.setData(this);
                        }

                    }
                    else if (rowSelected == 12 && interiorColorValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Interior Color";
                        if (decodeVinDetails.DecodeVinVehicleDetails.InteriorColor != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.InteriorColor;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 13 && interiorTypeValue.Text.Equals(REQUIRED))
                    {
                        popOverViewController.title = "Interior Type";
                        if (decodeVinDetails.DecodeVinVehicleDetails.InteriorType != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.InteriorType;
                            popOverViewController.setData(this);
                        }
                    }
                }

            }
        }

        private void LoadExteriorColorsFromTrim()
        {

            if (trimValue.Text != REQUIRED && vehicleDetails.KBBTrimId != 0)
            {
                KBBColorDetails exteriorColorList = new KBBColorDetails();
                decodeVinDetails.DecodeVinVehicleDetails.ExteriorColor = new List<IDValues>();

                exteriorColorList = GetKBBColors(vehicleDetails.KBBTrimId);

                if (exteriorColorList.data != null)
                {
                    if (exteriorColorList.data.Count > 1)
                    {
                        exteriorColorValueMultiple = true;
                        exteriorColorValue.Text = REQUIRED;

                        for (int i = 0; i < exteriorColorList.data.Count; i++)
                        {
                            IDValues idValues = new IDValues();
                            idValues.ID = exteriorColorList.data[i].colorId.ToString();
                            idValues.Value = exteriorColorList.data[i].displayName;
                            decodeVinDetails.DecodeVinVehicleDetails.ExteriorColor.Add(idValues);
                        }
                    }
                    else if (exteriorColorList.data.Count == 1)
                    {
                        exteriorColorValue.Text = exteriorColorList.data[0].colorId.ToString();
                        vehicleDetails.ExtColor = exteriorColorValue.Text;
                        exteriorColorValue.TextColor = UIColor.Black;
                        vehicleDetails.KBBColorId = exteriorColorList.data[0].displayName;
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

        private string GenerateProspect()
        {
            string prospectId = string.Empty;
            try
            {
                ProspectParams prospectParams = new ProspectParams();
                prospectParams.vin = vehicleDetails.VIN;
                prospectParams.colorId = Int32.Parse(vehicleDetails.KBBColorId);
                prospectParams.trimId = vehicleDetails.KBBTrimId;

                prospectParams.drivetrainId = vehicleDetails.KBBDrivetrainId;
                prospectParams.engineId = vehicleDetails.KBBEngineId;
                prospectParams.currStoreId = AppDelegate.appDelegate.storeId;
                prospectParams.dealerId = 0;
                AppDelegate.appDelegate.trimId = vehicleDetails.KBBTrimId;
                prospectParams.makeId = vehicleDetails.KBBMakeId;
                prospectParams.modelId = vehicleDetails.KBBModelId;
                prospectParams.mileage = Int32.Parse(vehicleDetails.Mileage.ToString());
                prospectParams.YearId = Int32.Parse(vehicleDetails.Year.ToString());
                prospectParams.transmissionId = vehicleDetails.KBBTransmissionId;
                prospectId = ServiceFactory.getWebServiceHandle().GenerateProspectId(prospectParams);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
                return null;

            }
            return prospectId;
        }

        partial void DetailSaveBtn_Activated(UIBarButtonItem sender)
        {
            DetailViewWorker worker = new DetailViewWorker();
            worker.WorkerDelegate = masterViewController;
            worker.UpdateUI(false);

            GenerateProspect();
            SaveVehicleDetails(vehicleDetails);
        }

        private SIMSResponseData SaveVehicleDetails(Vehicle vehicle)
        {

            try
            {
                return ServiceFactory.getWebServiceHandle().SaveVehicleDetails(vehicle);
            }
            catch (Exception exc)
            {
                Console.WriteLine("exception occured :: " + exc.Message);
                return null;
            }
        }

        private void LoadDropdownDataFromTrim(int index)
        {
            if (decodeVinDetails.DecodeVinVehicleDetails.Engine.Count == 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Engine = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.Transmission.Count == 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Transmission = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.DriveTrain.Count == 0)
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

                if (null != decodeVinDetails.DecodeVinVehicleDetails.Engine)
                {
                    engineValue.Text = REQUIRED;
                    engineValueMultiple = true;
                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count == 1)
            {
                engineValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[0].displayName; //assign the engine value
                vehicleDetails.Engine = engineValue.Text;
                engineValue.TextColor = UIColor.Black;
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

                if (null != decodeVinDetails.DecodeVinVehicleDetails.DriveTrain)
                {
                    drivetrainValue.Text = REQUIRED;
                    drivetrainvalueMultiple = true;
                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count == 1)
            {
                drivetrainValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[0].displayName; //assign the drivetrain value
                vehicleDetails.DriveTrain = drivetrainValue.Text;
                drivetrainValue.TextColor = UIColor.Black;
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

                if (null != decodeVinDetails.DecodeVinVehicleDetails.Transmission)
                {
                    transmissionValue.Text = REQUIRED;
                    transmissionvalueMultiple = true;
                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count == 1)
            {
                transmissionValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].displayName; //assign the transmision
                vehicleDetails.Transmission = transmissionValue.Text;
                transmissionValue.TextColor = UIColor.Black;
                vehicleDetails.KBBTransmissionId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].transmissionId;
            }


        }

        private void removeDuplicateModels(List<IDValues> modelList)
        {

            List<IDValues> results = modelList.GroupBy(x => x.ID).Select(g => g.First()).ToList();
            decodeVinDetails.DecodeVinVehicleDetails.Model = new List<IDValues>();
            decodeVinDetails.DecodeVinVehicleDetails.Model = results;

        }

        private void LoadTrimList()
        {
            if (null != vehicleDetails.Model && decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
            {
                if (decodeVinDetails.KBBVinVehicleDetails.data != null)
                {

                    if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
                    {
                        int index = 0;
                        decodeVinDetails.DecodeVinVehicleDetails.Series = new List<IDValues>();
                        for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                        {
                            if (modelValue.Text == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.displayName)
                            {
                                var idvalues = new IDValues();
                                idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.displayName;
                                idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.trimId.ToString();
                                decodeVinDetails.DecodeVinVehicleDetails.Series.Add(idvalues);
                                index = i;
                            }
                        }

                        if (decodeVinDetails.DecodeVinVehicleDetails.Series.Count > 1)
                        {
                            trimValue.Text = REQUIRED;
                            trimValueMultiple = true;
                        }
                        else if (decodeVinDetails.DecodeVinVehicleDetails.Series.Count == 1)
                        {
                            trimValue.Text = decodeVinDetails.DecodeVinVehicleDetails.Series[0].Value;
                            vehicleDetails.Trim = trimValue.Text;
                            trimValue.TextColor = UIColor.Black;
                            vehicleDetails.KBBTrimId = Int32.Parse(decodeVinDetails.DecodeVinVehicleDetails.Series[0].ID);
                            LoadDropdownDataFromTrim(index);
                            LoadExteriorColorsFromTrim();
                        }
                    }
                }
            }
        }

        // updating data after selection of vehicle information
        public void UpdateDatas(string data, int id)
        {
            Console.WriteLine("updated ..");
            if (rowSelected == 3)
            {
                modelValue.Text = data;
                vehicleDetails.Model = modelValue.Text;
                vehicleDetails.KBBModelId = id;
                LoadTrimList();
            }
            else if (rowSelected == 4)
            {
                trimValue.Text = data;
                vehicleDetails.Trim = trimValue.Text;
                vehicleDetails.KBBTrimId = id;

                if (decodeVinDetails.KBBVinVehicleDetails.data != null && decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
                {
                    for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                    {
                        if (vehicleDetails.Trim == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.displayName &&
                           vehicleDetails.KBBModelId == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.modelId)
                        {
                            LoadDropdownDataFromTrim(i);

                        }
                    }
                }
                LoadExteriorColorsFromTrim();

            }
            else if (rowSelected == 5)
            {
                engineValue.Text = data;
                vehicleDetails.Engine = data;
                vehicleDetails.KBBEngineId = id;
            }
            else if (rowSelected == 6)
            {
                odometerValue.Text = data;
                vehicleDetails.Odometer = odometerValue.Text;
            }
            else if (rowSelected == 8)
            {
                bodyStyleValue.Text = data;
                vehicleDetails.BodyStyle = bodyStyleValue.Text;
            }
            else if (rowSelected == 9)
            {
                drivetrainValue.Text = data;
                vehicleDetails.DriveTrain = drivetrainValue.Text;
                vehicleDetails.KBBDrivetrainId = id;
            }
            else if (rowSelected == 10)
            {
                transmissionValue.Text = data;
                vehicleDetails.Transmission = transmissionValue.Text;
                vehicleDetails.KBBTransmissionId = id;
            }
            else if (rowSelected == 11)
            {
                exteriorColorValue.Text = data;
                vehicleDetails.ExtColor = exteriorColorValue.Text;
                vehicleDetails.KBBColorId = id.ToString();
            }
            else if (rowSelected == 12)
            {
                interiorColorValue.Text = data;
                vehicleDetails.IntColor = interiorColorValue.Text;
            }
            else if (rowSelected == 13)
            {
                interiorTypeValue.Text = data;
                vehicleDetails.IntrType = interiorTypeValue.Text;
            }

        }

    }

    // Delegate methods
    public interface DetailViewWorkerDelegate
    {
        void UpdateDatas(bool show);
    }

    public class DetailViewWorker
    {
        WeakReference<DetailViewWorkerDelegate> _workerDelegate;

        public DetailViewWorkerDelegate WorkerDelegate
        {
            get
            {
                DetailViewWorkerDelegate workerDelegate;
                return _workerDelegate.TryGetTarget(out workerDelegate) ? workerDelegate : null;
            }
            set
            {
                _workerDelegate = new WeakReference<DetailViewWorkerDelegate>(value);
            }
        }

        public void UpdateUI(bool show)
        {
            Console.WriteLine("Updating UI .. ");

            if (_workerDelegate != null)
                WorkerDelegate?.UpdateDatas(show);

        }
    }

}

