using AppraisalApp.Models;
using ExtAppraisalApp.Utilities;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            PhotosModelList = new List<AddPhotoModel>();
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
            PhotosModelList.Add(new AddPhotoModel { Image = "add_photo.png", VehicleLabel = "Additional" });

            AddPhotoCollectionView.Source = new AddPhotosCollectionViewSource(this, PhotosModelList);

        }
        public void SelectPhotos(int index)
        {
            selected_index = index;

            if (selected_index != (PhotosModelList.Count - 1))
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

            if (PhotosModelList.Count <= 10 )
            {
                if ((PhotosModelList.Count - 1) == index)
                {
                    PhotosModelList.RemoveAt(index);
                    PhotosModelList.Add(new AddPhotoModel { Image = "camera_black.png", VehicleLabel = "Additional" });
                    PhotosModelList.Add(new AddPhotoModel { Image = "add_photo.png", VehicleLabel = "Additional" });
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
                    string buttonName = "AppraisalApp_Additional_" + selected_index + ".png";

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

                    // save photos to Azure cloud
                    imagePicker.DismissModalViewController(true);
                    Amazon.Aws amazonS3 = new Amazon.Aws();
                    Task.Run(() => amazonS3.UploadFile(pngFilename));
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
            Utility.ShowLoadingIndicator(this.View, "Uploading ...", true);
            await Task.Delay(2000);
            Utility.HideLoadingIndicator(this.View);

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