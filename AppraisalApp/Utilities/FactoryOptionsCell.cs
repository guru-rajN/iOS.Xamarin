using System;
using System.Collections.Generic;
using AppraisalApp.Models;
using ExtAppraisalApp;
using Foundation;
using UIKit;

namespace AppraisalApp.Utilities
{
    public class FactoryOptionsCell: UITableViewSource
    {

        protected List<FactoryOptionsKBB> tableItems;
        protected string cellIdentifier = "TableCell";
        OptionPopUp owner;

        public FactoryOptionsCell(List<FactoryOptionsKBB> items, OptionPopUp owner)
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
            return tableItems.Count;
        }

        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //Instantialte the Storyboard Object
            AppDelegate.appDelegate.FactoryOptionSelected = "";
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);

            //Instantiate the ViewController you want to navigate to.
            //Make sure you have set the Storyboard ID for this ViewController in your storyboard file.
            //Put this Storyboard ID in place of the TargetViewControllerName in below line. 
            UIViewController vcInstance = (UIViewController)storyboard.InstantiateViewController("AMOptionViewController");


            //Get the Instance of the TopViewController (CurrentViewController) or the NavigationViewController to push the TargetViewController onto the stack. 
            //NavigationController is an Instance of the NavigationViewController
           // owner.NavigationController.PushViewController(vcInstance, true);

        }

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            string item = "";

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }
        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (cell.RespondsToSelector(new ObjCRuntime.Selector("setSeparatorInset:"))) cell.SeparatorInset = UIEdgeInsets.Zero;
            if (cell.RespondsToSelector(new ObjCRuntime.Selector("setLayoutMargins:"))) cell.LayoutMargins = UIEdgeInsets.Zero;
        }

        //      public override string TitleForHeader (UITableView tableView, nint section)
        //      {
        //          return " ";
        //      }

    }

}

