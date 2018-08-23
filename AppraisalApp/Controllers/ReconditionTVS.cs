using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExtAppraisalApp.DB;
using Foundation;
using UIKit;
using static ExtAppraisalApp.ReconditionViewController;

namespace ExtAppraisalApp
{
    internal class ReconditionTVS : UITableViewSource
    {
        private List<Recondtionm> reconditions;


        public ReconditionTVS(List<Recondtionm> reconditions)
        {
            this.reconditions = reconditions;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ReconditionCell)tableView.DequeueReusableCell("cell_id", indexPath);
            var recondition = reconditions[indexPath.Row];

            cell.UpdateCell(recondition);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return reconditions.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string SelectedRow = indexPath.Row.ToString();
            var cell = tableView.CellAt(indexPath);
            // setSelectedIndex(SelectedRow.ReconditionHeader);
            cell.TintColor = UIColor.FromRGB(92, 165, 53);
            //cell.BackgroundColor = UIColor.FromRGB(169,202,141);
            cell.Accessory = (indexPath.Row >= 0) ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
            SavetolocalDb(SelectedRow);

        }

        void SavetolocalDb(string SelectedRow)
        {

            string SegmentIndex = globalInde.selectedSegmentIndex;
            string RowOption = SelectedRow;
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
            try
            {

                using (var conn = new SQLite.SQLiteConnection(DbPath))
                {
                    conn.CreateTable<ReconditionValue>();
                }
                var record = new ReconditionValue { RowOption = RowOption, SegmentIndex = SegmentIndex };
                using (var db = new SQLite.SQLiteConnection(DbPath))
                {
                    var existingRecord = (db.Table<ReconditionValue>().Where(c => c.SegmentIndex == record.SegmentIndex)).SingleOrDefault();
                    if (existingRecord != null)
                    {
                        existingRecord.RowOption = record.RowOption;
                        db.Update(existingRecord);
                    }
                    else
                    {
                        db.Insert(record);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //sqlitecode
        }
        //private void setSelectedIndex(string reconditionHeader)
        //{
        //     ReconditionSegment.SelectedSegment.ToString();
        //}



        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row >= 0)
            {
                var deselectedCell = tableView.CellAt(indexPath);
                if (deselectedCell != null)
                {
                    deselectedCell.Accessory = UITableViewCellAccessory.None;
                }
            }
        }



    }
}