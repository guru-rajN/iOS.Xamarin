using System;
using SQLite;

namespace AppraisalApp.Models
{
    public class DealerValue
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }
        public bool DealerLogin
        {
            get;
            set;
        }
        public short StoreId
        {
            get;
            set;
        }

    }
}
