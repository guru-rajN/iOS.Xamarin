using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class PhotoGetResponse
    {
        public class Optionp

        {
            public int PhotoID { get; set; }
            public string ThumbnailPhotoURL { get; set; }
            public object Photo { get; set; }
            public string PhotoURL { get; set; }
            public string PhotoGuide { get; set; }

        }

        public class Datum
        {
            public List<Optionp> AppraisalPhotos { get; set; }
        }


    }
}
