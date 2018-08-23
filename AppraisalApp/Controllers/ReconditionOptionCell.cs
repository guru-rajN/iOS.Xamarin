using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class ReconditionOptionCell : UITableViewCell
    {
        public ReconditionOptionCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateElements(string options)
        {
            ReconditionCellLabel.Text = options.ToString();
        }
    }
}