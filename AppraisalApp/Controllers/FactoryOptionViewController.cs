using AppraisalApp.Models;
using AppraisalApp.Utilities;
using CoreGraphics;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class FactoryOptionViewController : UIViewController
    {
        partial void BtnSave_Activated(UIBarButtonItem sender)
        {
            SaveFactoryOptions();
        }

        UITableView table;
        IEnumerable<FactoryOptionsSection> fctoption = new List<FactoryOptionsSection>();
        public FactoryOptionViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {


            base.ViewDidLoad();
            var width = View.Bounds.Width;
            var height = View.Bounds.Height;

            table = new UITableView(new CGRect(0, 0, width, height));
            table.AutoresizingMask = UIViewAutoresizing.All;

            AppDelegate.appDelegate.fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, 432110);
            List<string> tableItems = new List<string>();
            foreach(var category in AppDelegate.appDelegate.fctoption){
                string str = category.Caption;
                tableItems.Add(str);
            }
          
            table.Source = new TableSource(tableItems.ToArray(), this);
            Add(table);




        }

        public void SaveFactoryOptions(){
            SIMSResponseData responseStatus;
            VehicleFactoryOptionsKBB vehicleFactoryOptions = new VehicleFactoryOptionsKBB();
            vehicleFactoryOptions.VehicleId = AppDelegate.appDelegate.vehicleID;
            vehicleFactoryOptions.StoreId = AppDelegate.appDelegate.storeId;
            vehicleFactoryOptions.InvtrId = AppDelegate.appDelegate.invtrId;

            vehicleFactoryOptions.data = AppDelegate.appDelegate.factoryOptionsKBB;

            //Logic to add the Selected Factory options

            responseStatus= ServiceFactory.getWebServiceHandle().SaveFactoryOptions(vehicleFactoryOptions);
        }


    }
}