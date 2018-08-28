using AppraisalApp.Models;
using ExtAppraisalApp;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using UIKit;
using Xamarin.Forms;

namespace AppraisalApp
{
    public partial class AfterMarketViewController : UITableView
    {
        public AfterMarketViewController (IntPtr handle) : base (handle)
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
            AfterMarketOptions afterMarketOptions = new AfterMarketOptions();
            afterMarketOptions =ServiceFactory.getWebServiceHandle().GetAltenateFactoryOptions(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId,AppDelegate.appDelegate.prospectId);
            if ((globalInde.selectedSegmentIndex != null))
            {
                globalInde.oldselectedSegmentIndex = globalInde.selectedSegmentIndex.ToString();
            }
            if(segmentID=="1"){
                
            }
            else{
                
            }
            //globalInde.selectedSegmentIndex = segmentID.ToString();
            //TableView list = new TableView();
            //list.RowHeight = 80;
            //TableRoot troot = new TableRoot();
            //list.Root = troot;
            //UITableSection section = new TableSection();
            //troot.Add(section);
            //for (int i = 0; i < itemsList.Count; i++)
            //{
            //    section.Add(new UI.Custom.SickCell());
            //}

        }
    }
}