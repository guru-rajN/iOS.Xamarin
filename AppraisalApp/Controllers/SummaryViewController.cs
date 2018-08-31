using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class SummaryViewController : UIViewController
    {
        partial void EditButton_Activated(UIBarButtonItem sender)
        {
            if(EditButton.Title.Equals("Edit")){
                this.DismissViewController(true, null);
            }
            else{
                var storyboard = UIStoryboard.FromName("Main", null);
                var loginViewController = storyboard.InstantiateViewController("LoginViewController");
                AppDelegate.appDelegate.Window.RootViewController = loginViewController;
            }
        }

        partial void SubmitBtn_Activated(UIBarButtonItem sender)
        {
            // TO-DO : API calls integration
            EditButton.Title = "Close";
            ConfirmationMsg.Text = "We will get back to you.";

            SummaryMsg.Text = "Thank you for your appraisal submission. You have reached our appraisal center after hours however, we have added your appraisal request to the top of our queue and we will return a value to you as soon as we open tomorrow at 9am Eastern. Thank you.";

            SubmitBtn.Enabled = false;
        }

        public SummaryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}