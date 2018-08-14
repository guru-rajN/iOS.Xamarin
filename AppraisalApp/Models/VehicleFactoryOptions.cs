using System;
using System.Collections.Generic;

namespace AppraisalApp.Models
{
    public class VehicleFactoryOptions
    {
        public VehicleFactoryOptions()
        {
        }
        /// <summary>
        /// Contains VehicleID
        /// </summary>
        public long VehicleID { get; set; }
        /// <summary>
        /// Contains InventoryID
        /// </summary>
        public short InvtrID { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// Contains StoreID
        /// </summary>
        public short StoreID { get; set; }

        public List<FactoryOptions> FactoryOptionLst { get; set; }

        public List<AlternateFactoryOptions> AlternateFactoryOptionsLst { get; set; }

        public string OEMExtColor { get; set; }

        public string OEMIntColor { get; set; }

        public decimal? VehicleMSRP { get; set; }

    }

}
