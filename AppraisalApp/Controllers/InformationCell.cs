using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class InformationCell : UITableViewCell
    {
        public InformationCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateElements(string options)
        {
            infoCellLabel.Text = options.ToString();
        }
    }
}