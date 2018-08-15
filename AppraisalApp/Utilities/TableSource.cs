using System;
using System.Collections.Generic;
using System.IO;
using ExtAppraisalApp;
using Foundation;
using UIKit;

namespace AppraisalApp.Utilities
{
    public class TableSource : UITableViewSource
    {

        protected string[] tableItems;
        protected string cellIdentifier = "TableCell";
        FactoryOptionViewController owner;

        public TableSource(string[] items, FactoryOptionViewController owner)
        {
            tableItems = items;
            this.owner = owner;

        }

        /// <summary>
        /// Called by the TableView to determine how many sections(groups) there are.
        /// </summary>
        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            

            UITextField field = null;
            //UISwitch checkele = null;
            AppDelegate.appDelegate.FactoryOptionSelected = tableItems[indexPath.Row];
            //UIAlertController okAlertController = UIAlertController.Create("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.ActionSheet);
            UIAlertController okAlertController = UIAlertController.Create(tableItems[indexPath.Row],null, UIAlertControllerStyle.Alert);




            foreach(var option in AppDelegate.appDelegate.fctoption){
                if(option.Caption==AppDelegate.appDelegate.FactoryOptionSelected)
                {
                    foreach(var question in option.questions){
                        okAlertController.AddTextField((textField) => {
                            // Save the field
                            field = textField;

                            field.Placeholder = question.displayName;
                            field.Text = question.displayName;
                            field.AutocorrectionType = UITextAutocorrectionType.No;
                            field.KeyboardType = UIKeyboardType.Default;
                            field.ReturnKeyType = UIReturnKeyType.Done;
                            field.ClearButtonMode = UITextFieldViewMode.WhileEditing;

                        });
                    }

                    
                }

            }
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentModalViewController(okAlertController, true);
                owner.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;

            }
            else
            {
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentModalViewController(okAlertController, true);
                owner.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;

            }
           

            tableView.DeselectRow(indexPath, true);
        }

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            string item = tableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

        //      public override string TitleForHeader (UITableView tableView, nint section)
        //      {
        //          return " ";
        //      }

    }

}
