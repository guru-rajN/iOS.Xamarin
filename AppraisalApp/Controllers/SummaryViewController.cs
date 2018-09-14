using AppraisalApp.Models;
using ExtAppraisalApp.DB;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.IO;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class SummaryViewController : UIViewController
    {
        partial void EditButton_Activated(UIBarButtonItem sender)
        {
            if (EditButton.Title.Equals("Edit"))
            {
                this.DismissViewController(true, null);
                AppDelegate.appDelegate.IsAllDataSaved = true;
            }
            else
            {
                var storyboard = UIStoryboard.FromName("Main", null);
                var loginViewController = storyboard.InstantiateViewController("LoginViewController");
                AppDelegate.appDelegate.Window.RootViewController = loginViewController;
            }
        }

        partial void SubmitBtn_Activated(UIBarButtonItem sender)
        {
            EditButton.Title = "Close";
            SubmitBtn.Enabled = false;
            NSNotificationCenter.DefaultCenter.PostNotificationName("SaveClicked", null);
        }

        public SummaryViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            SummaryContainerView.Hidden = false;
            AppraisedContainerView.Hidden = true;
      
            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"PushNotify", UpdateUI, null);
            base.ViewDidLoad();

        }

        private void UpdateUI(NSNotification obj)
        {
            SummaryContainerView.Hidden = true;
            AppraisedContainerView.Hidden = false;

            var userInfo = obj.UserInfo;
            var NotificationMsg = "";
            if (null != userInfo)
                NotificationMsg = userInfo.Keys[0].ToString();

            var message = userInfo.ValueForKey((Foundation.NSString)"1");

            if (NotificationMsg.Equals("1"))
            {
                Title = message.ToString();
            }
            var dictionary = new NSDictionary(new NSString("1"), new NSString(Title));
            NSNotificationCenter.DefaultCenter.PostNotificationName("AppraisedValue", null, dictionary);
        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"PushNotify");
            base.ViewDidDisappear(animated);
        }

    }
}
