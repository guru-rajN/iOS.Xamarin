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
            vin.Text = amfactoryOption.VIN;
            YearMakeModel.Text = amfactoryOption.Year + " " + amfactoryOption.Make + " " + amfactoryOption.Model;
            Mileage.Text = Convert.ToString(amfactoryOption.Mileage);
            CreatedBy.Text = amfactoryOption.Appraisedby;
            appraisalDate.Text = Convert.ToString(amfactoryOption.CreatedDate);
            sacComment.Text = Convert.ToString(amfactoryOption.SACStatus);
        }
    }
}