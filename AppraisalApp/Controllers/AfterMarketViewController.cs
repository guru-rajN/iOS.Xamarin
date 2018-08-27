using Foundation;
using System;
using UIKit;

namespace AppraisalApp
{
    public partial class AfterMarketViewController : UIViewController
    {
        public AfterMarketViewController (IntPtr handle) : base (handle)
        {
        }
        public static class globalInde
        {
            public static string selectedSegmentIndex = null;
            public static string oldselectedSegmentIndex = null;
        }
        partial void SegmentValue_Changed(UISegmentedControl sender)
        {
            string segmentID = ReconditionSegment.SelectedSegment.ToString();
            if ((globalInde.selectedSegmentIndex != null))
            {
                globalInde.oldselectedSegmentIndex = globalInde.selectedSegmentIndex.ToString();
            }
            globalInde.selectedSegmentIndex = segmentID.ToString();
           
        }
    }
}