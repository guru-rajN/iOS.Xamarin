using System;
namespace ExtAppraisalApp.Models
{
    public class AppraisalResponse : VehicleDetails
    {
        public short InvtryType
        {
            get;
            set;
        }

        public bool IsVehicleAlreadyExist
        {
            get;
            set;
        }
    }
}
