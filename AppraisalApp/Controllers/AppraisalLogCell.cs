using AppraisalApp.Models;
using Foundation;
using System;
using System.Globalization;
using UIKit;

namespace AppraisalApp
{
    public partial class AppraisalLogCell : UITableViewCell
    {
        public AppraisalLogCell (IntPtr handle) : base (handle)
        {
        }

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        internal void UpdateCell(AppraisalLogEntity amfactoryOption)
        {
            Vin.Text = amfactoryOption.VIN;
            YearMakeModel.Text = amfactoryOption.Year + " " + amfactoryOption.Make + " " + amfactoryOption.Model;
            double milleage = Convert.ToDouble(amfactoryOption.Mileage);             string Millieagedec = milleage.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));             Mileage.Text = Millieagedec.Substring(0, Millieagedec.IndexOf('.', 0));            Trim.Text = amfactoryOption.SeriesTrim;
            string[] datetime = Convert.ToString(amfactoryOption.CreatedDate).Split(' '); // sample : 9/24/2018
            DateTime CurreDate=Convert.ToDateTime(datetime[0]);
            appraisalDate.Text = CurreDate.ToString("MM-dd-yyyy");
            string[] tokens = amfactoryOption.SACAppraisalValue.Split(',');
            if(amfactoryOption.SACAppraisalValue!=""){
                //if(UserInterfaceIdiomIsPhone){
                //    SacCommentsWidth.Constant = 100;
                   sacComment.Text = Convert.ToString("$" + tokens[1].Trim());
                //}else{
                //    SacCommentsWidth.Constant = 250;
                //    sacComment.Text = Convert.ToString("$" + tokens[1].Trim());
                //}

            }
            else{
                sacComment.Text = "";

            }
        }

        internal void UpdateCustomerCell(CustomerAppraisalLogEntity amfactoryOption)
        {
            Vin.Text = amfactoryOption.VIN;
            YearMakeModel.Text = amfactoryOption.Year + " " + amfactoryOption.Make + " " + amfactoryOption.Model;
            double milleage = Convert.ToDouble(amfactoryOption.Mileage);             string Millieagedec = milleage.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));             Mileage.Text = Millieagedec.Substring(0, Millieagedec.IndexOf('.', 0));            Trim.Text = amfactoryOption.SeriesTrim;
            string[] datetime = Convert.ToString(amfactoryOption.CreatedDate).Split(' '); 
            DateTime CurreDate = Convert.ToDateTime(datetime[0]);
            appraisalDate.Text = CurreDate.ToString("MM-dd-yyyy");         
            string[] tokens = amfactoryOption.SACAppraisalValue.Split(',');
            if (amfactoryOption.SACAppraisalValue != "")
            {
                sacComment.Text = Convert.ToString("$" + tokens[1].Trim());
            }
            else
            {
                sacComment.Text = "";

            }
        }
    }
}