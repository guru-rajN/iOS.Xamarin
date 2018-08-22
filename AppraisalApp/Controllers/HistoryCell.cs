using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class HistoryCell : UITableViewCell
    {
        public HistoryCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateElements(string options)
        {
            HistoryCellLabel.Text = options.ToString();
        }
    }
}