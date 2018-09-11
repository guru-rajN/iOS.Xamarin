using AppraisalApp.Models;
using Foundation;
using System;
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
            CreatedBy.Text = amfactoryOption.Appraisedby;
            Trim.Text = amfactoryOption.SeriesTrim;
            appraisalDate.Text = Convert.ToString(amfactoryOption.CreatedDate);
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