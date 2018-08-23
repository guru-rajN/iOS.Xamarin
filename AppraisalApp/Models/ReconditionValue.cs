using System;
using SQLite;

namespace ExtAppraisalApp
{
    public class ReconditionValue
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }
        public string SegmentIndex
        {
            get;
            set;
        }
        public string RowOption
        {
            get;
            set;
        }
    }
}

