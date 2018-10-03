using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class AppraisedViewController : UIViewController
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

       

        public AppraisedViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"AppraisedValue", ShowAppraisedValue, null);

            if (AppDelegate.appDelegate.APNSAlert != null)
            {
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
                APNSSummary.AttributedText = prettyString;

            }

            base.ViewDidLoad();
        }

        private void ShowAppraisedValue(NSNotification obj)
        {
            var userInfo = obj.UserInfo;
            var NotificationMsg = "";
            if (null != userInfo)
                NotificationMsg = userInfo.Keys[0].ToString();

            var message = userInfo.ValueForKey((Foundation.NSString)"1");

            if (NotificationMsg.Equals("1"))
            {
                Title = message.ToString();
            }

            if (!string.IsNullOrEmpty(Title))
            {
                //var a=new UILa
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

            }

        }
        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"AppraisedValue");
            base.ViewDidDisappear(animated);
        }
    }
}