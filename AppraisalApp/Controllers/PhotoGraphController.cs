using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class PhotoGraphController : UIViewController
    {

        // Detect the device whether iPad or iPhone
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        void ActionButton_TouchUpInside()
        {
            var alert = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);
            var image = UIImage.FromBundle("camera.png");
            var camera = UIAlertAction.Create("Camera ", UIAlertActionStyle.Default, (s) => { CameraBtna_TouchUpInside(); });
            camera.SetValueForKey(image, new NSString("image"));


            alert.AddAction(camera);

            var gallery = UIAlertAction.Create("Gallery", UIAlertActionStyle.Default, (k) => { GalleryButtona_TouchUpInside(); });
            var galleryicon = UIImage.FromBundle("gallery.png");
            gallery.SetValueForKey(galleryicon, new NSString("image"));
            alert.AddAction(gallery);

            var cancelaction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);
            alert.AddAction(cancelaction);
            UIPopoverPresentationController presentationPopover = alert.PopoverPresentationController;
            if (presentationPopover != null)
            {
                presentationPopover.SourceView = this.View;
                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Right;
            }
            this.PresentViewController(alert, true, null);
        }

        string currentButton = null;


        partial void Front_TouchUpInside(UIButton sender)
        {
            //viewPopup.Hidden = false;
            currentButton = "front";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-front";
        }



        partial void Back_TouchUpInside(UIButton sender)
        {
            //viewPopup.Hidden = false;
            currentButton = "back";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-rear";
        }

        partial void Left_TouchUpInside(UIButton sender)
        {
            currentButton = "left";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-driver-side";
        }

        partial void Right_TouchUpInside(UIButton sender)
        {
            currentButton = "right";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-passenger-side";
        }
        partial void Seats_TouchUpInside(UIButton sender)
        {
            currentButton = "seats";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-interior-rear";
        }

        partial void Seat_TouchUpInside(UIButton sender)
        {
            currentButton = "seat";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-interior-front";
        }
        partial void Odometer_TouchUpInside(UIButton sender)
        {
            currentButton = "odometer";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-dashboard";
        }

        partial void Dashboard_TouchUpInside(UIButton sender)
        {
            currentButton = "dashboard";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-odometer";
        }
        partial void Rim_TouchUpInside(UIButton sender)
        {
            currentButton = "rim";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-wheels";
        }

        partial void VIN_TouchUpInside(UIButton sender)
        {
            currentButton = "VIN";
            ActionButton_TouchUpInside();
            AppDelegate.appDelegate.photoButtonClicked = "photo-vin";
        }
        //partial void Odometer_TouchUpInside(UIButton sender)
        //{
        //    //viewPopup.Hidden = false;
        //    currentButton = "odometer";
        //    ActionButton_TouchUpInside();
        //}

        //partial void Dashboard_TouchUpInside(UIButton sender)
        //{
        //    //viewPopup.Hidden = false;
        //    currentButton = "dashboard";
        //    ActionButton_TouchUpInside();
        //}

        //partial void Seat_TouchUpInside(UIButton sender)
        //{
        //    //viewPopup.Hidden = false;
        //    currentButton = "seat";
        //    ActionButton_TouchUpInside();
        //}

        //partial void Front_TouchUpInside(UIButton sender)
        //{
        //    //viewPopup.Hidden = false;
        //    currentButton = "front";
        //    ActionButton_TouchUpInside();
        //}

        UIImagePickerController imagePicker;
        bool iSCamera = false;
        void GalleryButtona_TouchUpInside()
        {
            //viewPopup.Hidden = true;
            iSCamera = false;
            imagePicker = new UIImagePickerController();
            imagePicker.PrefersStatusBarHidden();
            imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            imagePicker.AllowsEditing = true;
            imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            imagePicker.Canceled += Handle_Canceled;
            PresentViewController(imagePicker, true, () => { });

        }



        void CameraBtna_TouchUpInside()
        {
            Console.WriteLine("Capture button clicked ");
            try
            {
                iSCamera = true;
                //viewPopup.Hidden = true;
                imagePicker = new UIImagePickerController();
                imagePicker.PrefersStatusBarHidden();
                imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
                imagePicker.AllowsEditing = true;
                imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                imagePicker.Canceled += Handle_Canceled;
                PresentViewController(imagePicker, true, () => { });
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }

        }
        public void setImage(UIImage Image)
        {
            switch (currentButton)
            {
                case "front":

                    Front.TintColor = UIColor.Clear;
                    Front.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.FrontCarImageUploaded = true;
                    Front.Layer.BorderColor = UIColor.Black.CGColor;

                    // Right_Image.SizeToFit();
                    break;
                case "back":
                    Back.TintColor = UIColor.Clear;
                    Back.SetBackgroundImage(Image, UIControlState.Normal);
                    // Left_Image.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.BackCarImageUploaded = true;
                    Back.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                case "right":
                    Right.TintColor = UIColor.Clear;
                    Right.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.RightCarImageUploaded = true;
                    Right.Layer.BorderColor = UIColor.Black.CGColor;
                    /// Front.SetBackgroundImage(Image, UIControlState.Normal);
                    break;
                case "left":
                    Left.TintColor = UIColor.Clear;
                    Left.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.LeftCarImageUploaded = true;
                    Left.Layer.BorderColor = UIColor.Black.CGColor;
                    /// Odometer.SetBackgroundImage(Image, UIControlState.Normal);
                    break;
                case "seat":
                    Seat.TintColor = UIColor.Clear;
                    Seat.SetBackgroundImage(Image, UIControlState.Normal);
                    ///Seat.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.SeatCarImageUploaded = true;
                    Seat.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                case "seats":
                    Seats.TintColor = UIColor.Clear;
                    Seats.SetBackgroundImage(Image, UIControlState.Normal);

                    AppDelegate.appDelegate.BackSeatImageUploaded = true;
                    Seats.Layer.BorderColor = UIColor.Black.CGColor;
                    ///Seat.SetBackgroundImage(Image, UIControlState.Normal);
                    break;
                case "dashboard":
                    Dashboard.TintColor = UIColor.Clear;
                    Dashboard.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.DashBoardImageUploaded = true;
                    Dashboard.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                case "odometer":
                    Odometer.TintColor = UIColor.Clear;
                    Odometer.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.OdometerImageUploaded = true;
                    Odometer.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                case "rim":
                    Rim.TintColor = UIColor.Clear;
                    Rim.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.RimImageUploaded = true;
                    Rim.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                case "VIN":
                    VIN.TintColor = UIColor.Clear;
                    VIN.SetBackgroundImage(Image, UIControlState.Normal);
                    AppDelegate.appDelegate.VINImageUplaoded = true;
                    VIN.Layer.BorderColor = UIColor.Black.CGColor;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
        }

        public void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {

            var originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;

            var meta = e.Info[UIImagePickerController.MediaMetadata] as NSDictionary;

            try
            {
                if (originalImage != null)
                {
                    Console.WriteLine("got the original image");
                    //Right_Image.SetBackgroundImage(originalImage, UIControlState.Normal);

                    //imageView.Image = originalImage; // display
                    setImage(originalImage);
                    var documentsDirectory = Environment.GetFolderPath
                                              (Environment.SpecialFolder.Personal);
                    string buttonName = currentButton + ".png";
                    string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
                    NSData imgData = originalImage.AsJPEG(0.0f);
                    NSError err = null;
                    if (imgData.Save(pngFilename, false, out err))
                    {
                        Console.WriteLine("saved as " + pngFilename);
                    }
                    else
                    {
                        Console.WriteLine("NOT saved as" + pngFilename + " because" + err.LocalizedDescription);
                    }

                    //ALAssetsLibrary library = new ALAssetsLibrary();

                    //library.WriteImageToSavedPhotosAlbum(originalImage.CGImage, meta, (assetUrl, error) => {
                    //    Console.WriteLine("assetUrl:" + assetUrl);
                    //});
                    var imagea = UIImage.LoadFromData(imgData);

                    //imagea.SaveToPhotosAlbum((AppraisalPhotoAlbum, eror) =>
                    //{

                    //});
                    var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
                    string Orientaion = "Landscape";
                    if (iSCamera)
                    {
                        if (currentOrientation == UIInterfaceOrientation.Portrait)
                        {
                            Orientaion = "Portrait";
                        }
                        else
                        {
                            Orientaion = "Landscape";
                        }
                    }
                    iSCamera = false;
                    NSData imageData = originalImage.AsJPEG(0.0f);

                    byte[] myByteArray = new byte[imageData.Length];
                    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));

                    imagePicker.DismissModalViewController(true);
                    Amazon.Aws amazonS3 = new Amazon.Aws();
                    Task.Run(() => amazonS3.UploadFile(pngFilename, myByteArray, Orientaion));
                    ActivityLoader();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }

            // dismiss the picker
            //imagePicker.DismissModalViewController(true);
            //imagePicker.DismissModalViewControllerAnimated(true);
        }



        void Handle_Canceled(object sender, EventArgs e)
        {
            imagePicker.DismissModalViewController(true);
            //imagePicker.DismissModalViewControllerAnimated(true);
        }

        protected PhotoGraphController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public async void ActivityLoader()
        {
            var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
            Utility.ShowLoadingIndicator(splitViewController.View, "Uploading ...", true);
            await Task.Delay(2000);
            Utility.HideLoadingIndicator(splitViewController.View);
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            Front.Layer.BorderWidth = 2.0f;
            Front.Layer.BorderColor = UIColor.Black.CGColor;
            Back.Layer.BorderWidth = 2.0f;
            Back.Layer.BorderColor = UIColor.Black.CGColor;
            Right.Layer.BorderWidth = 2.0f;
            Right.Layer.BorderColor = UIColor.Black.CGColor;
            Left.Layer.BorderWidth = 2.0f;
            Left.Layer.BorderColor = UIColor.Black.CGColor;
            Seat.Layer.BorderWidth = 2.0f;
            Seat.Layer.BorderColor = UIColor.Black.CGColor;
            Seats.Layer.BorderWidth = 2.0f;
            Seats.Layer.BorderColor = UIColor.Black.CGColor;
            Dashboard.Layer.BorderWidth = 2.0f;
            Dashboard.Layer.BorderColor = UIColor.Black.CGColor;
            Odometer.Layer.BorderWidth = 2.0f;
            Odometer.Layer.BorderColor = UIColor.Black.CGColor;
            Rim.Layer.BorderWidth = 2.0f;
            Rim.Layer.BorderColor = UIColor.Black.CGColor;
            VIN.Layer.BorderWidth = 2.0f;
            VIN.Layer.BorderColor = UIColor.Black.CGColor;

            //Notify photos selection and validation
            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"UpdatePhotoGraphs", UpdatePhotoGraphViews);

            setPersistedImage();

        }

        Task<PhotoGetResponse.Datum> GetPhotosWebServiceCall(long vehicleID, short storeId, short invtrId)
        {
            return Task<PhotoGetResponse.Datum>.Factory.StartNew(() =>
            {
                return GetPhotos(vehicleID, storeId, invtrId);

            });
        }

        public PhotoGetResponse.Datum GetPhotos(long vehicleID, short storeId, short invtrId)
        {
            PhotoGetResponse.Datum getphotoResponses = new PhotoGetResponse.Datum();
            getphotoResponses = ServiceFactory.getWebServiceHandle().GetPhoto(vehicleID, storeId, invtrId);
            return getphotoResponses;

        }

        private void UpdatePhotoGraphViews(NSNotification obj)
        {
            Debug.WriteLine("notification msg :: " + obj.UserInfo);
            var userInfo = obj.UserInfo;
            var NotificationMsg = "";
            if (null != userInfo)
                NotificationMsg = userInfo.Keys[0].ToString();

            if (NotificationMsg.Equals("Left"))
            {
                Left.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Right"))
            {
                Right.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Seat"))
            {
                Seat.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Seats"))
            {
                Seats.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Front"))
            {
                Front.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Back"))
            {
                Back.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Odometer"))
            {
                Odometer.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Dashboard"))
            {
                Dashboard.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("VIN"))
            {
                VIN.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else if (NotificationMsg.Equals("Rim"))
            {
                Rim.Layer.BorderColor = UIColor.Red.CGColor;
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"UpdatePhotoGraphs");

            base.ViewDidDisappear(animated);
        }

        private async void setPersistedImage()
        {

            UIImage rightImage = LoadImage("right");
            if (rightImage != null)
            {
                Right.SetBackgroundImage(rightImage, UIControlState.Normal);
                Right.TintColor = UIColor.Clear;
                AppDelegate.appDelegate.RightCarImageUploaded = true;
                Right.Layer.BorderColor = UIColor.Black.CGColor;
            }
            else
            {
                await setPersistImageOnlineAsync("right");
                rightImage = LoadImage("right");
                if (rightImage != null)
                {
                    rightImage = LoadImage("right");
                    Right.SetBackgroundImage(rightImage, UIControlState.Normal);
                    Right.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.RightCarImageUploaded = true;
                    Right.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }

            UIImage leftImage = LoadImage("left");
            if (leftImage != null)
            {
                Left.TintColor = UIColor.Clear;
                Left.SetBackgroundImage(leftImage, UIControlState.Normal);
                AppDelegate.appDelegate.LeftCarImageUploaded = true;
                Left.Layer.BorderColor = UIColor.Black.CGColor;

            }
            else
            {
                await setPersistImageOnlineAsync("left");
                leftImage = LoadImage("left");
                if (leftImage != null)
                {
                    leftImage = LoadImage("left");
                    Left.SetBackgroundImage(leftImage, UIControlState.Normal);
                    Left.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.LeftCarImageUploaded = true;
                    Left.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage frontImage = LoadImage("front");
            if (frontImage != null)
            {

                Front.TintColor = UIColor.Clear;
                Front.SetBackgroundImage(frontImage, UIControlState.Normal);
                AppDelegate.appDelegate.FrontCarImageUploaded = true;
                Front.Layer.BorderColor = UIColor.Black.CGColor;
            }
            else
            {
                await setPersistImageOnlineAsync("front");
                frontImage = LoadImage("front");
                if (frontImage != null)
                {
                    frontImage = LoadImage("front");
                    Front.SetBackgroundImage(frontImage, UIControlState.Normal);
                    Front.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.FrontCarImageUploaded = true;
                    Front.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }

            UIImage backImage = LoadImage("back");
            if (backImage != null)
            {
                Back.TintColor = UIColor.Clear;
                Back.SetBackgroundImage(backImage, UIControlState.Normal);
                AppDelegate.appDelegate.BackCarImageUploaded = true;
                Back.Layer.BorderColor = UIColor.Black.CGColor;

            }
            else
            {
                await setPersistImageOnlineAsync("back");
                backImage = LoadImage("back");
                if (backImage != null)
                {
                    backImage = LoadImage("back");
                    Back.SetBackgroundImage(backImage, UIControlState.Normal);
                    Back.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.BackCarImageUploaded = true;
                    Back.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage seatImage = LoadImage("seat");
            if (seatImage != null)
            {
                Seat.TintColor = UIColor.Clear;
                Seat.SetBackgroundImage(seatImage, UIControlState.Normal);
                AppDelegate.appDelegate.SeatCarImageUploaded = true;
                Left.Layer.BorderColor = UIColor.Black.CGColor;
            }
            else
            {
                await setPersistImageOnlineAsync("seat");
                seatImage = LoadImage("seat");
                if (seatImage != null)
                {
                    seatImage = LoadImage("seat");
                    Seat.SetBackgroundImage(seatImage, UIControlState.Normal);
                    Seat.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.SeatCarImageUploaded = true;
                    Seat.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage seatsImage = LoadImage("seats");
            if (seatsImage != null)
            {
                Seats.TintColor = UIColor.Clear;
                Seats.SetBackgroundImage(seatsImage, UIControlState.Normal);
                AppDelegate.appDelegate.BackSeatImageUploaded = true;
                Seats.Layer.BorderColor = UIColor.Black.CGColor;
            }
            else
            {
                await setPersistImageOnlineAsync("seats");
                seatsImage = LoadImage("seats");
                if (seatsImage != null)
                {
                    seatsImage = LoadImage("seats");
                    Seats.SetBackgroundImage(seatsImage, UIControlState.Normal);
                    Seats.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.BackSeatImageUploaded = true;
                    Seats.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage dashImage = LoadImage("dashboard");
            if (dashImage != null)
            {
                Dashboard.TintColor = UIColor.Clear;
                Dashboard.SetBackgroundImage(dashImage, UIControlState.Normal);
                AppDelegate.appDelegate.DashBoardImageUploaded = true;
                Dashboard.Layer.BorderColor = UIColor.Black.CGColor;

            }
            else
            {
                await setPersistImageOnlineAsync("dashboard");
                dashImage = LoadImage("dashboard");
                if (dashImage != null)
                {
                    dashImage = LoadImage("dashboard");
                    Dashboard.SetBackgroundImage(dashImage, UIControlState.Normal);
                    Dashboard.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.DashBoardImageUploaded = true;
                    Dashboard.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage odoImage = LoadImage("odometer");
            if (odoImage != null)
            {
                Odometer.TintColor = UIColor.Clear;
                Odometer.SetBackgroundImage(odoImage, UIControlState.Normal);
                AppDelegate.appDelegate.OdometerImageUploaded = true;
                Odometer.Layer.BorderColor = UIColor.Black.CGColor;

            }
            else
            {
                await setPersistImageOnlineAsync("odometer");
                odoImage = LoadImage("odometer");
                if (odoImage != null)
                {
                    odoImage = LoadImage("odometer");
                    Odometer.SetBackgroundImage(odoImage, UIControlState.Normal);
                    Odometer.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.OdometerImageUploaded = true;
                    Odometer.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage rimImage = LoadImage("rim");
            if (rimImage != null)
            {
                Rim.TintColor = UIColor.Clear;
                Rim.SetBackgroundImage(rimImage, UIControlState.Normal);
                AppDelegate.appDelegate.RimImageUploaded = true;
                Rim.Layer.BorderColor = UIColor.Black.CGColor;

            }
            else
            {
                await setPersistImageOnlineAsync("rim");
                rimImage = LoadImage("rim");
                if (rimImage != null)
                {
                    rimImage = LoadImage("rim");
                    Rim.SetBackgroundImage(rimImage, UIControlState.Normal);
                    Rim.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.RimImageUploaded = true;
                    Rim.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            UIImage vinImage = LoadImage("VIN");
            if (vinImage != null)
            {
                VIN.TintColor = UIColor.Clear;
                VIN.SetBackgroundImage(vinImage, UIControlState.Normal);
                AppDelegate.appDelegate.VINImageUplaoded = true;
                VIN.Layer.BorderColor = UIColor.Black.CGColor;
            }
            else
            {
                await setPersistImageOnlineAsync("VIN");
                vinImage = LoadImage("VIN");
                if (vinImage != null)
                {
                    vinImage = LoadImage("VIN");
                    VIN.SetBackgroundImage(vinImage, UIControlState.Normal);
                    VIN.TintColor = UIColor.Clear;
                    AppDelegate.appDelegate.VINImageUplaoded = true;
                    VIN.Layer.BorderColor = UIColor.Black.CGColor;
                }
            }
            InvokeOnMainThread(() =>
            {
                var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                Utility.HideLoadingIndicator(splitViewController.View);
            });

        }

        private async Task setPersistImageOnlineAsync(string buttonImageName)
        {


            if (AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos == null)
            {

                if (!AppDelegate.appDelegate.photoAcesss)
                {
                    AppDelegate.appDelegate.photoAcesss = true;
                    try
                    {
                        var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                        Utility.ShowLoadingIndicator(splitViewController.View, "Retrieving...", true);
                    }
                    catch (Exception exc)
                    {
                        Debug.WriteLine("Exception occurred :: " + exc.Message);
                    }

                    //Showndicator(this.View, "Photographs..", true);
                    AppDelegate.appDelegate.getphotoResponses = await GetPhotosWebServiceCall(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId);
                    //AppDelegate.appDelegate.getphotoResponses = GetPhotos(AppDelegate.appDelegate.vehicleID, AppDelegate.appDelegate.storeId, AppDelegate.appDelegate.invtrId);

                    if (AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos != null)
                    {

                        foreach (var a in AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos)
                        {
                            if (a.PhotoGuide == "photo-rear")
                            {
                                AppDelegate.appDelegate.BackCarImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-front")
                            {
                                AppDelegate.appDelegate.FrontCarImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-passenger-side")
                            {
                                AppDelegate.appDelegate.RightCarImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-driver-side")
                            {
                                AppDelegate.appDelegate.LeftCarImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-interior-rear")
                            {
                                AppDelegate.appDelegate.BackSeatImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-interior-front")
                            {
                                AppDelegate.appDelegate.SeatCarImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-dashboard")
                            {
                                AppDelegate.appDelegate.DashBoardImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-vin")
                            {
                                AppDelegate.appDelegate.VINImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-odometer")
                            {
                                AppDelegate.appDelegate.OdometerImageURL = a.PhotoURL;
                            }
                            if (a.PhotoGuide == "photo-wheels")
                            {
                                AppDelegate.appDelegate.RimImageURL = a.PhotoURL;
                            }
                        }

                    }





                }

            }

            saveURLLocalDB(buttonImageName);




        }

        private void saveURLLocalDB(string buttonImageName)
        {
            switch (buttonImageName)
            {
                case "back":
                    if (AppDelegate.appDelegate.BackCarImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.BackCarImageURL);
                    break;
                case "front":
                    if (AppDelegate.appDelegate.FrontCarImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.FrontCarImageURL);
                    break;
                case "right":
                    if (AppDelegate.appDelegate.RightCarImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.RightCarImageURL);
                    break;
                case "left":
                    if (AppDelegate.appDelegate.LeftCarImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.LeftCarImageURL);
                    break;
                case "seats":
                    if (AppDelegate.appDelegate.BackSeatImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.BackSeatImageURL);
                    break;
                case "seat":
                    if (AppDelegate.appDelegate.SeatCarImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.SeatCarImageURL);
                    break;
                case "dashboard":
                    if (AppDelegate.appDelegate.DashBoardImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.DashBoardImageURL);
                    break;
                case "odometer":
                    if (AppDelegate.appDelegate.OdometerImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.OdometerImageURL);
                    break;
                case "VIN":
                    if (AppDelegate.appDelegate.VINImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.VINImageURL);
                    break;
                case "rim":
                    if (AppDelegate.appDelegate.RimImageURL != null)
                        savephotoURLtoDB(buttonImageName, AppDelegate.appDelegate.RimImageURL);
                    break;
                default:
                    break;
            }
        }

        private void savephotoURLtoDB(string buttonImageName, string URL)
        {
            NSData data = NSData.FromUrl(NSUrl.FromString(URL));
            if (data != null)
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string buttonName = buttonImageName + ".png";
                string localPath = Path.Combine(documentsPath, buttonName);
                NSError err = null;

                if (data.Save(localPath, false, out err))
                {
                    Console.WriteLine("saved as " + localPath);
                }
                else
                {
                    Console.WriteLine("NOT saved as" + localPath + " because" + err.LocalizedDescription);
                }
            }
        }


        public UIImage LoadImage(string filename)
        {
            string buttonName = filename + ".png";
            var documentsDirectory = Environment.GetFolderPath
                                             (Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);

            UIImage image = null;
            //var jpegData = NSData.FromFile(pngFilename);
            //if (jpegData != null)
            image = UIImage.FromFile(pngFilename);
            return image;
        }
    }
}

