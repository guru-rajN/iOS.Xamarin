using AppraisalApp.Models;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class PhotosCell : UICollectionViewCell
    {
        public PhotosCell(IntPtr handle) : base(handle)
        {
        }
        public static string CellId = new NSString("PhotosCell");

        public void UpdateRow(List<AddPhotoModel> data, NSIndexPath indexPath)
        {
            if (data[indexPath.Row].Image.Equals("camera_black.png") || data[indexPath.Row].Image.Equals("add_photo.png"))
            {
                AddPhotoImg.ContentMode = UIViewContentMode.Center;
            }
            else
            {
                AddPhotoImg.ContentMode = UIViewContentMode.ScaleAspectFill;
            }

            AddPhotoImg.Image = UIImage.FromFile(data[indexPath.Row].Image);
            AddPhotoLabel.Text = data[indexPath.Row].VehicleLabel;
        }
    }
}