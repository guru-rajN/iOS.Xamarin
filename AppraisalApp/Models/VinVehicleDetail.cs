using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class VinVehicleDetail
    {
        /// <summary>
        /// Object initialization for the properties which are not able to convert from XML
        /// </summary>
        public VinVehicleDetail()
        {
            this.Years = new List<IDValues>();
            this.Make = new List<IDValues>();
            this.Model = new List<IDValues>();
            this.BodyStyle = new List<IDValues>();
            this.Series = new List<IDValues>();
            this.EngineDetails = new List<EngineDetails>();
        }
        /// <summary>
        /// Vin for the vehicle
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        ///Contains Year
        /// </summary>
        public uint Year { get; set; }

        /// <summary>
        /// Contains true or false value to find it is a newvehicle or not 
        /// </summary>
        public bool NewVehicle { get; set; }
        /// <summary>
        /// Uvc will be same for the similar make,model,trim,year
        /// </summary>
        public string Uvc { get; set; }
        /// <summary>
        /// Cylinders for a vehicle
        /// </summary>
        public uint Cylinders { get; set; }
        /// <summary>
        /// No of Doors
        /// </summary>
        public uint NoOfDoors { get; set; }
        /// <summary>
        ///  Contains true or false value to know Clarification is needed or not 
        /// </summary>
        public bool ClarificationNeeded { get; set; }
        /// <summary>
        ///  Contains true or false value to find  decode status
        /// </summary>
        public bool IsDecodeSuccess { get; set; }
        /// <summary>
        /// List of years
        /// </summary>
        public List<IDValues> Years { get; set; }
        /// <summary>
        /// make details of vehicle
        /// </summary>
        public List<IDValues> Make { get; set; }
        /// <summary>
        /// Engine details of vehicle
        /// </summary>
        public List<EngineDetails> EngineDetails { get; set; }
        /// <summary>
        /// Engine 
        /// </summary>
        public List<IDValues> Engine { get; set; }
        /// <summary>
        /// Model Details of vehicle
        /// </summary>
        public List<IDValues> Model { get; set; }
        /// <summary>
        ///Body Style Details of vehicle
        /// </summary>
        public List<IDValues> BodyStyle { get; set; }
        /// <summary>
        /// Series Details of vehicle
        /// </summary>
        public List<IDValues> Series { get; set; }
        /// <summary>
        /// Chrome Trim Details of vehicle
        /// </summary>
        public List<IDValues> ChromeTrim { get; set; }
        /// <summary>
        /// Transmission Details of vehicle
        /// </summary>
        public List<IDValues> Transmission { get; set; }
        /// <summary>
        /// DriveTrain Details of vehicle
        /// </summary>
        public List<IDValues> DriveTrain { get; set; }
        /// <summary>
        /// class Details of vehicle
        /// </summary>
        public List<IDValues> ClassOfVehicle { get; set; }
        /// <summary>
        ///Decode Status details
        /// </summary>
        public List<IDValues> DecodeStatus { get; set; }
        /// <summary>
        ///  Details of DMV class
        /// </summary>
        public List<IDValues> DMVClass { get; set; }
        /// <summary>
        /// Exterior color Details of vehicle
        /// </summary>
        public List<IDValues> ExteriorColor { get; set; }
        /// <summary>
        /// Interior color Details of vehicle
        /// </summary>
        public List<IDValues> InteriorColor { get; set; }
        /// <summary>
        /// Interior type Details of vehicle
        /// </summary>
        public List<IDValues> InteriorType { get; set; }
        /// <summary>
        ///Fuel Details of vehicle
        /// </summary>
        public List<IDValues> Fuel { get; set; }
        /// <summary>
        ///  Details of vehicle type
        /// </summary>
        public List<IDValues> VehicleType { get; set; }
        /// <summary>
        /// Details of DMV type
        /// </summary>
        public List<IDValues> DMVType { get; set; }
        /// <summary>
        /// option details of vehicle
        /// </summary>
        public List<OptionValues> Options { get; set; }
        /// <summary>
        /// Details of Model Code
        /// </summary>
        public List<IDValues> ModelCode { get; set; }
        /// <summary>
        ///  Details of  Dealer option
        /// </summary>
        public List<IDValues> DealerOption { get; set; }
        /// <summary>
        ///  Details of Source type
        /// </summary>
        public List<IDValues> SourceType { get; set; }
        /// <summary>
        ///  Details of Factory options
        /// </summary>
        public List<FactoryOptions> FactoryOptions { get; set; }
        /// <summary>
        ///  Details of OEM Exterior color
        /// </summary>
        public List<IDValues> OEMExteriorColor { get; set; }
        /// <summary>
        ///  Details of OEM Interior color
        /// </summary>
        public List<IDValues> OEMInteriorColor { get; set; }
        /// <summary>
        /// MSRP value
        /// </summary>
        public decimal VehicleMSRP { get; set; }
        /// <summary>
        ///  Contains true or false value to know FactoryOption is required or not 
        /// </summary>
        public bool IsFactoryOptionRequired { get; set; }
        /// <summary>
        /// Added for Standard Equipment
        /// </summary>
        public List<StandardEquipment> StandardEquipment { get; set; }

        public KBBColorDetails KbbColorDetails { get; set; }

        //Added for KBB
        public int KBBMakeId { get; set; }

        public int KBBModelId { get; set; }

        public int KBBTrimId { get; set; }

        public List<IDValues> OdometerOptions { get; set; }


    }

    public class KBBColorDetails
    {
        public List<Datum> data { get; set; }

    }
    public class Datum
    {
        public int colorId { get; set; }
        public string displayName { get; set; }
    }

    /// <summary>
    ///Engine Details
    /// </summary>
    public class EngineDetails
    {
        /// <summary>
        /// Displacement
        /// </summary>
        public string Displacement { get; set; }
        /// <summary>
        /// NetTorque_RPM 
        /// </summary>
        public long NetTorqueRPM { get; set; }
        /// <summary>
        /// NetTorque_Value
        /// </summary>
        public decimal NetTorqueValue { get; set; }
        /// <summary>
        /// Horsepower_RPM
        /// </summary>
        public decimal HorsepowerRPM { get; set; }
        /// <summary>
        /// Horsepower_Value
        /// </summary>
        public decimal HorsepowerValue { get; set; }
        /// <summary>
        /// FuelEfficiencyCity 
        /// </summary>
        public decimal FuelEfficiencyCity { get; set; }
        /// <summary>
        /// FuelEfficiencyHwy
        /// </summary>
        public decimal FuelEfficiencyHwy { get; set; }
    }
    /// <summary>
    /// ID Values
    /// </summary>
    public class IDValues
    {
        /// <summary>
        /// ID 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        ///Selected or not
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
    }
    /// <summary>
    /// Option Values
    /// </summary>
    public class OptionValues : IDValues
    {
        /// <summary>
        ///Cost
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// trade in cost
        /// </summary>
        public decimal TradeInCost { get; set; }
        /// <summary>
        /// standard
        /// </summary>
        public string Std { get; set; }
        /// <summary>
        /// oa
        /// </summary>
        public string Oa { get; set; }
        /// <summary>
        /// ID Values
        /// </summary>
        public decimal TradeInXClean { get; set; }
        /// <summary>
        ///TradeInAbove
        /// </summary>
        public decimal TradeInAbove { get; set; }
        /// <summary>
        ///TradeInAverage 
        /// </summary>
        public decimal TradeInAverage { get; set; }
        /// <summary>
        /// TradeInBelow
        /// </summary>
        public decimal TradeInBelow { get; set; }
        /// <summary>
        ///RetailAbove
        /// </summary>
        public decimal RetailAbove { get; set; }
        /// <summary>
        ///RetailAverage
        /// </summary>
        public decimal RetailAverage { get; set; }
        /// <summary>
        /// RetailBelow
        /// </summary>
        public decimal RetailBelow { get; set; }
        /// <summary>
        /// LoanAbove
        /// </summary>
        public decimal LoanAbove { get; set; }
        /// <summary>
        ///  LoanAverage 
        /// </summary>
        public decimal LoanAverage { get; set; }
        /// <summary>
        /// LoanBelow
        /// </summary>
        public decimal LoanBelow { get; set; }
        /// <summary>
        /// WSaleAbove 
        /// </summary>
        public decimal WSaleAbove { get; set; }
        /// <summary>
        /// WSaleAverage
        /// </summary>
        public decimal WSaleAverage { get; set; }
        /// <summary>
        ///WSaleBelow
        /// </summary>
        public decimal WSaleBelow { get; set; }
    }

    /// <summary>
    /// Details of standard equipment
    /// </summary>
    public partial class StandardEquipment
    {
        /// <summary>
        /// Details of mechanical
        /// </summary>
        public List<Mechanical> Mechanical { get; set; }
        /// <summary>
        /// Details of Exterior
        /// </summary>
        public List<Exterior> Exterior { get; set; }
        /// <summary>
        /// Details of Entertainment 
        /// </summary>
        public List<Entertainment> Entertainment { get; set; }
        /// <summary>
        /// Details of Interior
        /// </summary>
        public List<Interior> Interior { get; set; }
        /// <summary>
        /// Details of Safety
        /// </summary>
        public List<Safety> Safety { get; set; }
    }

    /// <summary>
    /// Details of the equipments
    /// </summary>
    public class EquipmentDetails
    {
        /// <summary>
        /// HeaderName
        /// </summary>
        public string HeaderName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// TrimID
        /// </summary>
        public int[] TrimID { get; set; }
    }

    /// <summary>
    /// Mechanical
    /// </summary>

    public class Mechanical : EquipmentDetails
    {

    }
    /// <summary>
    /// Exterior
    /// </summary>
    public class Exterior : EquipmentDetails
    {

    }
    /// <summary>
    ///Entertainment
    /// </summary>
    public class Entertainment : EquipmentDetails
    {

    }
    /// <summary>
    /// Interior
    /// </summary>
    public class Interior : EquipmentDetails
    {

    }
    /// <summary>
    /// Safety
    /// </summary>
    public class Safety : EquipmentDetails
    {

    }


    /// <summary>
    /// contains the details of factory options for a particular vehicle
    /// </summary>
    public class FactoryOptions
    {
        /// <summary>
        /// contains the option description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Contains a value which determines whether or not the option of a particular category is mutually exclusive with the other option of the same category
        /// If  some of the factory options UTF=0, then these factory options are not mutually exclusive to each other and user can select them without any restriction.
        /// Some of the factory options UTF  has value ,then these are mutually exclusive.
        /// </summary>
        public string Utf { get; set; }

        /// <summary>
        /// contains the option kind Id to categorize each factory option
        /// </summary>
        public string OptionKindId { get; set; }

        /// <summary>
        /// Contains the price for each factory options
        /// </summary>
        public decimal? Price { get; set; }

        ///// <summary>
        ///// installed
        ///// </summary>
        //    public string InstalledCause { get; set; }


        /// <summary>
        /// Contains a value which determines what option should be displayed based on the trim selected by the user
        /// </summary>
        public int[] StyleId { get; set; }

        /// <summary>
        /// Contains a code for each factory option
        /// </summary>
        public string OemCode { get; set; }

    }

}
