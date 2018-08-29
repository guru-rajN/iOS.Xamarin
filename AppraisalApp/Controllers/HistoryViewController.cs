using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
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
            Segment3.TintColor = UIColor.FromRGB(92, 165, 53);
        }


        partial void Segment1_Change(UISegmentedControl sender)
        {
            Segment1.TintColor = UIColor.FromRGB(92, 165, 53);
        }

        string value1;
        string value2;
        string value3;
        string value2_Answer = null;
        partial void Save_Activated(UIBarButtonItem sender)
        {
            value1 = Segment1.SelectedSegment.ToString();
            value2 = Segment2.SelectedSegment.ToString();
            value3 = Segment3.SelectedSegment.ToString();
            value2_Answer = label2.Text.ToString();
            if ((value1 == "0" || value1 == "1") && (value2 == "0" || value2 == "1") && (value3 == "0" || value3 == "1"))
            {
                if (value2_Answer != "" || value2 == "1")
                {
                    if (value1.ToString() == "0")
                    {
                        value1 = "Yes";

                    }
                    else
                    {
                        value1 = "No";
                    }
                    if (value2.ToString() == "0")
                    {
                        value2 = "Yes";

                    }
                    else
                    {
                        value2 = "No";
                    }
                    if (value3.ToString() == "0")
                    {
                        value3 = "Yes";

                    }
                    else
                    {
                        value3 = "No";
                    }
                    ReconAnsKBB History1 = new ReconAnsKBB()
                    {
                        questionId = "qp/82",
                        questionType = "Boolean",
                        label = "Do you have a free and clear title? Select “No” if your vehicle is leased or financed.",
                        maximumValue = 0,
                        minimumValue = 0,
                        comment = null,
                        tags = null,
                        value = value1,
                        vehicleSectionName = null,
                        vehicleSectionId = 0,
                        vehicleConditionCategoryName = null,
                        vehicleConditionCategory = 0
                    };
                    ReconAnsKBB History2 = new ReconAnsKBB()
                    {
                        questionId = "qp/76",
                        questionType = "Boolean",
                        label = "Has an insurance claim ever been filed on this vehicle?",
                        maximumValue = 0,
                        minimumValue = 0,
                        comment = null,
                        tags = null,
                        value = value2,
                        vehicleSectionName = null,
                        vehicleSectionId = 0,
                        vehicleConditionCategoryName = null,
                        vehicleConditionCategory = 0

                    };
                    ReconAnsKBB History3 = new ReconAnsKBB()
                    {
                        questionId = "qp/76/amount",
                        questionType = "Integer",
                        label = "How much were the total claims?",
                        maximumValue = 0,
                        minimumValue = 0,
                        comment = null,
                        tags = null,
                        value = value2_Answer.ToString(),
                        vehicleSectionName = null,
                        vehicleSectionId = 0,
                        vehicleConditionCategoryName = null,
                        vehicleConditionCategory = 0
                    };
                    ReconAnsKBB History4 = new ReconAnsKBB()
                    {
                        questionId = "qp/79",
                        questionType = "Boolean",
                        label = "Are 2 sets of keys and alarm pad (if applicable) available?",
                        maximumValue = 0,
                        minimumValue = 0,
                        comment = null,
                        tags = null,
                        value = value3,
                        vehicleSectionName = null,
                        vehicleSectionId = 0,
                        vehicleConditionCategoryName = null,
                        vehicleConditionCategory = 0
                    };





                    HistoryRequest data = new HistoryRequest();
                    data.Answers.Add(History1);
                    data.Answers.Add(History2);
                    data.Answers.Add(History3);
                    data.Answers.Add(History4);
                    data.VehicleID = AppDelegate.appDelegate.vehicleID;
                    data.StoreID = AppDelegate.appDelegate.storeId;
                    data.InvtrID = AppDelegate.appDelegate.invtrId;
                    data.UserName = "Extrnal App";
                    Save_History(data);
                }
                else
                {
                    label2.BackgroundColor = UIColor.FromRGB(255, 213, 213);
                    label1.BackgroundColor = UIColor.FromRGB(255, 213, 213);
                    label3.TextColor = UIColor.FromRGB(215, 4, 27);//Label 2 highlight with red color 
                }

            }
            if (!(value1 == "Yes" || value1 == "No"))
            {
                Segment1.TintColor = UIColor.Red;
            }
            if (!(value2 == "Yes" || value2 == "No"))
            {
                Segment2.TintColor = UIColor.Red;
            }
            if (!(value3 == "Yes" || value3 == "No"))
            {
                Segment3.TintColor = UIColor.Red;
            }

        }

        //Save History API
        void Save_History(HistoryRequest data)
        {
            SIMSResponseData responseStatus;
            responseStatus = ServiceFactory.ServiceHistory.getWebServiceHandle().SaveHistory(data);
        }
        partial void Segment2_Change(UISegmentedControl sender)
        {
            var index2 = Segment2.SelectedSegment;
            Segment2.TintColor = UIColor.FromRGB(92, 165, 53);
            if (index2 == 1)
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
            label1.Hidden = true;
            label2.Hidden = true;
            label3.Hidden = true;
            label1.BackgroundColor = UIColor.White;
            label2.BackgroundColor = UIColor.White;
            label3.TextColor = UIColor.Black;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


    }
}