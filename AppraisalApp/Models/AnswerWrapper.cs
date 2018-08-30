using System;
using System.Collections.Generic;
using ExtAppraisalApp.Models;

namespace AppraisalApp.Models
{
    public class AnswerWrapper
    {
        public AnswerWrapper()
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
