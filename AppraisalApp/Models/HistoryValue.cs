using System;
using SQLite;

namespace ExtAppraisalApp.Models
{
    public class HistoryValue
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }
        public string HistoyQuestion
        {
            get;
            set;
        }
        public string HistoryValueid
        {
            get;
            set;
        }
        public string InsureCoast
        {
            get; set;
        }
    }
}
