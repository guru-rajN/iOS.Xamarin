using System;
namespace ExtAppraisalApp.Models
{
    public class VinVehicleDetailsKBB
    {
        public VinVehicleDetail DecodeVinVehicleDetails { get; set; }

        public RootObject KBBVinVehicleDetails { get; set; }

        public bool IsKbbFailure { get; set; }

    }
}
