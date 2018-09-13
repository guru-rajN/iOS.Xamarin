using AppraisalApp.Models;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class AdditionalPhotographs : UIViewController
    {
        public AdditionalPhotographs (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            List<AddPhotoModel> PhotosModelList = new List<AddPhotoModel>();

            var data = new List<AddPhotoModel>
            {
                new AddPhotoModel{
                    Image = "pfront.png",
                    VehicleLabel = "Additional"
                },
                new AddPhotoModel{
                    Image = "pfront.png",
                    VehicleLabel = "Additional"
                },
                new AddPhotoModel{
                    Image = "pfront.png",
                    VehicleLabel = "Additional"
                },
                new AddPhotoModel{
                    Image = "pfront.png",
                    VehicleLabel = "Additional"
                }
            };

            AddPhotoCollectionView.Source = new AddPhotosCollectionViewSource(this, data);
            //AddPhotoCollectionView.ReloadData();
        }


    }

    internal class AddPhotosCollectionViewSource : UICollectionViewSource
    {
        private AdditionalPhotographs additionalPhotosView;
        private List<AddPhotoModel> data;
        public NSIndexPath[] SelectedItems { get { return _selectedItems.ToArray(); } }
        readonly List<NSIndexPath> _selectedItems = new List<NSIndexPath>();

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Debug.WriteLine("Selected index :: " + indexPath.Row);
            _selectedItems.Add(indexPath);
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Debug.WriteLine("Deselected index :: " + indexPath.Row);
            _selectedItems.Remove(indexPath);
        }

        public AddPhotosCollectionViewSource(AdditionalPhotographs additionalPhotosView, List<AddPhotoModel> data)
        {
            this.additionalPhotosView = additionalPhotosView;
            this.data = data;
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