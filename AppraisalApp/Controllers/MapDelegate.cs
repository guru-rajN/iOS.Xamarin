using System;
using MapKit;
using UIKit;
using CoreGraphics;

namespace ExtAppraisalApp
{
    class MapDelegate : MKMapViewDelegate
    {
        static string annotationId = "ConferenceAnnotation";
        UIImageView venueView;
        UIImage venueImage;

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;

            if (annotation is ConferenceAnnotation)
            {

                // show conference annotation
                annotationView = mapView.DequeueReusableAnnotation(annotationId);

                if (annotationView == null)
                    annotationView = new MKAnnotationView(annotation, annotationId);

                annotationView.Image = UIImage.FromBundle("carc.png");
                annotationView.CanShowCallout = true;
            }

            return annotationView;
        }

        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            // show an image view when the conference annotation view is selected
            if (view.Annotation is ConferenceAnnotation)
            {

                venueView = new UIImageView();
                venueView.ContentMode = UIViewContentMode.ScaleAspectFit;
                venueImage = UIImage.FromBundle("carcash.png");
                //venueView.BackgroundColor = UIColor.LightGray;
                venueView.Image = venueImage;
                view.AddSubview(venueView);

                UIView.Animate(0.4, () => {
                    venueView.Frame = new CGRect(-50, -25, 120, 120);
                });
            }
        }

        public override void DidDeselectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            // remove the image view when the conference annotation is deselected
            if (view.Annotation is ConferenceAnnotation)
            {

                venueView.RemoveFromSuperview();
                venueView.Dispose();
                venueView = null;
            }
        }

        public override MKOverlayView GetViewForOverlay(MKMapView mapView, IMKOverlay overlay)
        {
            // return a view for the polygon
            MKPolygon polygon = overlay as MKPolygon;
            MKPolygonView polygonView = new MKPolygonView(polygon);
            polygonView.FillColor = UIColor.Blue;
            polygonView.StrokeColor = UIColor.Red;
            return polygonView;
        }
    }
}

