using AppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class APNSViewController : UIViewController
    {
        //partial void Map_TouchUpInside(UIButton sender)
        //{
        //    var storyboard = UIStoryboard.FromName("Main", null);
        //    MapsViewController summaryViewController = (MapsViewController)storyboard.InstantiateViewController("MapsViewController");
        //    UINavigationController uINavigationController = new UINavigationController(summaryViewController);
        //    uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
        //    uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
        //    this.NavigationController.PresentViewController(uINavigationController, true, null);
        //}



        partial void APNSDone_Activated(UIBarButtonItem sender)
        {
            //var storyboard = UIStoryboard.FromName("Main", null);
            //var appraisalLogViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
            //AppDelegate.appDelegate.Window.RootViewController = appraisalLogViewController;
        }



        public APNSViewController(IntPtr handle) : base(handle)
        {

        }



        async public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            APNSDone.Enabled = false;

            if (AppDelegate.appDelegate.APNSSACDB)
            {
                //Get SAC and other value from DB 
                //var storyboard = UIStoryboard.FromName("Main", null);
                //APNSViewController summaryViewController = (APNSViewController)storyboard.InstantiateViewController("APNSViewController");
                //var splitViewController = (APNSViewController)AppDelegate.appDelegate.Window.RootViewController;
                Utility.ShowLoadingIndicator(this.View, "", true);
                await GetAPNSSummary();
                AppDelegate.appDelegate.APNSSACDB = false;
                Utility.HideLoadingIndicator(this.View);

            }
            UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() => {
                var storyboard = UIStoryboard.FromName("Main", null);
                MapsViewController summaryViewController = (MapsViewController)storyboard.InstantiateViewController("MapsViewController");
                UINavigationController uINavigationController = new UINavigationController(summaryViewController);
                uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
                uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
                this.NavigationController.PresentViewController(uINavigationController, true, null);
            });
            address.UserInteractionEnabled = true;
            address.AddGestureRecognizer(labelTap);
            if (AppDelegate.appDelegate.APNSAlert != null)
            {
                //var a=new 

                string addressText = AppDelegate.appDelegate.APNSAlertAddressa + "," + AppDelegate.appDelegate.APNSAlertAddressb + "," + AppDelegate.appDelegate.APNSAlertZip;
                //address.Text = AppDelegate.appDelegate.APNSAlertAddressa + "," + AppDelegate.appDelegate.APNSAlertAddressb + "," + AppDelegate.appDelegate.APNSAlertZip;
                var underlineAttriString = new NSMutableAttributedString(addressText);
                underlineAttriString.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                                                  NSNumber.FromInt32((int)NSUnderlineStyle.Single), new NSRange(0, underlineAttriString.Length));
                address.AttributedText = underlineAttriString;
                string Message = AppDelegate.appDelegate.APNSAlert;
                string[] tokens = Message.Split(' ');
                VehicleDetails.Text = tokens[2] + " " + tokens[3] + " " + tokens[4];
                string datea = tokens[7].Substring(1);
                int Appvalue = Int32.Parse(datea);
                //String.Format("{0:C0}", sacValue.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));
                // string Appvaluea = "$" + Appvalue.ToString("#,##0");
                string Appvaluea = "$" + Appvalue.ToString("#,##0");
                //Globalization.CultureInfo.GetCultureInfo("en-US")));
                // Appvaluea = Appvaluea.Substring(0, Appvaluea.IndexOf('.', 0));
                AppValue.Text = Appvaluea;
                DateTime date = DateTime.Now.AddDays(14);
                //string summarytext = "14 days or 500 miles";
                string formatteddate = date.ToString("MMM dd, yyyy");
                ExpDate.Text = formatteddate;
                int SummaryAppvalueStartIndex = 158;
                int SummaryAppvalueEndIndex = Appvaluea.Length;
                int SummaryExStartIndex = 184 + (Appvaluea.Length);
                int SummaryExEndIndex = 20;
                var firstAttributes = new UIStringAttributes
                {
                    Font = UIFont.BoldSystemFontOfSize(14)
                };

                var secondAttributes = new UIStringAttributes
                {
                    ForegroundColor = UIColor.Red,
                    BackgroundColor = UIColor.Gray,
                    StrikethroughStyle = NSUnderlineStyle.Single
                };
                var prettyString = new NSMutableAttributedString("Thank you for submitting your appraisal information. We are happy to provide a value based on the information you have provided us. Your vehicle is valued at " + Appvaluea + ". This amount is good for 14 days or 500 miles from the date of submission. At the time of delivery or transfer of ownership, CarCash reserves the right to verify that the information you have submitted is accurate and to adjust the value offered if we feel that your vehicle does not match the description you have provided.!");
                prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(SummaryAppvalueStartIndex, SummaryAppvalueEndIndex));
                prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(SummaryExStartIndex, SummaryExEndIndex));
                //prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, 11));
                APNSSummary.AttributedText = prettyString;

                //APNSSummary.Text = "Thank you for submitting your appraisal information. We are happy to provide a value based on the information you have provided" +
                //" us. Your vehicle is valued at" + Appvaluea + ". This amount is good for "+" "+summarytext+ " " +"from the date of submission. At the time of delivery or transfer of ownership, CarCash reserves the right to verify " +
                //"that the information you have submitted is accurate and to adjust the value offered if we feel that your vehicle does not match the description you have provided.";
            }
        }

        partial void CloseBtn_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var appraisalLogViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
            AppDelegate.appDelegate.Window.RootViewController = appraisalLogViewController;
        }

        partial void Cashout_TouchUpInside(UIButton sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            MapsViewController summaryViewController = (MapsViewController)storyboard.InstantiateViewController("MapsViewController");
            UINavigationController uINavigationController = new UINavigationController(summaryViewController);
            uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
            this.NavigationController.PresentViewController(uINavigationController, true, null);
        }


        Task GetAPNSSummary()
        {
            return Task.Factory.StartNew(() =>
            {
                AppDelegate.appDelegate.SACvalue = AppDelegate.appDelegate.SACvalue.Substring(0, AppDelegate.appDelegate.SACvalue.IndexOf('.', 0));
                AppDelegate.appDelegate.SACvalue = AppDelegate.appDelegate.SACvalue.Split(',')[0];
                ApnsSummaryview APNSvalue = new ApnsSummaryview();
                APNSvalue = ServiceFactory.getWebServiceHandle().GetAPNSSummaryView(AppDelegate.appDelegate.vehicleID,
                                                                                    AppDelegate.appDelegate.storeId,
                                                                                    AppDelegate.appDelegate.invtrId);
                AppDelegate.appDelegate.APNSAlert = APNSvalue.Message + AppDelegate.appDelegate.SACvalue;
                AppDelegate.appDelegate.APNSAlertStore = APNSvalue.StoreName;
                AppDelegate.appDelegate.APNSAlertLat = APNSvalue.Langitude;
                AppDelegate.appDelegate.APNSAlertLon = APNSvalue.Lattitude;
                AppDelegate.appDelegate.APNSAlertAddressa = APNSvalue.Addressa;
                AppDelegate.appDelegate.APNSAlertAddressb = APNSvalue.Addressb;
                AppDelegate.appDelegate.APNSAlertZip = APNSvalue.Zipcode;

            });

        }


        partial void Comparebook_TouchUpInside(UIButton sender)
        {
            Utility.ShowAlert("CarCash", "functionality coming soon", "OK");
        }
    }
}