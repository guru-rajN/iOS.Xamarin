using System;

namespace ExtAppraisalApp.Models
{
    public class ReconAns
    {
        public string VehicleConditionCategoryName { get; set; }

        public Int16 VehicleConditionCategory { get; set; }

        public string optionValue { get; set; }

        public Int16 optionValueId { get; set; }


    }

    public enum optionValue
    {
        Flawless = 0,
        AboveAverage = 1,
        Average = 2,
        LessThanAverage = 3,
        Rough = 4,
        TowIn = 5
    }
}