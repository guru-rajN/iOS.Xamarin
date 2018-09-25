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
            Mileage.Text = Convert.ToString(amfactoryOption.Mileage);
            Trim.Text = amfactoryOption.SeriesTrim;
            string[] datetime = Convert.ToString(amfactoryOption.CreatedDate).Split(' ');
            appraisalDate.Text = datetime[0]; 
            string[] tokens = amfactoryOption.SACAppraisalValue.Split(',');
            if(amfactoryOption.SACAppraisalValue!=""){
                sacComment.Text = Convert.ToString(tokens[0]) + " " + "$" + " " + tokens[1];
            }
            else{
                sacComment.Text = "";

            }
        }
    }
}