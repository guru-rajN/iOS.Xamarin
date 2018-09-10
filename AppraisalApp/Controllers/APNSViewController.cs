using Foundation;
using System;
using System.Text.RegularExpressions;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class APNSViewController : UIViewController
    {
        partial void APNSDone_Activated(UIBarButtonItem sender)
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var loginViewController = storyboard.InstantiateViewController("LoginViewController");
            AppDelegate.appDelegate.Window.RootViewController = loginViewController;
        }

       

        public APNSViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (AppDelegate.appDelegate.APNSAlert != null)
            {
                //var a=new UILa
                string Message = AppDelegate.appDelegate.APNSAlert;
                string[] tokens = Message.Split(' ');
                VehicleDetails.Text = tokens[2] + " " + tokens[3] + " " + tokens[4];
                string datea = tokens[7].Substring(1);
                int Appvalue = Int32.Parse(datea);
                string Appvaluea = "$"+ Appvalue.ToString("#,##0");
                AppValue.Text = Appvaluea;
                DateTime date = DateTime.Now.AddDays(14);
                string summarytext = "14 days or 500 miles";
                string formatteddate = date.ToString("MMM dd, yyyy");
                ExpDate.Text = formatteddate;

                var firstAttributes = new UIStringAttributes
                {
                    ForegroundColor = UIColor.Blue,
                    BackgroundColor = UIColor.Yellow,
                    Font = UIFont.BoldSystemFontOfSize(16)
                };

                var secondAttributes = new UIStringAttributes
                {
                    ForegroundColor = UIColor.Red,
                    BackgroundColor = UIColor.Gray,
                    StrikethroughStyle = NSUnderlineStyle.Single
                };
                var prettyString = new NSMutableAttributedString("UITextField is not pretty!");
                prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, 11));
                prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(15, 3));
                APNSSummary.AttributedText = prettyString;

                //APNSSummary.Text = "Thank you for submitting your appraisal information. We are happy to provide a value based on the information you have provided" +
                    //" us. Your vehicle is valued at" + Appvaluea + ". This amount is good for "+" "+summarytext+ " " +"from the date of submission. At the time of delivery or transfer of ownership, CarCash reserves the right to verify " +
                    //"that the information you have submitted is accurate and to adjust the value offered if we feel that your vehicle does not match the description you have provided.";
            }
        } 
    }
}