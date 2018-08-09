using System;
namespace ExtAppraisalApp.Models
{
    public class VehicleParameters
    {
       
        public long VehicleID { get; set; }

        public short StoreID { get; set; }
        public short InvtrID { get; set; }

        public bool IsKbbVehicle { get; set; }
      
        public int KBBYearId { get; set; }

        public int KBBMakeId { get; set; }
        public int KBBModelId { get; set; }

        public int KBBTrimId { get; set; }

        public int KBBEngineId { get; set; }

        public int KBBTransmissionId { get; set; }
       
        public int KBBDrivetrainId { get; set; }
    }
}
