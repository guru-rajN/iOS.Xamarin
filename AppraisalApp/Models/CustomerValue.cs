using System;
using SQLite;

namespace AppraisalApp.Models
{
    public class CustomerValue
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get;
            set;
        }
        public bool CustomerLogin
        {
            get;
            set;
        }
        public string CustomerLastName
        {
            get;
            set;
        }
        public string CustomerEmail
        {
            get; set;
        }
        public string CustomerPhone
        {
            get; set;
        }
    }
}
