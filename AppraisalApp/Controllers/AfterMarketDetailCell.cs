using ExtAppraisalApp;
using ExtAppraisalApp.Models;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppraisalApp
{
    public partial class AfterMarketDetailCell : UITableViewCell
    {
        public AfterMarketDetailCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(ReconQuestionsKBB amfactoryOption)
        {

            if (amfactoryOption.value == null)
            {
                amfactoryOption.value = "false";
            }
            string[] tokens = amfactoryOption.questionId.Split('/');
            switchElement.Tag = Convert.ToInt32(tokens[1]);
            switchElement.On = Convert.ToBoolean(amfactoryOption.value);
            switchElement.ValueChanged += Switchele_ValueChanged;

            LabelElement.Text = amfactoryOption.label;
            LabelElement.UserInteractionEnabled = true;
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

    }
}