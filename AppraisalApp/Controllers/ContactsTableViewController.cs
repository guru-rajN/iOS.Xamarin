using CoreGraphics;
using Foundation;
using System;
using UIKit;
using Xamarin.Forms;

namespace ExtAppraisalApp
{
    public partial class ContactsTableViewController : UITableViewController
    {
        public ContactsTableViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ContactsTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            System.Diagnostics.Debug.WriteLine("Row Selected :: " + indexPath.Row);

            if (indexPath.Row == 0)
            {

                global::Xamarin.Forms.Forms.Init();

                var address = "chidu.soraba@gmail.com";
                Device.OpenUri(new Uri($"mailto:{ address}?subject=Feedback&body=A message for you consideration." + "%0D%0A" +  //line break 
                                           ""));
            }
            else if (indexPath.Row == 1)
            {
                try
                {
                    global::Xamarin.Forms.Forms.Init();
                    Device.OpenUri(new Uri(String.Format("tel:{0}", "+18666576642")));
                }
                catch (ArgumentNullException exc)
                {
                    System.Diagnostics.Debug.WriteLine("Exception :: " + exc.Message);
                    // Number was null or white space
                }
            }
        }
    }
}