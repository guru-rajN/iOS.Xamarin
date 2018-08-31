using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
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

        private string SelectedModel;
        private string SelectedTrim;

        private string SelectedModelId;
        private string SelectedTrimId;



        bool engineValueMultiple = false;
        bool drivetrainvalueMultiple = false;
        bool modelValueMultiple = false;
        bool exteriorColorValueMultiple = false;
        bool transmissionvalueMultiple = false;
        bool trimValueMultiple = false;

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

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



            if (null == masterViewController)
            {
                if(!UserInterfaceIdiomIsPhone)
                    masterViewController = (MasterViewController)((UINavigationController)SplitViewController.ViewControllers[0]).TopViewController;
            }


            ViewWorker worker = new ViewWorker();

            worker.WorkerDelegate = masterViewController;

            worker.ShowPartialDoneImg( 1);


            if (AppDelegate.appDelegate.cacheVehicleDetails != null)
            {
                vehicleDetails = AppDelegate.appDelegate.cacheVehicleDetails;
            }
            else
            {
                vehicleDetails = GetVehicleData();// get vehicle details service
                AppDelegate.appDelegate.cacheVehicleDetails = vehicleDetails;
            }

            if (null != vehicleDetails)
            {
                if (AppDelegate.appDelegate.cacheDecodeVinDetails != null)
                {
                    decodeVinDetails = AppDelegate.appDelegate.cacheDecodeVinDetails;
                }
                else
                {
                    if (vehicleDetails.InvtrType.Equals("Used"))
                    {
                        decodeVinDetails = DecodeVin(vehicleDetails.VIN, (int)vehicleDetails.Mileage, vehicleDetails.StoreID, 20);
                    }
                    else
                    {
                        decodeVinDetails = DecodeVin(vehicleDetails.VIN, AppDelegate.appDelegate.mileage, vehicleDetails.StoreID, 10);

                    }
                    AppDelegate.appDelegate.cacheDecodeVinDetails = decodeVinDetails;
                }



                if (null != vehicleDetails)
                {
                    vinNumber.Text = vehicleDetails.VIN;
                    yearValue.Text = vehicleDetails.Year.ToString();
                    makeValue.Text = vehicleDetails.Make;

                    // Display Year & Make in MasterView
                    masterViewController.Title = vehicleDetails.Year.ToString() + " " + vehicleDetails.Make;

                    mileageValue.Text = AppDelegate.appDelegate.mileage.ToString();
                    vehicleDetails.Mileage = AppDelegate.appDelegate.mileage;

                    SelectedTrim = vehicleDetails.Trim;
                    SelectedTrimId = vehicleDetails.KBBTrimId.ToString();

                    SelectedModel = vehicleDetails.Model;
                    SelectedModelId = vehicleDetails.KBBModelId.ToString();


                    if (string.IsNullOrEmpty(vehicleDetails.BodyStyle))
                    {
                        bodyStyleValue.Text = REQUIRED;
                    }
                    else
                    {
                        bodyStyleValue.Text = vehicleDetails.BodyStyle;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.Odometer))
                    {
                        odometerValue.Text = REQUIRED;
                    }
                    else
                    {
                        odometerValue.Text = vehicleDetails.Odometer;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.IntColor))
                    {
                        interiorColorValue.Text = REQUIRED;
                    }
                    else
                    {
                        interiorColorValue.Text = vehicleDetails.IntColor;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.Transmission))
                    {
                        transmissionValue.Text = REQUIRED;
                    }
                    else
                    {
                        transmissionValue.Text = vehicleDetails.Transmission;

                    }

                    if (string.IsNullOrEmpty(vehicleDetails.Trim))
                    {
                        trimValue.Text = REQUIRED;
                    }
                    else
                    {
                        trimValue.Text = vehicleDetails.Trim;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.ExtColor))
                    {
                        exteriorColorValue.Text = REQUIRED;
                    }
                    else
                    {
                        exteriorColorValue.Text = vehicleDetails.ExtColor;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.IntrType))
                    {
                        interiorTypeValue.Text = REQUIRED;
                    }
                    else
                    {
                        interiorTypeValue.Text = vehicleDetails.IntrType;
                    }

                    // if both drive train and transmission is null, then engine should always be null , should not show Chrome engine
                    if (string.IsNullOrEmpty(vehicleDetails.DriveTrain) && string.IsNullOrEmpty(vehicleDetails.Transmission))
                    {
                        vehicleDetails.Engine = null;
                    }

                    if (string.IsNullOrEmpty(vehicleDetails.Engine))
                    {
                        engineValue.Text = REQUIRED;
                    }
                    else
                    {
                        engineValue.Text = vehicleDetails.Engine;
                    }
                    if (string.IsNullOrEmpty(vehicleDetails.DriveTrain))
                    {
                        drivetrainValue.Text = REQUIRED;
                    }
                    else
                    {
                        drivetrainValue.Text = vehicleDetails.DriveTrain;
                    }

                    mileageValue.TextColor = UIColor.Black;

                    if (null != decodeVinDetails.KBBVinVehicleDetails.data)
                        vehicleDetails.KBBMakeId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].make.makeId;

                    // First time load check if model is multiple(null) or single
                    if (decodeVinDetails.KBBVinVehicleDetails.data != null)
                    {
                        decodeVinDetails.DecodeVinVehicleDetails.Model = new List<IDValues>();
                        if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
                        {
                            modelValueMultiple = true;
                            if (string.IsNullOrEmpty(vehicleDetails.Model))
                            {
                                modelValue.Text = REQUIRED;
                            }
                            else
                            {
                                modelValue.Text = vehicleDetails.Model;
                            }

                            for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                            {
                                var idvalues = new IDValues();
                                idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.displayName;
                                idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.modelId.ToString();
                                decodeVinDetails.DecodeVinVehicleDetails.Model.Add(idvalues);

                            }

                            removeDuplicateModels(decodeVinDetails.DecodeVinVehicleDetails.Model);

                            if (decodeVinDetails.DecodeVinVehicleDetails.Model.Count == 1)
                            {
                                modelValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].model.displayName;
                                vehicleDetails.Model = modelValue.Text;
                                modelValue.TextColor = UIColor.Black;
                                vehicleDetails.KBBModelId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[0].model.modelId;
                                LoadTrimList();
                            }
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

            if (rowSelected == 3 && modelValueMultiple)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 4 && trimValueMultiple)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 5 && engineValueMultiple)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 6)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 8)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 9 && drivetrainvalueMultiple)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 10 && transmissionvalueMultiple)
            {
                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 11 && exteriorColorValueMultiple)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 12)
            {

                this.PerformSegue("popOverSegue", this);

            }
            else if (rowSelected == 13)
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
                    if (rowSelected == 3 && modelValueMultiple)
                    {
                        popOverViewController.title = "Model";
                        if (modelValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Model;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 4 && trimValueMultiple)
                    {
                        popOverViewController.title = "Series/Trim";
                        if (trimValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Series;
                            popOverViewController.setData(this);
                        }


                    }
                    else if (rowSelected == 5 && engineValueMultiple)
                    {

                        popOverViewController.title = "Engine";

                        if (engineValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Engine;
                            popOverViewController.setData(this);
                        }

                    }
                    else if (rowSelected == 6)
                    {

                        popOverViewController.title = "Odometer";

                        if (decodeVinDetails.DecodeVinVehicleDetails.OdometerOptions != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.OdometerOptions;
                            popOverViewController.setData(this);
                        }


                    }
                    else if (rowSelected == 8)
                    {

                        popOverViewController.title = "Body Style";
                        if (decodeVinDetails.DecodeVinVehicleDetails.BodyStyle != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.BodyStyle;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 9 && drivetrainvalueMultiple)
                    {
                        popOverViewController.title = "Drive train";

                        if (drivetrainvalueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.DriveTrain;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 10 && transmissionvalueMultiple)
                    {
                        popOverViewController.title = "Transmission";

                        if (transmissionvalueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.Transmission;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 11 && exteriorColorValueMultiple)
                    {
                        popOverViewController.title = "Exterior Color";
                        if (exteriorColorValueMultiple)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.ExteriorColor;
                            popOverViewController.setData(this);
                        }

                    }
                    else if (rowSelected == 12)
                    {
                        popOverViewController.title = "Interior Color";
                        if (decodeVinDetails.DecodeVinVehicleDetails.InteriorColor != null)
                        {
                            popOverViewController.listData = decodeVinDetails.DecodeVinVehicleDetails.InteriorColor;
                            popOverViewController.setData(this);
                        }
                    }
                    else if (rowSelected == 13)
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
                        if (string.IsNullOrEmpty(vehicleDetails.ExtColor) ||
                           vehicleDetails.Trim != SelectedTrim && vehicleDetails.KBBTrimId != 0)
                        {
                            exteriorColorValue.Text = REQUIRED;
                        }
                        else
                        {
                            exteriorColorValue.Text = vehicleDetails.ExtColor;
                        }

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
            //var saveData = CheckAllFieldsData();

            //if (saveData)
            //{
            //    DetailViewWorker worker = new DetailViewWorker();

            //    worker.WorkerDelegate = masterViewController;
            //    worker.UpdateUI(false);

            //    AppDelegate.appDelegate.prospectId = GenerateProspect();
            //    SaveVehicleDetails(vehicleDetails);

            //    AppDelegate.appDelegate.cacheVehicleDetails = vehicleDetails;
            //}

            //DetailViewWorker worker = new DetailViewWorker();
            ViewWorker worker = new ViewWorker();
            worker.WorkerDelegate = masterViewController;
            worker.UpdateUI(false);

            AppDelegate.appDelegate.prospectId = GenerateProspect();
            SaveVehicleDetails(vehicleDetails);

            AppDelegate.appDelegate.cacheVehicleDetails = vehicleDetails;
            AppDelegate.appDelegate.IsInfoSaved = true;

            //Utilities.Utility.ShowToastMessage("Vehicle Appraisal Created");
            // Show Factory Options
            //var storyboard = UIStoryboard.FromName("Main", null);
            //var FactoryOptions = storyboard.InstantiateViewController("FactoryOptionViewController");
            //this.
            //this.NavigationController.PushViewController(FactoryOptions, true);
            worker.ShowPartialDoneImg(2);
            worker.ShowDoneImg(1);
            worker.PerformNavigation(2);
        }

        private bool CheckAllFieldsData()
        {
            if (string.IsNullOrEmpty(modelValue.Text) || modelValue.Text.Equals(REQUIRED))
            {
                modelValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(trimValue.Text) || trimValue.Text.Equals(REQUIRED))
            {
                trimValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(engineValue.Text) || engineValue.Text.Equals(REQUIRED))
            {
                engineValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(odometerValue.Text) || odometerValue.Text.Equals(REQUIRED))
            {
                odometerValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(mileageValue.Text) || mileageValue.Text.Equals(REQUIRED))
            {
                mileageValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(bodyStyleValue.Text) || bodyStyleValue.Text.Equals(REQUIRED))
            {
                bodyStyleValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(drivetrainValue.Text) || drivetrainValue.Text.Equals(REQUIRED))
            {
                drivetrainValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(transmissionValue.Text) || transmissionValue.Text.Equals(REQUIRED))
            {
                transmissionValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(exteriorColorValue.Text) || exteriorColorValue.Text.Equals(REQUIRED))
            {
                exteriorColorValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(interiorColorValue.Text) || interiorColorValue.Text.Equals(REQUIRED))
            {
                interiorColorValue.TextColor = UIColor.Red;
                return false;
            }
            else if (string.IsNullOrEmpty(interiorTypeValue.Text) || interiorTypeValue.Text.Equals(REQUIRED))
            {
                interiorTypeValue.TextColor = UIColor.Red;
                return false;
            }
            else
            {
                return true;
            }


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
            if (decodeVinDetails.DecodeVinVehicleDetails.Engine.Count >= 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Engine = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.Transmission.Count >= 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Transmission = new List<IDValues>();
            }
            if (decodeVinDetails.DecodeVinVehicleDetails.DriveTrain.Count >= 0)
            {
                decodeVinDetails.DecodeVinVehicleDetails.DriveTrain = new List<IDValues>();
            }

            Console.WriteLine("transmission count :: " + decodeVinDetails.DecodeVinVehicleDetails.Transmission.Count);

            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count > 1)
            {
                decodeVinDetails.DecodeVinVehicleDetails.Engine = new List<IDValues>();
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].engines[i].engineId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.Engine.Add(idvalues);

                }

                if (null != decodeVinDetails.DecodeVinVehicleDetails.Engine ||
                    vehicleDetails.Trim != SelectedTrim && vehicleDetails.KBBTrimId != 0 && vehicleDetails.KBBTrimId.ToString() != SelectedTrimId && vehicleDetails.Trim != null)
                {
                    if (string.IsNullOrEmpty(vehicleDetails.Engine))
                    {
                        engineValue.Text = REQUIRED;

                    }
                    else
                    {
                        engineValue.Text = vehicleDetails.Engine;
                    }
                    engineValueMultiple = true;
                    drivetrainValue.TextColor = UIColor.FromHSB(100, 59, 51);
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
                decodeVinDetails.DecodeVinVehicleDetails.DriveTrain = new List<IDValues>();
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[i].drivetrainId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.DriveTrain.Add(idvalues);

                }

                if (null != decodeVinDetails.DecodeVinVehicleDetails.DriveTrain ||
                vehicleDetails.Trim != SelectedTrim && vehicleDetails.KBBTrimId != 0 && vehicleDetails.KBBTrimId.ToString() != SelectedTrimId && vehicleDetails.Trim != null)
                {
                    if (string.IsNullOrEmpty(vehicleDetails.DriveTrain))
                    {
                        drivetrainValue.Text = REQUIRED;
                    }
                    else
                    {
                        drivetrainValue.Text = vehicleDetails.DriveTrain;

                    }
                    drivetrainvalueMultiple = true;
                    drivetrainValue.TextColor = UIColor.FromHSB(100, 59, 51);
                }
            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains.Count == 1)
            {
                drivetrainValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[0].displayName; //assign the drivetrain value
                vehicleDetails.DriveTrain = drivetrainValue.Text;
                drivetrainValue.TextColor = UIColor.Black;
                vehicleDetails.KBBDrivetrainId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].drivetrains[0].drivetrainId;
            }

            if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count == 1)
            {
                transmissionValue.Text = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].displayName; //assign the transmision
                vehicleDetails.Transmission = transmissionValue.Text;
                transmissionValue.TextColor = UIColor.Black;
                vehicleDetails.KBBTransmissionId = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[0].transmissionId;

            }
            else if (decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count > 1)
            {

                decodeVinDetails.DecodeVinVehicleDetails.Transmission = new List<IDValues>();
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions.Count; i++)
                {
                    var idvalues = new IDValues();
                    idvalues.Value = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[i].displayName;
                    idvalues.ID = decodeVinDetails.KBBVinVehicleDetails.data.possibilities[index].transmissions[i].transmissionId.ToString();
                    decodeVinDetails.DecodeVinVehicleDetails.Transmission.Add(idvalues);

                }

                if (null != decodeVinDetails.DecodeVinVehicleDetails.Transmission ||
                vehicleDetails.Trim != SelectedTrim && vehicleDetails.KBBTrimId != 0 && vehicleDetails.KBBTrimId.ToString() != SelectedTrimId && vehicleDetails.Trim != null)
                {
                    if (string.IsNullOrEmpty(vehicleDetails.Transmission))
                    {
                        transmissionValue.Text = REQUIRED;

                    }
                    else
                    {
                        transmissionValue.Text = vehicleDetails.Transmission;
                    }
                    transmissionValue.TextColor = UIColor.FromRGB(79, 131, 54);
                    transmissionvalueMultiple = true;

                }
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
                            if (string.IsNullOrEmpty(vehicleDetails.Trim))
                            {
                                trimValue.Text = REQUIRED;
                            }
                            else
                            {
                                trimValue.Text = vehicleDetails.Trim;
                                updateTrimDependentFields(trimValue.Text);
                            }
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

                vehicleDetails.Transmission = null;
                vehicleDetails.ExtColor = null;
                vehicleDetails.DriveTrain = null;
                vehicleDetails.Engine = null;

                updateTrimDependentFields(vehicleDetails.Trim);

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

        public void updateTrimDependentFields(string trim)
        {
            if (decodeVinDetails.KBBVinVehicleDetails.data != null && decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count > 1)
            {
                for (int i = 0; i < decodeVinDetails.KBBVinVehicleDetails.data.possibilities.Count; i++)
                {
                    if (trim == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].trim.displayName &&
                       vehicleDetails.KBBModelId == decodeVinDetails.KBBVinVehicleDetails.data.possibilities[i].model.modelId)
                    {
                        LoadDropdownDataFromTrim(i);

                    }
                }

                LoadExteriorColorsFromTrim();
            }

        }

    }

    // Delegate methods
    //public interface DetailViewWorkerDelegate
    //{
    //    void UpdateDatas(bool show);

    //    void performNavigate(int index);

    //    void ShowDoneIcon();
    //}



    //public class DetailViewWorker
    //{
    //    WeakReference<DetailViewWorkerDelegate> _workerDelegate;

    //    public DetailViewWorkerDelegate WorkerDelegate
    //    {
    //        get
    //        {
    //            DetailViewWorkerDelegate workerDelegate;
    //            return _workerDelegate.TryGetTarget(out workerDelegate) ? workerDelegate : null;
    //        }
    //        set
    //        {
    //            _workerDelegate = new WeakReference<DetailViewWorkerDelegate>(value);
    //        }
    //    }

    //    public void UpdateUI(bool show)
    //    {
    //        Console.WriteLine("Updating UI .. ");

    //        if (_workerDelegate != null)
    //            WorkerDelegate?.UpdateDatas(show);

    //    }

    //    public void PerformNavigation(int indexPath){
    //        if (_workerDelegate != null)
    //            WorkerDelegate?.performNavigate(indexPath);
    //    }

    //    public void ShowDoneImg(){
    //        if (_workerDelegate != null)
    //            WorkerDelegate?.ShowDoneIcon();
    //    }
    //}

}

