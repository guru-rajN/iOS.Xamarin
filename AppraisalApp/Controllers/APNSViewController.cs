using Foundation;
using System;
using System.Text.RegularExpressions;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class APNSViewController : UIViewController
    {
        partial void Map_TouchUpInside(UIButton sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            MapsViewController summaryViewController = (MapsViewController)storyboard.InstantiateViewController("MapsViewController");
            UINavigationController uINavigationController = new UINavigationController(summaryViewController);
            uINavigationController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            uINavigationController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
            this.NavigationController.PresentViewController(uINavigationController, true, null);
        }



        partial void APNSDone_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var appraisalLogViewController = storyboard.InstantiateViewController("AppraisalLogNavID");
            AppDelegate.appDelegate.Window.RootViewController = appraisalLogViewController;
        }



        public APNSViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (AppDelegate.appDelegate.APNSAlert != null)
            {
                //var a=new UILa
                address.Text = AppDelegate.appDelegate.APNSAlertAddressa + "," + AppDelegate.appDelegate.APNSAlertAddressb + "," + AppDelegate.appDelegate.APNSAlertZip;
                string Message = AppDelegate.appDelegate.APNSAlert;
                string[] tokens = Message.Split(' ');
                VehicleDetails.Text = tokens[2] + " " + tokens[3] + " " + tokens[4];
                string datea = tokens[7].Substring(1);
                int Appvalue = Int32.Parse(datea);
                string Appvaluea = "$" + Appvalue.ToString("#,##0");
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
                    Font = UIFont.BoldSystemFontOfSize(19)
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

    }
}