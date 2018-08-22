using Foundation;
using System;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class HistoryViewController : UIViewController
    {


        partial void Label2_Change(UITextField sender)
        {
            const int maxCharacters = 7;

            label2.ShouldChangeCharacters = (textField, range, replacement) =>
            {
                var newContent = new NSString(textField.Text).Replace(range, new NSString(replacement)).ToString();
                int number;
                return newContent.Length <= maxCharacters && (replacement.Length == 0 || int.TryParse(replacement, out number));
            };

            label1.BackgroundColor = UIColor.White;
            label2.BackgroundColor = UIColor.White;
            label3.TextColor = UIColor.Black;//Label 2 highlight with red color
        }
        //partial void Label2_Change(UITextField sender)
        //{

        //    label1.BackgroundColor = UIColor.White;
        //    label2.BackgroundColor = UIColor.White;
        //    label3.TextColor = UIColor.Black;//Label 2 highlight with red color
        //}

        partial void label2_Change(UITextField sender)
        {
            label1.BackgroundColor = UIColor.White;
            label2.BackgroundColor = UIColor.White;
            label3.TextColor = UIColor.Black;//Label 2 highlight with red color 
        }

        partial void Segment3_Change(UISegmentedControl sender)
        {
            Segment3.TintColor =UIColor.FromRGB(92, 165, 53);
        }

      
        partial void Segment1_Change(UISegmentedControl sender)
        {
            Segment1.TintColor = UIColor.FromRGB(92, 165, 53);
        }

        string value1;
        string value2;
        string value3;
        string value2_Answer=null;
        partial void Save_Activated(UIBarButtonItem sender)
        {
                value1 = Segment1.SelectedSegment.ToString();
            value2 = Segment2.SelectedSegment.ToString();
            value3 = Segment3.SelectedSegment.ToString();
            value2_Answer = label2.Text.ToString();
            if ((value1 == "0" || value1 == "1") && (value2 == "0" || value2 == "1") && (value3 == "0" || value3 == "1"))
            {
                if (value2_Answer!="" || value2 == "1")
                {
                    Save_History();
    
                }
                else
                {
                    label2.BackgroundColor= UIColor.FromRGB(255,213,213);
                    label1.BackgroundColor = UIColor.FromRGB(255, 213, 213);
                    label3.TextColor = UIColor.FromRGB(215, 4, 27);//Label 2 highlight with red color 
                }

            }
               if(!(value1 == "0" || value1 == "1")) 
                {
                    Segment1.TintColor = UIColor.Red;
                }
                if (!(value2 == "0" || value2 == "1"))
                {
                    Segment2.TintColor = UIColor.Red;
                }
                if (!(value3 == "0" || value3 == "1"))
                {
                    Segment3.TintColor = UIColor.Red; 
                }

        }

        //Save History API
        void Save_History()
        {
            
        }
        partial void Segment2_Change(UISegmentedControl sender)
        {
            var index2 = Segment2.SelectedSegment;
            Segment2.TintColor = UIColor.FromRGB(92, 165, 53);
            if(index2==1)
            {
                label1.Hidden = true;
                label2.Hidden = true;
                label3.Hidden = true;
                label1.BackgroundColor = UIColor.White;
                label2.BackgroundColor = UIColor.White;
                label3.TextColor = UIColor.Black;
            }
            if (index2 == 0)
            {
                label1.Hidden = false;
                label2.Hidden = false;
                label3.Hidden = false;
                label2.Text = "";
            }
        }

        protected HistoryViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            label1.UserInteractionEnabled = false;
            Segment1.SelectedSegment = -1;
            Segment2.SelectedSegment = -1;
            Segment3.SelectedSegment = -1;
            label2.KeyboardType = UIKeyboardType.NumberPad;
            label2.BorderStyle = UITextBorderStyle.Bezel;
            label1.BorderStyle = UITextBorderStyle.Bezel;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
       

    }
}