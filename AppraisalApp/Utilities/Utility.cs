using System;
using UIKit;

namespace ExtAppraisalApp.Utilities
{
    /**
     * Add application common tasks such as alerts, network check, mathematical conversions etc.
     **/
    public class Utility
    {
        public Utility() { }

        // show alert dialog
        public static void ShowAlert(string title, string message, string buttonText)
        {
            UIAlertView alert = new UIAlertView();
            alert.Title = title;
            alert.Message = message;
            alert.AddButton(buttonText);
            alert.Show();
        }

        // alert dialog with multiple action buttons
        public static void ShowAlert(string title, string message, string buttonText1, string buttonText2)
        {
            UIAlertView alert = new UIAlertView();
            alert.Title = title;
            alert.Message = message;
            alert.AddButton(buttonText1);
            alert.AddButton(buttonText2);
            alert.Show();
        }

        internal static void ShowAlert(string v)
        {
            throw new NotImplementedException();
        }
    }
}
