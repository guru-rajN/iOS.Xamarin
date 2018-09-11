using System;
namespace ExtAppraisalApp.Models
{
    public class OfferResponse
    {
        public long vehicleId { get; set; }

        public short storeId { get; set; }
        public short invtrId { get; set; }
        public string UserName { get; set; }
        public string ProspectId { get; set; }
        public Int32 TrimId { get; set; }
    }
}
