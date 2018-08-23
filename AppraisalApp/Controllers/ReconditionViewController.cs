using ExtAppraisalApp.DB;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class ReconditionViewController : UIViewController
    {

        partial void ReconditionSaveBtn_Activated(UIBarButtonItem sender)
        {
            string labeltext = null;
            string segmentIndex = null;
            List<ReconditionValue> Saverecon = new List<ReconditionValue>();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);// Documents Folder
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);
          
            var connac = new SQLite.SQLiteConnection(DbPath);

            connac.CreateTable<ReconditionValue>();

            for (int i = 0; i <= 2; i++)
            {
                string segmentKey = i.ToString();
                var existings = (connac.Table<ReconditionValue>().Where(
                c => c.SegmentIndex == segmentKey)).SingleOrDefault();
                if (existings == null)
                {
                    if (i == 0)
                    {
                        globalInde.selectedSegmentIndex = "0";
                        setObjectRecon("0");

                        labeltext = "Mechanical";
                        ReconditionSegment.SelectedSegment = 0;
                    }
                    else if (i == 1)
                    {
                        globalInde.selectedSegmentIndex = "1";
                        setObjectRecon("1");

                        labeltext = "Interior";
                        ReconditionSegment.SelectedSegment = 1;
                    }
                    else if (i == 2)
                    {
                        globalInde.selectedSegmentIndex = "2";
                        setObjectRecon("2");

                        labeltext = "Exterior";
                        ReconditionSegment.SelectedSegment = 2;
                    }
                    ReconditionSaveBtn.TintColor = UIColor.Red;
                    selectionAlertLabel.Text = "please select any one of " + labeltext + " option";
                    selectionAlertLabel.TextColor = UIColor.Red;
                }
                else
                {
                    if (existings.SegmentIndex.ToString() == "0")
                    {
                        existings.SegmentIndex = "Mechanical";
                        ReconditionValue record1 = new ReconditionValue();
                        record1.RowOption = existings.RowOption.ToString();
                        record1.SegmentIndex = existings.SegmentIndex;
                        Saverecon.Add(record1);
                    }
                    else if (existings.SegmentIndex.ToString() == "1")
                    {
                        segmentIndex = "Exterior";
                        ReconditionValue record2 = new ReconditionValue();

                        record2.SegmentIndex = segmentIndex;
                        record2.RowOption = existings.RowOption.ToString();
                        Saverecon.Add(record2);
                    }
                    else if (existings.SegmentIndex.ToString() == "2")
                    {
                        segmentIndex = "Interior";
                        ReconditionValue record3 = new ReconditionValue();

                        record3.SegmentIndex = segmentIndex;
                        record3.RowOption = existings.RowOption.ToString();
                        Saverecon.Add(record3);
                    }
                }
            }
            if ((Saverecon.Count >= 3))
            {
                ReconditionSaveBtn.TintColor = UIColor.Black;
                selectionAlertLabel.Text = "";
                //alert.TextColor = UIColor.Black;
                //save recond api
            }
        }

        public static class globalInde
        {
            public static string selectedSegmentIndex = null;
            public static string oldselectedSegmentIndex = null;
        }

        partial void SegmentValue_Changed(UISegmentedControl sender)
        {
            string segmentID = ReconditionSegment.SelectedSegment.ToString();
            if ((globalInde.selectedSegmentIndex != null))
            {
                globalInde.oldselectedSegmentIndex = globalInde.selectedSegmentIndex.ToString();
            }
            globalInde.selectedSegmentIndex = segmentID.ToString();
            setObjectRecon(segmentID);
            //var a = ReconditionTableView.IndexPathsForSelectedRows;


        }


        protected ReconditionViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


        private void setObjectRecon(string segmentID)
        {
            string FlawReconditionDescription = null;
            string AboveAvargeDescription = null;
            string AvarageDescription = null;
            string BelowAvarageDescription = null;
            string RoughDescription = null;
            string TowDescription = null;
            if (segmentID == "0")
            {
                FlawReconditionDescription = "This vehicle runs like its showroom new. Everything works, there are no outstanding issues and it’s never been in an accident. It’s only been service at a dealer. The wheels and/or lead cover are free of scratches and dents. The tires are in great shape.";
                AboveAvargeDescription = "This vehicle has no mechanical issues and the service records are up to date. There are no leaks. No warning lights on. The wheels and/or wheel covers are free of scratches and dents. The tires are in good shape.";
                AvarageDescription = "This vehicle may have had mechanical issues but they corrected. The tires are good and have a little life left in them. The wheels and/or wheel covers may have minor scratches but no dents.";
                BelowAvarageDescription = "This vehicle may have had mechanical issues that have not been corrected. The tires need to be replaced and the wheels and/or wheel covers may have scratches or dent but are not bent.";
                RoughDescription = "This vehicle needs major repairs but is drivable. The tires need to be replaced and the wheels and/or wheel covers may have scratches, dents or bent.";
                TowDescription = "The required repairs makes this vehicle unsafe to drive to us.";
            }
            else if (segmentID == "1")
            {
                FlawReconditionDescription = "The interior is brand new. Free of stains, wear, burns, tears or odors and everything works.";
                AboveAvargeDescription = "This interior has minimal signs wear but is free of stains, burns, tears or odors. Everything works and is in place.";
                AvarageDescription = "This interior starting to show some signs of wear and the carpet may have a small stain but is otherwise free of burns, tears or odors.";
                BelowAvarageDescription = "There is visible wear and staining. The upholstery or door panels may have a tear or burn and there could be a slight odor.";
                RoughDescription = "There is extensive wear or staining. Burns and tears may exists and floor mats are missing or worn out. The headline may sag or be ripped. The dashboard may have visible cracks.";
                TowDescription = "In addition to extensive wear, pieces or the interior are missing or out of place.";
            }
            else if (segmentID == "2")
            {
                FlawReconditionDescription = "This vehicle is showroom new and free of any scratches, dents, crack, chip or other damage. All glass is clear and free of defects and all lights are clear and in perfect condition. The vehicle has never been repaired, repainted or in an accident.";
                AboveAvargeDescription = "This vehicle is almost perfect with no more than 2 panels with minor scratches (less than 4”) or small dents (smaller than a quarter) but is otherwise free of damage or defects. All glass is clear and free of defects and all lights are clear. The vehicle has never been repaired, repainted or in an accident.";
                AvarageDescription = "This vehicle is in average condition. It has no more than 4 panels with minor scratches (less than 4”) or small dents (smaller than a quarter). The windshield may have a chip in it but is otherwise free from damage. The headlight may have mirror fading around the edges. The vehicle has never been repaired or repainted.";
                BelowAvarageDescription = "This vehicle has cosmetic damage on up to 6 panels. There are small dents and scratches as well as large ones. The windshield may have chips or cracks and the headlights may be faded. This vehicle may have been repaired or repainted.";
                RoughDescription = "This vehicle has visible damage. It may be rusted and the headlights are faded, the glass may be crack.";
                TowDescription = "The damage to this vehicle makes it unsafe to drive to us.";
            }

            var reconditions = new List<Recondtionm>
            {
                new Recondtionm
                {

                    ReconditionHeader="Flawless",
                    ReconditionDescription=FlawReconditionDescription,
                },
                new Recondtionm
                {
                    ReconditionHeader="Above Average",
                    ReconditionDescription=AboveAvargeDescription,
                },
                new Recondtionm
                {
                    ReconditionHeader="Average",
                    ReconditionDescription=AvarageDescription,
                },
                new Recondtionm
                {
                    ReconditionHeader="Less Than Average",
                    ReconditionDescription=BelowAvarageDescription
                },
                new Recondtionm
                {
                    ReconditionHeader="Rough",
                    ReconditionDescription=RoughDescription,
                },
                new Recondtionm
                {
                    ReconditionHeader="Tow In",
                    ReconditionDescription=TowDescription,
                },
            };

            ReconditionTableView.Source = new ReconditionTVS(reconditions);
            ReconditionTableView.RowHeight = UITableView.AutomaticDimension;
            ReconditionTableView.EstimatedRowHeight = 40f;
            ReconditionTableView.ReloadData();

            string selectedSegmentIndex = globalInde.oldselectedSegmentIndex;
            //nint removeRowHeader;
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var DbPath = Path.Combine(libraryPath, DBConstant.DB_NAME);


            using (var conna = new SQLite.SQLiteConnection(DbPath))
            {
                conna.CreateTable<ReconditionValue>();
            }
            var conn = new SQLite.SQLiteConnection(DbPath);

            //var existing = (conn.Table<ReconditionValue>().Where(
            //    c => c.SegmentIndex == selectedSegmentIndex)).SingleOrDefault();
            //if (existing == null)
            //{             
            //}
            //else
            //{
            //    removeRowHeader = Int32.Parse(existing.RowOption); 
            //    ReconditionTableView.DeselectRow(NSIndexPath.FromRowSection(removeRowHeader, 0), false);
            //    var cellun = ReconditionTableView.CellAt(NSIndexPath.FromRowSection(removeRowHeader, 0));
            //    if (cellun!=null)
            //    {
            //        cellun.Accessory = UITableViewCellAccessory.None;
            //    }
            //}

            for (int i = 0; i <= 5; i++)
            {
                ReconditionTableView.DeselectRow(NSIndexPath.FromRowSection(i, 0), false);
                var cellun = ReconditionTableView.CellAt(NSIndexPath.FromRowSection(i, 0));
                if (cellun != null)
                {
                    cellun.Accessory = UITableViewCellAccessory.None;
                }


            }

            nint rowselected;
            var existings = (conn.Table<ReconditionValue>().Where(
                c => c.SegmentIndex == segmentID)).SingleOrDefault();
            if (existings == null)
            {
                //rowselected = -1;
            }
            else
            {
                rowselected = Int32.Parse(existings.RowOption);
                ReconditionTableView.SelectRow(NSIndexPath.FromRowSection(rowselected, 0), false, UITableViewScrollPosition.Middle);
                //var cellaa = ReconditionTableView.CellAt(NSIndexPath.FromRowSection(rowselected, 0));
                //cellaa.TintColor = UIColor.FromRGB(92, 165, 53);
                //cellaa.Accessory = UITableViewCellAccessory.Checkmark;

            }
            //SQLite read code indexrow for selected segment and pass the same if nothing set -1


            // NSIndexPath path = NSIndexPath.FromRowSection(5, 0);
            //ReconditionTVS.DeselectAll(ReconditionTableView);
            //  Rowselected();
        }

        void Rowselected()
        {
            NSIndexPath path = NSIndexPath.FromRowSection(5, 0);
            ReconditionTableView.SelectRow(path, false, UITableViewScrollPosition.None);
            //NSIndexPath pathin = NSIndexPath.FromRowSection(5, 0);
            // var cell = ReconditionTableView.CellAt(pathin);
            //cell.TintColor = UIColor.FromRGB(92, 165, 53);
            //cell.BackgroundColor = UIColor.FromRGB(169,202,141);
            //cell.Accessory = (path.Row >= 0) ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string segmentID = ReconditionSegment.SelectedSegment.ToString();
            setObjectRecon(segmentID);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public Object setSegemtIn
        {
            set;
            get;
        }
    }
}