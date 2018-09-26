using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class PhotoViewController : UIViewController
    {

        partial void PhotosSegment_Changed(UISegmentedControl sender)
        {

            var segmentIndex = sender.SelectedSegment;

            if (segmentIndex == 0)
            {
                AdditionalPhotosContainer.Hidden = true;
                PhotosContainer.Hidden = false;
            }
            else
            {
                PhotosContainer.Hidden = true;
                AdditionalPhotosContainer.Hidden = false;
                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdateAdditionalPhotos", null);
            }
        }

        private MasterViewController masterViewController;

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }



        partial void PhotosSaveBtn_Activated(UIBarButtonItem sender)
        {
            if (!AppDelegate.appDelegate.LeftCarImageUploaded)
            {

                var dictionary = new NSDictionary(new NSString("Left"), new NSString("Left"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.RightCarImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Right"), new NSString("Right"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.SeatCarImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Seat"), new NSString("Seat"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.BackSeatImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Seats"), new NSString("Seats"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.FrontCarImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Front"), new NSString("Front"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.BackCarImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Back"), new NSString("Back"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.OdometerImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Odometer"), new NSString("Odometer"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.DashBoardImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Dashboard"), new NSString("Dashboard"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.VINImageUplaoded)
            {
                var dictionary = new NSDictionary(new NSString("VIN"), new NSString("VIN"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }
            if (!AppDelegate.appDelegate.RimImageUploaded)
            {
                var dictionary = new NSDictionary(new NSString("Rim"), new NSString("Rim"));

                NSNotificationCenter.DefaultCenter.PostNotificationName("UpdatePhotoGraphs", null, dictionary);
            }

            if (AppDelegate.appDelegate.LeftCarImageUploaded && AppDelegate.appDelegate.RightCarImageUploaded && AppDelegate.appDelegate.SeatCarImageUploaded && AppDelegate.appDelegate.BackSeatImageUploaded && AppDelegate.appDelegate.FrontCarImageUploaded && AppDelegate.appDelegate.BackCarImageUploaded
               && AppDelegate.appDelegate.OdometerImageUploaded && AppDelegate.appDelegate.DashBoardImageUploaded && AppDelegate.appDelegate.VINImageUplaoded && AppDelegate.appDelegate.RimImageUploaded)
            {
                // Navigate to Summary 
                if (null == masterViewController)
                {
                    if (!UserInterfaceIdiomIsPhone)
                        masterViewController = (MasterViewController)((UINavigationController)SplitViewController.ViewControllers[0]).TopViewController;
                }

                ViewWorker viewWorker = new ViewWorker();
                viewWorker.WorkerDelegate = (ExtAppraisalApp.Utilities.WorkerDelegateInterface)masterViewController;
                viewWorker.ShowDoneImg(6);

                if (UserInterfaceIdiomIsPhone)
                {
                    var dictionary = new NSDictionary(new NSString("1"), new NSString("PhotoGraphs"));

                    NSNotificationCenter.DefaultCenter.PostNotificationName((Foundation.NSString)"MenuSelection", null, dictionary);
                }

                AppDelegate.appDelegate.IsPhotosSaved = true;

                this.PerformSegue("summarySegue", this);
            }


        }

        protected PhotoViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public async void ActivityLoader()
        {
            Utility.ShowLoadingIndicator(this.View, "Uploading ...", true);
            await Task.Delay(2000);
            Utility.HideLoadingIndicator(this.View);
        }

        public override void ViewDidLoad()
        {
            PhotosContainer.Hidden = false;
            AdditionalPhotosContainer.Hidden = true;


            base.ViewDidLoad();
        }

        public UIImage LoadImage(string filename)
        {
            string buttonName = filename + ".png";
            var documentsDirectory = Environment.GetFolderPath
                                             (Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);

            UIImage image = null;
            image = UIImage.FromFile(pngFilename);
            return image;
        }
    }
}

