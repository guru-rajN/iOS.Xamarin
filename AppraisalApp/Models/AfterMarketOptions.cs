using System;
using System.Collections.Generic;
using AppraisalApp.Models;

namespace ExtAppraisalApp.Models
{
    public class AfterMarketOptions
    {
        public List<AlternateFactoryOptions> sonicAfterMarketList { get; set; }

        public AfterMarketQuestions aftermarketQuestions { get; set; }
    }

    public class AfterMarketQuestions
    {
        public List<AfterMarketSection> data { get; set; }
        public ApiResponse meta { get; set; }
    }

    public class AfterMarketSection
    {
        public string Caption { get; set; }
        public List<ReconQuestionsKBB> questions { get; set; }
    }


    public class ReconOptionsKBB
    {
        public ReconOptionsKBB()
        {
            data = new List<ReconQuestionsKBB>();
            meta = new ApiResponse();
        }
        /// <summary>
        /// Contains list of Recon Questions
        /// </summary>

        public List<ReconQuestionsKBB> data { get; set; }

        /// <summary>
        /// Contains codes and links send from the api
        /// </summary>

        public ApiResponse meta { get; set; }
    }


    public class ReconQuestionsKBB
    {
        public ReconQuestionsKBB()
        {
            tags = new List<string>();
        }
        /// <summary>
        /// Contains question id
        /// </summary>

        public string questionId { get; set; }
        /// <summary>
        /// Contains question type
        /// </summary>

        public string questionType { get; set; }
        /// <summary>
        /// Contains question label
        /// </summary>

        public string label { get; set; }
        /// <summary>
        /// Contains max String length
        /// </summary>

        public int maxStringLength { get; set; }
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

        public List<string> enumChoices { get; set; }
        /// <summary>
        /// Contains comments
        /// </summary>

        public string comment { get; set; }
        /// <summary>
        /// Contains list of tags
        /// </summary>

        public List<string> tags { get; set; }
        /// <summary>
        /// Contains accepts comments
        /// </summary>

        public bool acceptsComment { get; set; }
        /// <summary>
        /// Contains answer
        /// </summary>
        public string value { get; set; }

        public string vehicleSectionName { get; set; }

        public VehicleSection vehicleSectionId { get; set; }


        public string vehicleConditionCategoryName { get; set; }

        public VehicleConditionCategory vehicleConditionCategory { get; set; }
        public string Caption { get; set; }
        public string SubCaption { get; set; }
    }

    public class ApiResponse
    {
        public ApiResponse()
        {
            codes = new List<int>();
            links = new List<string>();
        }
        /// <summary>
        /// Contains Codes
        /// </summary>

        public List<int> codes { get; set; }
        /// <summary>
        /// Contains link
        /// </summary>

        public List<string> links { get; set; }
    }
    public enum VehicleConditionCategory
    {
        None = 0,
        WearAndTear = 1,
        Mechanical = 2,
        SeriousAndAccident = 3
    }
    public enum VehicleSection
    {
        None = 0,
        Interior = 5,
        DriverSide = 1,
        Front = 2,
        PassengerSide = 3,
        Rear = 4,
        TopAndBottom = 7,
        Miscellaneous = 6,
        Mechanical = 8
    }
}
