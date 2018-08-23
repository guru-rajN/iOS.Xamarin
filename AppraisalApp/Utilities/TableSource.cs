using System;
using System.Collections.Generic;
using System.IO;
using ExtAppraisalApp;
using Foundation;
using UIKit;
using CoreGraphics;
using ExtAppraisalApp.Services;

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

        protected TableSource(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
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
            //Instantialte the Storyboard Object

            //this.PerformSegue("popOverSegue", this);
           // owner.PerformSegue("FacOptionSegue", this);
            AppDelegate.appDelegate.FactoryOptionSelected = tableItems[indexPath.Row];
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);

            //Instantiate the ViewController you want to navigate to.
            //Make sure you have set the Storyboard ID for this ViewController in your storyboard file.
            //Put this Storyboard ID in place of the TargetViewControllerName in below line. 
            UIViewController vcInstance = (UIViewController)storyboard.InstantiateViewController("OptionPopUp");


            //Get the Instance of the TopViewController (CurrentViewController) or the NavigationViewController to push the TargetViewController onto the stack. 
            //NavigationController is an Instance of the NavigationViewController

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                owner.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
                owner.PresentModalViewController(vcInstance, true);

            }
            else
            {
                owner.PresentModalViewController(vcInstance, true);

            }

           // owner.PresentModalViewController(vcInstance, true);
           // owner.NavigationController.PushViewController(vcInstance, true);

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
