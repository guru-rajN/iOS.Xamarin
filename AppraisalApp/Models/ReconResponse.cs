using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class ReconResponse
    {
        public class Option

        {

            public string optionValue { get; set; }

            public int optionValueId { get; set; }

            public bool selected { get; set; }

        }



        public class Datum

        {

            public string VehicleConditionCategoryName { get; set; }

            public int vehicleConditionCategory { get; set; }

            public List<Option> options { get; set; }

        }



        public class RootObject

        {

            public List<Datum> data { get; set; }

            public string message { get; set; }

            public int statusCode { get; set; }

        }
    }
}
