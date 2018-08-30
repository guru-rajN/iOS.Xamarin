using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class ReconAnsKBB
    {
        public ReconAnsKBB()
        {
            tags = new List<string>();
        }
        /// <summary>
        /// Contains the answer.
        /// It may by boolean type or integer type
        /// </summary>

        public string value { get; set; }
        /// <summary>
        /// Contains the question id
        /// </summary>

        public string questionId { get; set; }
        /// <summary>
        /// Contains the tags
        /// </summary>

        public List<string> tags { get; set; }
        /// <summary>
        /// Contains the question type.
        /// ex:"YesNo" or "Number"
        /// </summary>

        public string questionType { get; set; }
        /// <summary>
        /// Contains the question
        /// </summary>

        public string label { get; set; }
        /// <summary>
        /// Contains the Comment
        /// </summary>
        public string comment { get; set; }
        public string vehicleSectionName { get; set; }

        public VehicleSection vehicleSectionId { get; set; }


        public string vehicleConditionCategoryName { get; set; }

        public VehicleConditionCategory vehicleConditionCategory { get; set; }

        /// <summary>
        /// Contains maximum value
        /// </summary>

        public int maximumValue { get; set; }
        /// <summary>
        /// Contains minimum value
        /// </summary>

        public int minimumValue { get; set; }
        /// <summary>
        /// Contains enum choices
        /// </summary>

        public int ReconAmt { get; set; }


    }
   
    public enum VehicleConditionCategorya
    {
        None = 0,
        WearAndTear = 1,
        Mechanical = 2,
        SeriousAndAccident = 3
    }


}
