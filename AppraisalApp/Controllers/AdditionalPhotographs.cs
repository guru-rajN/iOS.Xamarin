using AppraisalApp.Models;
using ExtAppraisalApp.Models;
using ExtAppraisalApp.Services;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class AdditionalPhotographs : UIViewController
    {
        public AdditionalPhotographs(IntPtr handle) : base(handle)
        {
        }
        public int selected_index = 0;

        List<AddPhotoModel> PhotosModelList;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            NSNotificationCenter.DefaultCenter.AddObserver((Foundation.NSString)"UpdateAdditionalPhotos", UpdateView);

            //setPersistedImage();

        }

        public override void ViewDidDisappear(bool animated)
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver((Foundation.NSString)"UpdateAdditionalPhotos");
            base.ViewDidDisappear(animated);
        }

        private void UpdateView(NSNotification obj)
        {
            PhotosModelList = new List<AddPhotoModel>();
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "add_photo.png", VehicleLabel = "Additional" });

            AddPhotoCollectionView.Source = new AddPhotosCollectionViewSource(this, PhotosModelList);

            var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
            Utility.ShowLoadingIndicator(splitViewController.View, "Retrieving...", true);

            setPersistedImage();

        }


        public void setPersistedImage()
        {

            int index = 0;
            loadImagea(index);
            index = 1;
            loadImagea(index);
            index = 2;
            loadImagea(index);

            InvokeOnMainThread(() =>
            {
                var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
                Utility.HideLoadingIndicator(splitViewController.View);
            });

        }


        private void loadImagea(int index)
        {
            string buttonName = "additional-photo-" + index + ".png";
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            UIImage image = null;
            image = UIImage.FromFile(pngFilename);
            if (image != null)
            {
                PhotosModelList[index].Image = pngFilename;
            }
            else
            {
                if (AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos != null)
                {
                    foreach (var a in AppDelegate.appDelegate.getphotoResponses.AppraisalPhotos)
                    {
                        if (a.PhotoGuide == "additional-photo-0.png")
                        {
                            AppDelegate.appDelegate.AdditionalPhoto0 = a.PhotoURL;
                            savephotoURLtoDB("additional-photo-0", AppDelegate.appDelegate.AdditionalPhoto0);
                            loadOnlineImage(0);
                        }
                        if (a.PhotoGuide == "additional-photo-1.png")
                        {
                            AppDelegate.appDelegate.AdditionalPhoto1 = a.PhotoURL;

                            savephotoURLtoDB("additional-photo-1", AppDelegate.appDelegate.AdditionalPhoto1);
                            loadOnlineImage(1);
                        }
                        if (a.PhotoGuide == "additional-photo-2.png")
                        {
                            AppDelegate.appDelegate.AdditionalPhoto2 = a.PhotoURL;
                            savephotoURLtoDB("additional-photo-2", AppDelegate.appDelegate.AdditionalPhoto2);
                            loadOnlineImage(2);
                        }


                    }
                }
            }
        }

        private void loadOnlineImage(int index)
        {
            string buttonName = "additional-photo-" + index + ".png";
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);
            UIImage image = null;
            image = UIImage.FromFile(pngFilename);
            if (image != null)
            {
                PhotosModelList[index].Image = pngFilename;
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
        public PhotoGetResponse.Datum GetPhotos(long vehicleID, short storeId, short invtrId)
        {
            PhotoGetResponse.Datum getphotoResponses = new PhotoGetResponse.Datum();
            getphotoResponses = ServiceFactory.getWebServiceHandle().GetPhoto(vehicleID, storeId, invtrId);

            return getphotoResponses;

        }

        private UIImage LoadImage(string selectedINdex)
        {
            string buttonName = "additional-photo-" + selectedINdex + ".png";
            var documentsDirectory = Environment.GetFolderPath
                                             (Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, buttonName);

            UIImage image = null;
            //var jpegData = NSData.FromFile(pngFilename);
            //if (jpegData != null)
            image = UIImage.FromFile(pngFilename);
            return image;
        }

        public void SelectPhotos(int index)
        {
            selected_index = index;

            if (selected_index != (PhotosModelList.Count - 1) || selected_index == 9)
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

            if (PhotosModelList.Count <= 10)
            {
                if ((PhotosModelList.Count - 1) == index)
                {
                    PhotosModelList.RemoveAt(index);
                    PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });

                    if (PhotosModelList.Count < 10)
                    {
                        PhotosModelList.Add(new AddPhotoModel { Image = "add_photo.png", VehicleLabel = "Additional" });
                    }
                    AddPhotoCollectionView.ReloadData();
                }
            }



        }


        UIImagePickerController imagePicker;

        void GalleryButtona_TouchUpInside()
        {
            //viewPopup.Hidden = true;
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

        public void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {

            var originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;

            var meta = e.Info[UIImagePickerController.MediaMetadata] as NSDictionary;

            try
            {
                if (originalImage != null)
                {

                    var documentsDirectory = Environment.GetFolderPath
                                              (Environment.SpecialFolder.Personal);
                    string buttonName = "additional-photo-" + selected_index + ".png";
                    AppDelegate.appDelegate.photoButtonClicked = buttonName;
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


                    SetAdditionalImages(pngFilename);
                    var imagea = UIImage.LoadFromData(imgData);
                    var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
                    string Orientaion = "Landscape";
                    if (currentOrientation == UIInterfaceOrientation.Portrait)
                    {
                        Orientaion = "Portrait";
                    }
                    else
                    {
                        Orientaion = "Landscape";
                    }
                    NSData imageData = originalImage.AsJPEG(0.0f);

                    Byte[] myByteArray = new Byte[imageData.Length];
                    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));

                    // save photos to Azure cloud
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
        public void SetAdditionalImages(string fileName)
        {
            PhotosModelList[selected_index].Image = fileName;
            AddPhotoCollectionView.ReloadData();
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            imagePicker.DismissModalViewController(true);
        }

        public async void ActivityLoader()
        {
            var splitViewController = (UISplitViewController)AppDelegate.appDelegate.Window.RootViewController;
            Utility.ShowLoadingIndicator(splitViewController.View, "Uploading ...", true);
            await Task.Delay(2000);
            Utility.HideLoadingIndicator(splitViewController.View);

        }


    }

    internal class AddPhotosCollectionViewSource : UICollectionViewSource
    {
        private AdditionalPhotographs additionalPhotosView;
        private List<AddPhotoModel> data;

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Debug.WriteLine("Selected index :: " + indexPath.Row);
            additionalPhotosView.SelectPhotos(indexPath.Row);
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Debug.WriteLine("Deselected index :: " + indexPath.Row);
        }

        public AddPhotosCollectionViewSource(AdditionalPhotographs additionalPhotosView, List<AddPhotoModel> data)
        {
            this.additionalPhotosView = additionalPhotosView;
            this.data = data;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            //var cell = (PhotosCell)collectionView.CellForItem(indexPath);
            //cell.BackgroundColor = UIColor.Yellow;
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {

            //var renderer = Platform.GetRenderer(page);

            //var cell = (PhotosCell)collectionView.CellForItem(indexPath);
            //var UIVCKitchenViewController = GetViewController(MainStoryboard, "UIVCKitchenView");
            //UIVCKitchenViewController.PerformSegue("seqShowKitchenDetails", this);

            //cell.BackgroundColor = UIColor.Orange;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return data.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (PhotosCell)collectionView.DequeueReusableCell(PhotosCell.CellId, indexPath);
            cell.Layer.BorderWidth = 2.0f;
            cell.Layer.BorderColor = UIColor.Black.CGColor;
            cell.Layer.CornerRadius = 10.0f;
            cell.UpdateRow(data, indexPath);

            return cell;
        }


    }
}
