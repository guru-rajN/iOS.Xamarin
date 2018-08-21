using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class PopOverViewController : UITableViewController
    {

        public string title { get; set; }

        public List<Object> listData { get; set; }

        private UIPickerView pickerView;

        public static PopOverModel PopOverModel;


        public PopOverViewController(IntPtr handle) : base(handle)
        {
        }

        private void ConfigureView()
        {

            titleText.Text = title;

            DoneBtn.Enabled = false;

            PopOverTableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));

            // create our simple picker model

            PopOverModel = new PopOverModel();

            //foreach (string countryName in listData)
            //{
            //    PopOverModel.Items.Add(countryName);
            //}

            //createPickerView ();

            pickerView = new UIPickerView();
            pickerView.Model = PopOverModel;
            pickerView.ShowSelectionIndicator = true;

            // To create a toolbar with done button
            UIToolbar toolbar = new UIToolbar();
            toolbar.BarStyle = UIBarStyle.Black;
            toolbar.Translucent = true;
            toolbar.SizeToFit();

            UIBarButtonItem doneBtn = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) => {
                foreach (UIView view in this.View.Subviews)
                {
                    subtitleText.Text = PopOverModel.Items[(int)pickerView.SelectedRowInComponent(0)].ToString();
                    //var Id = AppDelegate.StoresDictionary.FirstOrDefault(x => x.Key.Contains(txtLocationSelector.Text)).Value;
                    //storeLocatorId = Int32.Parse(Id);
                    subtitleText.Text = PopOverModel.Items[(int)pickerView.SelectedRowInComponent(0)].ToString();
                    subtitleText.ResignFirstResponder();
                }
                DoneBtn.Enabled = true;
            });
            toolbar.SetItems(new UIBarButtonItem[] { doneBtn }, true);

            // To assign inputview has pickerview
            subtitleText.InputView = pickerView;
            subtitleText.InputAccessoryView = toolbar;

            subtitleText.TouchDown += SetPicker;
            subtitleText.Placeholder = "Required";
        }

        public override void ViewDidLoad()
        {
            ConfigureView();

            base.ViewDidLoad();

        }

        private void SetPicker(object sender, EventArgs e)
        {
            UITextField field = (UITextField)sender;
            if (field.Text != "")
                pickerView.Select(PopOverModel.Items.IndexOf(field.Text), 0, true);
        }

        // Cancel button click event
        partial void CancelBtn_Activated(UIBarButtonItem sender)
        {
            this.DismissViewController(true, null);
        }

        // Done btn Click Event
        partial void DoneBtn_Activated(UIBarButtonItem sender)
        {
            this.DismissViewController(true, null);
        }

    }

    // Inner Class : StatusChange Model : Pickerview
    public class PopOverModel : UIPickerViewModel
    {
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// The items to show up in the picker
        /// </summary>
        public List<string> Items { get; private set; }

        /// <summary>
        /// The current selected item
        /// </summary>
        public string SelectedItem
        {
            get { return Items[selectedIndex]; }
        }

        int selectedIndex = 0;

        public PopOverModel()
        {
            Items = new List<string>();
        }

        /// <summary>
        /// Called by the picker to determine how many rows are in a given spinner item
        /// </summary>
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Items.Count;
        }

        /// <summary>
        /// called by the picker to get the text for a particular row in a particular
        /// spinner item
        /// </summary>
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return Items[(int)row];
        }

        /// <summary>
        /// called by the picker to get the number of spinner items
        /// </summary>
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        /// <summary>
        /// called when a row is selected in the spinner
        /// </summary>
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            selectedIndex = (int)row;
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }

    }
}