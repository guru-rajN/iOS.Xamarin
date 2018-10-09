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

        internal void UpdateCell(AppraisalLogEntity amfactoryOption)
        {
            Vin.Text = amfactoryOption.VIN;
            YearMakeModel.Text = amfactoryOption.Year + " " + amfactoryOption.Make + " " + amfactoryOption.Model;
            string milleage = Convert.ToString(amfactoryOption.Mileage);
            Mileage.Text = String.Format("{0:C0}", amfactoryOption.Mileage).Replace(@"$", string.Empty);
            Trim.Text = amfactoryOption.SeriesTrim;
            string[] datetime = Convert.ToString(amfactoryOption.CreatedDate).Split(' '); // sample : 9/24/2018
            DateTime CurreDate=Convert.ToDateTime(datetime[0]);
            appraisalDate.Text = CurreDate.ToString("MM-dd-yyyy");
            string[] tokens = amfactoryOption.SACAppraisalValue.Split(',');
            if(amfactoryOption.SACAppraisalValue!=""){
                sacComment.Text = Convert.ToString(tokens[0]) + " " + "$" + " " + tokens[1];
            }
            else{
                sacComment.Text = "";

            }
        }

        internal void UpdateCustomerCell(CustomerAppraisalLogEntity amfactoryOption)
        {
            Vin.Text = amfactoryOption.VIN;
            YearMakeModel.Text = amfactoryOption.Year + " " + amfactoryOption.Make + " " + amfactoryOption.Model;
            string milleage = Convert.ToString(amfactoryOption.Mileage);
            Mileage.Text= String.Format("{0:C0}", amfactoryOption.Mileage).Replace(@"$", string.Empty);
            Trim.Text = amfactoryOption.SeriesTrim;
            string[] datetime = Convert.ToString(amfactoryOption.CreatedDate).Split(' '); 
            DateTime CurreDate = Convert.ToDateTime(datetime[0]);
            appraisalDate.Text = CurreDate.ToString("MM-dd-yyyy");         
            string[] tokens = amfactoryOption.SACAppraisalValue.Split(',');
            if (amfactoryOption.SACAppraisalValue != "")
            {
                sacComment.Text = Convert.ToString("$" + " " + tokens[1]);
            }
            else
            {
                sacComment.Text = "";

            }
        }
    }
}