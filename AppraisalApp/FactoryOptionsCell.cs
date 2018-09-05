using AppraisalApp.Models;
using ExtAppraisalApp;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppraisalApp
{
    public partial class FactoryOptionCell : UITableViewCell
    {
        public FactoryOptionCell(IntPtr handle) : base(handle)
        {
        }

        internal void UpdateCell(FactoryOptionsKBB factoryOption)
        {
        }

        //internal void UpdateCell(FactoryOptionsKBB factoryOption)
        //{


        //    switchElement.Tag = factoryOption.optionId;
        //    switchElement.On = Convert.ToBoolean(factoryOption.isSelected);
        //    switchElement.ValueChanged += Switchele_ValueChanged;

        //    LabelElement.Text = factoryOption.displayName;
        //    LabelElement.UserInteractionEnabled = true;
        //}

        private void Switchele_ValueChanged(object sender, EventArgs e)
        {
            UISwitch switchvalue = (UISwitch)sender;
            int value = Convert.ToInt32(switchvalue.Tag);
            foreach (var option in AppDelegate.appDelegate.fctoption)
            {
                if (option.Caption == AppDelegate.appDelegate.FactoryOptionSelected)
                {
                    List<FactoryOptionsKBB> factoryOption = new List<FactoryOptionsKBB>();

                    foreach (var question in option.questions)
                    {
                        // AppDelegate.appDelegate.factoryOptionsKBB = question;

                        if (question.optionId == value)
                        {

                            if (switchvalue.On)
                            {
                                question.isSelected = "true";

                            }
                            else
                            {
                                question.isSelected = "false";
                            }

                        }

                        // AppDelegate.appDelegate.factoryOptionsKBB.Add(question); 
                    }

                }
            }

        }
    }
}