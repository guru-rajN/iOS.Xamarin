using AppraisalApp.Models;
using CoreGraphics;
using ExtAppraisalApp;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;

namespace AppraisalApp
{
    public partial class AMOptionPopUp : UIViewController
    {
       
        partial void BtnSave_Activated(UIBarButtonItem sender)
        {
            this.DismissModalViewController(true);
        }

        partial void BtnCancel_Activated(UIBarButtonItem sender)
        {
            this.DismissModalViewController(true);
        }

        public void Switchele_ValueChanged(object sender, EventArgs e)
        {
            UISwitch switchvalue = (UISwitch)sender;
            int value = Convert.ToInt32(switchvalue.Tag);
            string val = "qc/" + value;
            foreach (var option in AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions.data)
            {
                if (option.Caption == AppDelegate.appDelegate.AMFactoryOptionSelected)
                {
                    List<ReconQuestionsKBB> factoryOption = new List<ReconQuestionsKBB>();

                    foreach (var question in option.questions)
                    {

                        if (question.questionId == val)
                        {
                            if (switchvalue.On)
                            {
                                question.value = "true";
                            }
                            else
                            {
                                question.value = "false";
                            }

                        }

                    }

                }
            }
        }




        public AMOptionPopUp(IntPtr handle) : base(handle)
        {
        }

        StackLayout contentview = new StackLayout();




        public override void ViewDidLoad()
        {
            int y = 0;
            foreach (var option in AppDelegate.appDelegate.afterMarketOptions.aftermarketQuestions.data)
            {
                if (option.Caption == AppDelegate.appDelegate.AMFactoryOptionSelected)
                {

                    foreach (var question in option.questions)
                    {
                        UISwitch switchele = new UISwitch();
                        if (question.value == null)
                        {
                            question.value = "false";
                        }
                        switchele.On = Convert.ToBoolean(question.value.ToLower());

                        string[] tokens = question.questionId.Split('/');
                        switchele.Tag = Convert.ToInt32(tokens[1]);
                        switchele.ValueChanged += Switchele_ValueChanged;
                        UILabel label = new UILabel();
                        switchele.Frame = new CGRect(20, y + 33, UIScreen.MainScreen.Bounds.Width, 100);
                        label.Frame = new CGRect(80, y, UIScreen.MainScreen.Bounds.Width, 100);
                        y = y + 50;
                        switchele.UserInteractionEnabled = true;
                        label.Text = question.label;
                        AdditionAMFOOption.AddSubview(switchele);
                        AdditionAMFOOption.AddSubview(label);


                    }
                }
            }
        }

     
    }
}
