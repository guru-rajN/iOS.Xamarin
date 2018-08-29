using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class HistoryRequest
    {
        public HistoryRequest()
        {
            Answers = new List<ReconAnsKBB>();
        }

        public long VehicleID
        {
            get;
            set;
        }

        public short StoreID
        {
            get;
            set;
        }

        public short InvtrID
        {
            get;
            set;
        }
        public string UserName { get; set; }
        public List<ReconAnsKBB> Answers { get; set; }
    }
}
