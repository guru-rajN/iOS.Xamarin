
using CoreGraphics;
using ExtAppraisalApp;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using AppraisalApp.Utilities;

namespace AppraisalApp
{
    public partial class OptionPopUp : UIViewController
    {
        UITableView table;
        public OptionPopUp (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {

            UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);
           // UISwitch.TextAttributeCustom.Te = "test";
           // base.ViewDidLoad();
          //  var width = View.Bounds.Width;
           // var height = View.Bounds.Height;

          //  table = new UITableView(new CGRect(0, 0, width, height));
         //   table.AutoresizingMask = UIViewAutoresizing.All;

           // AppDelegate.appDelegate.fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId, 432110);
           // List<string> tableItems = new List<string>();
           // foreach (var category in AppDelegate.appDelegate.fctoption)
           // {
            //    string str = category.Caption;
            //    tableItems.Add(str);
           // }

           // table.Source = new TableSource(tableItems.ToArray(), this);
          //  Add(table);






        }
    }
}