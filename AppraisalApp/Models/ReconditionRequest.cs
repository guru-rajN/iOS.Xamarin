using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class ReconditionKBB
    {
        public ReconditionKBB()
        {
            Answers = new List<ReconAns>();
        }
        public long VehicleID { get; set; }
        public short StoreID { get; set; }
        public short InvtrID { get; set; }
        public string UserName { get; set; }
        public List<ReconAns> Answers { get; set; }
    }

}