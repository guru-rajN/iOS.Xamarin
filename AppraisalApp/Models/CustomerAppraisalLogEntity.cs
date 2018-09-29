using System;
namespace AppraisalApp.Models
{
    public class CustomerAppraisalLogEntity
    {
        public virtual Nullable<short> Year

        {

            get;

            set;

        }



        public virtual string Make

        {

            get;

            set;

        }



        public virtual string Model

        {

            get;

            set;

        }



        public virtual string SeriesTrim

        {

            get;

            set;

        }



        public virtual string ExteriorColor

        {

            get;

            set;

        }



        public virtual Nullable<int> Mileage

        {

            get;

            set;

        }



        public virtual DateTime? CreatedDate

        {

            get;

            set;

        }



        public virtual string SalesPerson

        {

            get;

            set;

        }



        public virtual string SACAppraisalValue

        {

            get;

            set;

        }



        public virtual Nullable<decimal> AppraisalValue

        {

            get;

            set;

        }



        public virtual Nullable<DateTime> AppraisedDate

        {

            get;

            set;

        }



        public virtual string Appraisedby

        {

            get;

            set;

        }



        public virtual string VIN

        {

            get;

            set;

        }



        public virtual long Vehicle_ID

        {

            get;

            set;

        }



        public virtual short Store_ID

        {

            get;

            set;

        }



        public virtual short Invtr_ID

        {

            get;

            set;

        }



        public virtual byte? Wizard_Page

        {

            get;

            set;

        }



        public virtual byte VehicleSrc

        {

            get;

            set;

        }

        public virtual short Status_ID

        {

            get;

            set;

        }



        public Nullable<short> SACStatus

        {

            get;

            set;

        }





        public virtual short Curr_Store_ID

        {

            get;

            set;

        }



        public virtual string Status

        {

            get;

            set;

        }
    }
}
