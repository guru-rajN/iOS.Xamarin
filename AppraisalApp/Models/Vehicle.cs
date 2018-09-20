using System;
namespace ExtAppraisalApp.Models
{
    public class Vehicle : VehicleDetails
    {
        public Vehicle()
        {
        }
        /// <summary>

        /// Trim for the vehicle--Mandatory field

        /// </summary>

        public string Trim

        {

            get;

            set;

        }

        /// <summary>

        /// Chrome Trim for the vehicle--Mandatory field

        /// </summary>



        public string ChromeTrim

        {

            get;

            set;

        }

        /// <summary>

        /// Exterior color for the vehicle--Mandatory field

        /// </summary>



        public string ExtColor

        {

            get;

            set;

        }





        public string KBBColorId

        {

            get;

            set;

        }

        /// <summary>

        /// Interior color for the vehicle--Mandatory field

        /// </summary>



        public string IntColor

        {

            get;

            set;

        }

        /// <summary>

        /// Transmission type for the vehicle--Mandatory field

        /// </summary>



        public string Transmission

        {

            get;

            set;

        }

        /// <summary>

        /// Interior Type for the vehicle --Mandatory field

        /// </summary>



        public string IntrType

        {

            get;

            set;

        }

        /// <summary>

        /// Engine--Mandatory field

        /// </summary>



        public string Engine

        {

            get;

            set;

        }

        /// <summary>

        /// Fuel --Optional field

        /// </summary>



        public string Fuel

        {

            get;

            set;

        }

        /// <summary>

        /// Mileage value for the vehicle--Mandatory field

        /// </summary>



        public int? Mileage

        {

            get;

            set;

        }



        /// <summary>

        /// Amount

        /// </summary>



        public decimal? Payoff

        {

            get;

            set;

        }

        /// <summary>

        /// Manager Note

        /// </summary>



        public string ManagerNote

        {

            get;

            set;

        }

        /// <summary>

        /// Sight unseen value

        /// </summary>



        public bool? SightUnseen

        {

            get;

            set;

        }



        //

        //public bool? Is_Certifiable

        //{

        //    get;

        //    set;

        //}

        /// <summary>

        /// Type of DMV--Mandatory field

        /// </summary>



        public string DMVType

        {

            get;

            set;

        }

        /// <summary>

        /// Year

        /// </summary>



        public short? Year

        {

            get;

            set;

        }

        /// <summary>

        /// Make Id for the vehicle

        /// </summary>



        public string MakeID

        {

            get;

            set;

        }

        /// <summary>

        /// Model Id for the vehicle

        /// </summary>



        public string ModelID

        {

            get;

            set;

        }

        /// <summary>

        /// Make name of the vehicle--Mandatory field

        /// </summary>



        public string Make

        {

            get;

            set;

        }

        /// <summary>

        ///Model name of the vehicle--Mandatory field

        /// </summary>



        public string Model

        {

            get;

            set;

        }

        /// <summary>

        /// Trim Id for the vehicle

        /// </summary>



        public string TrimID

        {

            get;

            set;

        }

        /// <summary>

        /// Classifation of the  vehicle--Mandatory field

        /// </summary>



        public string Classification

        {

            get;

            set;

        }

        /// <summary>

        /// DMV Classifation of the  vehicle --Mandatory field

        /// </summary>



        public string DMVClassification

        {

            get;

            set;

        }



        /// <summary>

        ///Type of the  vehicle  --Mandatory field

        /// </summary>



        public string VehicleType

        {

            get;

            set;

        }

        /// <summary>

        /// Inventory type for the  vehicle

        /// </summary>



        public string InvtrType

        {

            get;

            set;

        }

        /// <summary>

        /// Model Code for the  vehicle

        /// </summary>



        public string ModelCode

        {

            get;

            set;

        }

        /// <summary>

        ///Dealership Option for the  vehicle

        /// </summary>



        public string DealerShipOptions

        {

            get;

            set;

        }

        /// <summary>

        ///Additional Dealership Option for the  vehicle

        /// </summary>



        public string AdditionalDealershipOptions

        {

            get;

            set;

        }

        /// <summary>

        /// Inventory vehicle demo is required or not value

        /// </summary>



        public bool? IsDemo

        {

            get;

            set;

        }

        /// <summary>

        /// Inventory vehicle Loaner or not value

        /// </summary>



        public bool? IsLoaner

        {

            get;

            set;

        }

        /// <summary>

        /// Inventory vehicle loaner date value

        /// </summary>



        public DateTime? LoanerDate

        {

            get;

            set;

        }

        /// <summary>

        /// Demo assigned to the inventory vehicle

        /// </summary>



        public string DemoAssignedTo

        {

            get;

            set;

        }

        /// <summary>

        /// TDate for the demo

        /// </summary>



        public DateTime? DemoDate

        {

            get;

            set;

        }

        /// <summary>

        /// Model Code Id fro the vehicle

        /// </summary>



        public string ModelCodeID

        {

            get;

            set;

        }

        /// <summary>

        /// Purchase Under

        /// </summary>



        public string PurchaseUnder

        {

            get;

            set;

        }

        /// <summary>

        /// Inventory vehicle acquisition type

        /// </summary>



        public string AcquisitionType

        {

            get;

            set;

        }

        /// <summary>

        /// Status Of Vehicle

        /// </summary>



        public string VehicleStatus

        {

            get;

            set;

        }

        /// <summary>

        /// Wizard Page

        /// </summary>



        public short WizardPage

        {

            get;

            set;

        }

        /// <summary>

        /// Market Ready or not

        /// </summary>



        public bool IsMarketReady

        {

            get;

            set;

        }

        /// <summary>

        /// StatusId for the vehicle

        /// </summary>



        public int StatusID

        {

            get;

            set;

        }

        /// <summary>

        /// Service Date for the vehicle

        /// </summary>



        public DateTime? ServiceDate

        {

            get;

            set;

        }

        /// <summary>

        /// Displacement

        /// </summary>



        public string displacement { get; set; }

        /// <summary>

        /// Vehicle drive train value under vehicle details

        /// </summary>



        public string DriveTrain { get; set; }

        /// <summary>

        /// Vehicle body style value under vehicle details

        /// </summary>



        public string BodyStyle { get; set; }

        /// <summary>

        /// Vehicle torque RPM value under vehicle details

        /// </summary>



        public long NetTorqueRPM { get; set; }

        /// <summary>

        /// Vehicle torque value under vehicle details

        /// </summary>



        public decimal NetTorqueValue { get; set; }

        /// <summary>

        /// Vehicle horsepower RPM value under vehicle details

        /// </summary>



        public decimal HorsepowerRPM { get; set; }

        /// <summary>

        /// Vehicle horsepower value under vehicle details

        /// </summary>



        public decimal HorsepowerValue { get; set; }

        /// <summary>

        /// Vehicle fuel efficiency value under vehicle details in city

        /// </summary>



        public decimal FuelEfficiencyCity { get; set; }

        /// <summary>

        /// Vehicle fuel efficiency value under vehicle details in Highway

        /// </summary>



        public decimal FuelEfficiencyHwy { get; set; }

        /// <summary>

        /// Vehicle laneId for  vehicle

        /// </summary>



        public short LaneId { get; set; }

        /// <summary>

        /// Source Name for the vehicle

        /// </summary>



        public string SourceName { get; set; }

        /// <summary>

        /// Parking

        /// </summary>



        public string Parking { get; set; }





        public virtual string Odometer { get; set; }
        public bool IsFactoryOptions { get; set; }
        public bool IsHistory { get; set; }
        public bool IsPhotos { get; set; }
    }
}
