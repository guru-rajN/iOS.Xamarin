using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class FactoryOptionsCell : UITableViewCell
    {
        public FactoryOptionsCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateElements(string options)
        {
            factoryOptionCellLabel.Text = options.ToString();
        }
    }
}