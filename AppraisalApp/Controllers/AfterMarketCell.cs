using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class AfterMarketCell : UITableViewCell
    {
        public AfterMarketCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateElements(string options)
        {
            afterMarketCellLabel.Text = options.ToString();
        }
    }
}