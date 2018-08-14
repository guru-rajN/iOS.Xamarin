using AppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class FactoryOptionViewController : UIViewController
    {
        public FactoryOptionViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            List<FactoryOptionsSection> fctoption= new List<FactoryOptionsSection>();
            long VehicleId=85356;
            short StoreId=2001;
            short InvtrId=1;
            int TrimId=430659;

            fctoption = ServiceFactory.getWebServiceHandle().GetFactoryOptionsKBB(VehicleId,StoreId,InvtrId,TrimId);


        }
    }
}