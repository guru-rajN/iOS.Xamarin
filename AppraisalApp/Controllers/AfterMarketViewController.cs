using AppraisalApp.Models;
using AppraisalApp.Utilities;
using CoreGraphics;
using ExtAppraisalApp;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace AppraisalApp
{
    public partial class AfterMarketViewController : UIViewController
    {
        partial void AfterMarketSegmentValue_Changed(UISegmentedControl sender)
        {
            string segmentID = AdditionSegment.SelectedSegment.ToString();
            if (segmentID == "1")
            {
                AdditionAMFO.Hidden = true;
            }
            else
            {
                AdditionAMFO.Hidden = false;
            }

        }

        private MasterViewController masterViewController;

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        async partial void Btn_SaveAfterMarket_Activated(UIBarButtonItem sender)
        {
            var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
            Utility.ShowLoadingIndicator(splitViewController.View, "Saving...", true);

            SIMSResponseData responseData = await CallSaveAfterMarketFactoryOptions();

            Utility.HideLoadingIndicator(splitViewController.View);
            // Navigate to History
            if (null == masterViewController)
            {
                if (!UserInterfaceIdiomIsPhone)
                    masterViewController = (MasterViewController)((UINavigationController)SplitViewController.ViewControllers[0]).TopViewController;
            }

            ViewWorker viewWorker = new ViewWorker();
            viewWorker.WorkerDelegate = (ExtAppraisalApp.Utilities.WorkerDelegateInterface)masterViewController;

            if (!AppDelegate.appDelegate.IsAllDataSaved)
            {
                if (!AppDelegate.appDelegate.IsAftermarketSaved)
                {
                    viewWorker.PerformNavigation(4);
                    if (!AppDelegate.appDelegate.IsHistory)
                        viewWorker.ShowPartialDoneImg(4);

                    viewWorker.ShowDoneImg(3);

                    if (UserInterfaceIdiomIsPhone)
                    {
                        var dictionary = new NSDictionary(new NSString("1"), new NSString("AfterMarket"));

                        NSNotificationCenter.DefaultCenter.PostNotificationName((Foundation.NSString)"MenuSelection", null, dictionary);
                    }
                }
                else
                {
                    viewWorker.PerformNavigation(4);
                }
            }
            else
            {
                var storyboard = UIStoryboard.FromName("Main", null);
                SummaryViewController summaryViewController = (SummaryViewController)storyboard.InstantiateViewController("SummaryViewController");
                UINavigationController uINavigationController = new UINavigationController(summaryViewController);
                uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
                uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
                this.NavigationController.PresentViewController(uINavigationController, true, null);
            }
             
            AppDelegate.appDelegate.IsAftermarketSaved = true;
        }

        UITableView table;
        IEnumerable<AfterMarketSection> fctoption = new List<AfterMarketSection>();



        void Switchele_ValueChanged(object sender, EventArgs e)
        {
            UISwitch switchvalue = (UISwitch)sender;
            int value = Convert.ToInt32(switchvalue.Tag);
            foreach (var aftermarket in AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList)
            {
                if (aftermarket.AfterMarketOptionId == value)
                {
                    if (switchvalue.On)
                    {
                        aftermarket.Is_AfterMarketOption_Select = true;

                    }
                    else
                    {
                        aftermarket.Is_AfterMarketOption_Select = false;
                    }
                }
            }

        }

        public AfterMarketViewController(IntPtr handle) : base(handle)
        {
        }
        public static class globalInde
        {
            public static string selectedSegmentIndex = null;
            public static string oldselectedSegmentIndex = null;
        }
        partial void SegmentValue_Changed(UISegmentedControl sender)
        {
            string segmentID = ReconditionSegment.SelectedSegment.ToString();
            if ((globalInde.selectedSegmentIndex != null))
            {
                globalInde.oldselectedSegmentIndex = globalInde.selectedSegmentIndex.ToString();


            }
            if (segmentID == "1")
            {
                this.masterAMFO.Hidden = true;
                MasterAdditionalAMFO.Hidden = false;
                //base.ViewDidLoad();
                //var width = View.Bounds.Width;
                //var height = View.Bounds.Height;

                //table = new UITableView(new CGRect(0, 0, width, height));
                //table.AutoresizingMask = UIViewAutoresizing.All;

                //AppDelegate.appDelegate.fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, 432110);
                //List<string> tableItems = new List<string>();
                //foreach (var category in AppDelegate.appDelegate.fctoption)
                //{
                //    string str = category.Caption;
                //    tableItems.Add(str);
                //}

                //table.Source = new FactoryOptionSource(tableItems.ToArray(), this);
                //Add(table);
            }
            else
            {

                this.masterAMFO.Hidden = false;
                MasterAdditionalAMFO.Hidden = true;

            }
        }

        Task GetAltenateFactoryOptions(long VehicleId, short Store_Id, short Invtr_Id, string ProsfectID)
        {
            return Task.Factory.StartNew(() => {
                if(AppDelegate.appDelegate.afterMarketOptions ==null || AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions == null){
                    AppDelegate.appDelegate.afterMarketOptions = ServiceFactory.getWebServiceHandle().GetAltenateFactoryOptions(VehicleId, Store_Id, Invtr_Id, ProsfectID);
                }
                InvokeOnMainThread(() =>
                { 
                    int y = 0;
                    if(AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList.Count > 0){
                        
                    
                    foreach (var option in AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList)
                    {
                        UISwitch switchele = new UISwitch();
                        switchele.On = Convert.ToBoolean(option.Is_AfterMarketOption_Select);
                        switchele.Tag = option.AfterMarketOptionId;
                        switchele.ValueChanged += Switchele_ValueChanged;
                        UILabel label = new UILabel();
                        switchele.Frame = new CGRect(20, y + 33, UIScreen.MainScreen.Bounds.Width, 100);
                        label.Frame = new CGRect(80, y, UIScreen.MainScreen.Bounds.Width, 100);
                        y = y + 50;
                        label.UserInteractionEnabled = true;
                        label.Text = option.Description;
                        AMFO.AddSubview(switchele);
                        AMFO.AddSubview(label);

                    }
                    }
                    var width = View.Bounds.Width;
                    var height = View.Bounds.Height;

                    table = new UITableView(new CGRect(0, 0, width, height));
                    table.AutoresizingMask = UIViewAutoresizing.All;

                    List<string> tableItems = new List<string>();

                    foreach (var option in AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions.data)
                    {

                        string str = option.Caption;
                        tableItems.Add(str);

                    }
                    table.Source = new FactoryOptionSource(tableItems.ToArray(), this);
                    table.TableFooterView = new UIView(CoreGraphics.CGRect.Empty);
                    AdditionAMFO.AddSubview(table);

                    AdditionSegment.SelectedSegment = 1;
                    AdditionAMFO.Hidden = true;

                    var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                    Utility.HideLoadingIndicator(splitViewController.View);
                });
               // Utility.ShowLoadingIndicator(this.View, "Fetching AfterMarket Options", false);

            });

        }
        Task<SIMSResponseData> CallSaveAfterMarketFactoryOptions(){
            return Task<SIMSResponseData>.Factory.StartNew(() =>
            {
                SIMSResponseData responseData = SaveAfterMarketFactoryOptions();
                return responseData;
            });
        }

        public SIMSResponseData SaveAfterMarketFactoryOptions()
        {
            SIMSResponseData responseStatus;
            VehicleAfterMarketOptions vehicleFactoryOptions = new VehicleAfterMarketOptions();
            AnswerWrapper answers = new AnswerWrapper();
            answers.Answers = new List<ReconAnsKBB>();

            foreach (var ans in AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions.data)
            {

                foreach (var item in ans.questions)
                {
                    ReconAnsKBB answer = new ReconAnsKBB();

                    answer.label = item.label;
                    answer.questionId = item.questionId;
                    answer.questionType = item.questionType;
                    answer.tags = item.tags;
                    if (item.value == "true")
                    {
                        answer.value = "Yes";
                    }
                    else
                    {
                        answer.value = "No";
                    }
                    answer.value = item.value;
                    answer.vehicleConditionCategory = item.vehicleConditionCategory;
                    answer.vehicleConditionCategoryName = item.vehicleConditionCategoryName;
                    answer.vehicleSectionId = item.vehicleSectionId;
                    answer.vehicleSectionName = item.vehicleSectionName;
                    answer.comment = item.comment;
                    answers.Answers.Add(answer);
                }
            }
            vehicleFactoryOptions.Answer = new AnswerWrapper();
            vehicleFactoryOptions.Answer.Answers = new List<ReconAnsKBB>();
            vehicleFactoryOptions.Answer.VehicleID = AppDelegate.appDelegate.vehicleID;
            vehicleFactoryOptions.Answer.StoreID = AppDelegate.appDelegate.storeId;
            vehicleFactoryOptions.Answer.InvtrID = AppDelegate.appDelegate.invtrId;
            vehicleFactoryOptions.Answer.UserName = "ExtApprasialApp";

            vehicleFactoryOptions.Answer.Answers = answers.Answers;
            vehicleFactoryOptions.vehicleFactoryOptions = new VehicleFactoryOptions();
            vehicleFactoryOptions.vehicleFactoryOptions.AlternateFactoryOptionsLst = new List<AlternateFactoryOptions>();
            if(AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList.Count== 0){
                AlternateFactoryOptions vehicleFactory = new AlternateFactoryOptions();
                vehicleFactory.Description = "None";
                vehicleFactory.Is_AfterMarketOption_Select = true;
                vehicleFactory.AfterMarketOptionId = 1;
                vehicleFactory.OptionKindId = "AMFO";
                AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList.Add(vehicleFactory);
            }
            vehicleFactoryOptions.vehicleFactoryOptions.AlternateFactoryOptionsLst = AppDelegate.appDelegate.afterMarketOptions.sonicAfterMarketList;
            vehicleFactoryOptions.vehicleFactoryOptions.VehicleID = AppDelegate.appDelegate.vehicleID;
            vehicleFactoryOptions.vehicleFactoryOptions.StoreID = AppDelegate.appDelegate.storeId;
            vehicleFactoryOptions.vehicleFactoryOptions.InvtrID = AppDelegate.appDelegate.invtrId;
            vehicleFactoryOptions.vehicleFactoryOptions.UserName = "ExtApprasialApp";
            //Logic to add the Selected Factory options

            responseStatus = ServiceFactory.getWebServiceHandle().SaveAfterMarketFactoryOptions(vehicleFactoryOptions);
            return responseStatus;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (!AppDelegate.appDelegate.IsAllDataSaved)
            {
                if (UserInterfaceIdiomIsPhone)
                {
                    Btn_SaveAfterMarket.Title = "Save";
                }
                else
                {
                    Btn_SaveAfterMarket.Title = "Next";
                }
            }
            else
            {
                Btn_SaveAfterMarket.Title = "Save";
            }

            this.masterAMFO.Hidden = false;
            MasterAdditionalAMFO.Hidden = true;
            try{
                if (null == AppDelegate.appDelegate.prospectId)
                {
                    GenerateProspect();

                    }
                else
                {
                    var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                    Utility.ShowLoadingIndicator(splitViewController.View, "Retrieving...", true);
                    GetAltenateFactoryOptions(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, AppDelegate.appDelegate.prospectId);

                }
    

            }catch(Exception exc){
                Debug.WriteLine("Exception occured :: " + exc.Message);
            }


        }

        Task GenerateProspect()
        {
            return Task.Factory.StartNew(() => {
                AppDelegate.appDelegate.prospectId = ServiceFactory.getWebServiceHandle().GenerateProspect();
                Debug.WriteLine("prospect id :: " + AppDelegate.appDelegate.prospectId);
                InvokeOnMainThread(() =>
                {
                    var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                    Utility.HideLoadingIndicator(splitViewController.View);
                    Utility.ShowLoadingIndicator(splitViewController.View, "Retrieving...", true);
                    GetAltenateFactoryOptions(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, AppDelegate.appDelegate.prospectId);



                    if (null == AppDelegate.appDelegate.prospectId)
                    {
                        Utility.ShowAlert("AppraisalApp", "Vehicle Prospect ID not generated", "OK");
                    }
                });

            });
        }
    }

}