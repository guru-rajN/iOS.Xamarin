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

                double sacValue = Convert.ToDouble(tokens[1].Trim());
                string SacValueNew = String.Format("{0:C0}",sacValue.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));

                sacComment.Text = Convert.ToString("$" + SacValueNew.Trim());

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
                try{
                    double sacValue = Convert.ToDouble(tokens[1].Trim());
                    string SacValueNew = String.Format("{0:C0}",sacValue.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("en-US")));

                    sacComment.Text = Convert.ToString("$" + SacValueNew.Trim());  
                }catch(Exception exc){
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                }

            }
            else
            {
                sacComment.Text = "";

            }
        }
    }
}