using System;
namespace AppraisalApp.Models
{
    public partial class AppraisalLogEntity
    {
        #region Primitive Properties
 
        public virtual bool SightUnseen
        {
            get;
            set;
        }
 
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
 
        public virtual string Status
        {
            get;
            set;
        }
 
        public virtual Nullable<int> Photos
        {
            get;
            set;
        }
 
        public virtual byte? CReportIconID
        {
            get;
            set;
        }
 
        public virtual string CReportURL
        {
            get;
            set;
        }
 
        public virtual byte? AReportIconID
        {
            get;
            set;
        }
 
        public virtual string AReportURL
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
 
        public virtual Nullable<Boolean> IsKbbVehicle
        {
            get;
            set;
        }
        public virtual Nullable<Boolean> IsKBBFailure { get; set; }
        public virtual short Curr_Store_ID
        {
            get;
            set;
        }
 
        public virtual short Invtr_ID
        {
            get;
            set;
        }
 
        public virtual string TimerColor
        {
            get;
            set;
        }
 
        public virtual byte? WIZARD_PAGE
        {
            get;
            set;
        }
 
        /* Added because of Starts Manual Existence*/
        public bool IsExists { get; set; }
 
        public string StoreName { get; set; }
 
        public string IsSaleHistory { get; set; }
 
        public virtual short VehicleSrc
        {
            get;
            set;
        }
        public virtual short Status_ID
        {
            get;
            set;
        }
        public string HasFactoryOptions { get; set; }
 
        public virtual string Location { get; set; }
 
        //exclude vehicle from aprrasing process if they hold the following statues : Recon,Hold for Appointment, Hold for Deal
        public bool Exclude { get; set; }
 
        public virtual string ReconType
        {
            get;
            set;
        }
 
        public virtual bool Is_Recon_Exists
        {
            get;
            set;
        }
        public Nullable<short> SACStatus
        {
            get;
            set;
        }
        public virtual bool IsOtherAppraisal
        {
            get;
            set;
        }
        public virtual string AppraisalType
        {
            get;
            set;
        }
        public string Kiosk_Req { get; set; }
 
        public virtual bool IsKbbFailure
        {
            get;
            set;
        }
        #endregion
    }
 

}
