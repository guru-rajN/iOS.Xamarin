using CoreLocation;
using MapKit;

namespace ExtAppraisalApp
{
    public class ConferenceAnnotation : MKAnnotation
    {
        string title;
        string subtitle;
        string description;
        CLLocationCoordinate2D coord;

        public ConferenceAnnotation(string title, string description, string subtitle, CLLocationCoordinate2D coord)
        {
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.coord = coord;
        }

        public override string Title
        {
            get
            {
                return title;
            }
        }


        public override string Description
        {
            get
            {
                return description;
            }
        }
        public override string Subtitle
        {
            get
            {
                return subtitle;
            }
        }
        public override CLLocationCoordinate2D Coordinate
        {
            get
            {
                return coord;
            }
        }
    }
}

