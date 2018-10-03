using CoreLocation;
using Foundation;
using MapKit;
using System;
using System.Globalization;
using System.Threading;
using UIKit;

namespace ExtAppraisalApp
{
    public partial class MapsViewController : UIViewController
    {
        MapDelegate mapDelegate;
        CLLocationManager locationManager = new CLLocationManager();


        partial void MapClose_Activated(UIBarButtonItem sender)
        {
            this.DismissViewController(true, null);
        }
        public MapsViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestWhenInUseAuthorization();
            }



            // change map type, show user location and allow zooming and panning
            map.MapType = MKMapType.Standard;
            map.ShowsUserLocation = true;
            map.ZoomEnabled = true;
            map.ScrollEnabled = true;

            // set map center and region
            string storeName = AppDelegate.appDelegate.APNSAlertStore.ToString();
            string Address = AppDelegate.appDelegate.APNSAlertAddressa.ToString();

            double lon = ConvertToDouble(AppDelegate.appDelegate.APNSAlertLat.ToString());
            double lat = ConvertToDouble(AppDelegate.appDelegate.APNSAlertLon.ToString());


            CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D(lat, lon);
            MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 1000, 1000);
            map.CenterCoordinate = mapCenter;
            map.Region = mapRegion;

            // set the map delegate
            mapDelegate = new MapDelegate();
            map.Delegate = mapDelegate;

            // add a custom annotation at the map center
            map.AddAnnotations(new ConferenceAnnotation(storeName, "9025 Grant St Suite 150", Address, mapCenter));

            #region Not related to this sample
            //int typesWidth = 260, typesHeight = 30, distanceFromBottom = 60;
            //mapTypes = new UISegmentedControl(new CGRect((View.Bounds.Width - typesWidth) / 2, View.Bounds.Height - distanceFromBottom, typesWidth, typesHeight));
            // mapTypes.BackgroundColor = UIColor.White;
            // mapTypes.BackgroundColor = UIColor.White;
            mapTypes.Layer.CornerRadius = 5;
            mapTypes.ClipsToBounds = true;
            //mapTypes.InsertSegment("Road", 0, false);
            /// mapTypes.InsertSegment("Satellite", 1, false);
            //mapTypes.InsertSegment("Hybrid", 2, false);
            mapTypes.SelectedSegment = 0; // Road is the default
            mapTypes.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
            mapTypes.ValueChanged += (s, e) =>
            {
                switch (mapTypes.SelectedSegment)
                {
                    case 0:
                        map.MapType = MKMapType.Standard;
                        break;
                    case 1:
                        map.MapType = MKMapType.Satellite;
                        break;
                    case 2:
                        map.MapType = MKMapType.Hybrid;
                        break;
                }
            };
            View.AddSubview(mapTypes);
            #endregion
            //// add an overlay of the hotel
            //MKPolygon hotelOverlay = MKPolygon.FromCoordinates (
            //  new CLLocationCoordinate2D[] {
            //  new CLLocationCoordinate2D(30.2649977168594, -97.73863627705),
            //  new CLLocationCoordinate2D(30.2648461170005, -97.7381627734755),
            //  new CLLocationCoordinate2D(30.2648355402574, -97.7381750192576),
            //  new CLLocationCoordinate2D(30.2647791309417, -97.7379872505988),
            //  new CLLocationCoordinate2D(30.2654525150319, -97.7377341711021),
            //  new CLLocationCoordinate2D(30.2654807195004, -97.7377994819399),
            //  new CLLocationCoordinate2D(30.2655089239607, -97.7377994819399),
            //  new CLLocationCoordinate2D(30.2656428950368, -97.738346460207),
            //  new CLLocationCoordinate2D(30.2650364981811, -97.7385709662122),
            //  new CLLocationCoordinate2D(30.2650470749025, -97.7386199493406)
            //});

            //map.AddOverlay (hotelOverlay);

            UITapGestureRecognizer tap = new UITapGestureRecognizer(g =>
            {
                var pt = g.LocationInView(map);
                CLLocationCoordinate2D tapCoord = map.ConvertPoint(pt, map);

                Console.WriteLine("new CLLocationCoordinate2D({0}, {1}),", tapCoord.Latitude, tapCoord.Longitude);
            });

            map.AddGestureRecognizer(tap);
        }
        private double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", ".").Replace("-", "-"));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }
    }
}