using System;
using System.Collections.Generic;

namespace AppraisalApp.Models
{
    public class VehicleFactoryOptionsKBB : VehicleBase
    {

        public long VehicleId { get; set; }
        /// <summary>
        /// Contains InventoryID
        /// </summary>

        public short InvtrId { get; set; }

        /// <summary>
        /// Contains StoreID
        /// </summary>

        public short StoreId { get; set; }

        public string UserName { get; set; }


        public List<FactoryOptionsKBB> data { get; set; }
    }

    public class VehicleBase
    {
        /// <summary>
        /// Contains the details of VehicleParameters
        /// </summary>
        public class VehicleParameters
        {
            /// <summary>
            /// Vehicle ID
            /// </summary>
            public long VehicleID { get; set; }
            /// <summary>
            /// Store Id
            /// </summary>
            public short StoreID { get; set; }
            /// <summary>
            /// Inventory Id
            /// </summary>
            public short InvtrID { get; set; }

        }
    }
}
