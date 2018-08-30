using System;
using CoreGraphics;
using GlobalToast;
using UIKit;

namespace ExtAppraisalApp.Utilities
{
    /**
     * Add application common tasks such as alerts, network check, mathematical conversions etc.
     **/
    public class Utility
    {
        public Utility() { }

        public static UIView container;
        public static UIActivityIndicatorView activitySpinner;

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

        public static void ShowToastMessage(string title){
            Toast.ShowToast(title).SetDuration(5000);
        }

        public static void ShowLoadingIndicator(UIView view, string loadingMessage, bool show)
        {

            container = new UIView(new CGRect(0, 0, 120, 120));
            container.BackgroundColor = UIColor.DarkGray;
            container.Layer.CornerRadius = 5;
            container.Center = new CGPoint(view.Bounds.Width / 2, view.Bounds.Height / 2.5);

            activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            activitySpinner.Center = new CGPoint(container.Frame.Width / 2, container.Frame.Height / 2.5);
            container.Add(activitySpinner);

            var label = new UILabel(new CGRect(0, 0, (container.Frame.Width - 20), 20));
            label.TextColor = UIColor.White;
            label.Text = loadingMessage;
            label.TextAlignment = UITextAlignment.Center;
            label.Center = new CGPoint(container.Frame.Width / 2, 4 * container.Frame.Height / 5);
            container.Add(label);

            activitySpinner.StartAnimating();
            view.AddSubview(container);
            //if(show){
            //    activitySpinner.StartAnimating();
            //    view.Add(container);
            //}else{
            //    activitySpinner.StopAnimating();
            //    container.RemoveFromSuperview();
            //}

        }

        public static void HideLoadingIndicator(UIView view)
        {
            activitySpinner.StopAnimating();
            container.RemoveFromSuperview();
        }

    }
}
