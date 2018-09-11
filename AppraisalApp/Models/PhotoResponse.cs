using System;
namespace ExtAppraisalApp.Models
{
    public class PhotoResponse
    {
        public long VehicleID { get; set; }
        public short StoreID { get; set; }
        public short InvtrID { get; set; }
        public Byte[] Photo { get; set; }
        public string PhotoURL { get; set; }
        public string PhotoGuide { get; set; }

    }
}
