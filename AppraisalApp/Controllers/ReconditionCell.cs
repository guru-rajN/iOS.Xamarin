using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class ReconditionCell : UITableViewCell
    {
        public ReconditionCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(Recondtionm recondition)
        {
            ReconditionHeader.Text = recondition.ReconditionHeader;
            ReconditionDescription.Text = recondition.ReconditionDescription;
        }
    }
}