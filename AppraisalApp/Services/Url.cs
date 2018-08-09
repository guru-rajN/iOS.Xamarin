using System;
namespace ExtAppraisalApp.Services
{
    public class Url
    {
        public Url(){}

        public const string HTTP = "http://";
        public const string HTTPS = "https://";

        public const string PRODUCTION_URL = HTTPS + "";
        public const string STAGING_URL = HTTPS + "tt-stg-simsapp.sonicautomotive.com/";

        /**
         * TO BE changed as per requirement
         */
        public const string SERVER_URL = STAGING_URL;

        public const string BASE_URL = SERVER_URL + "OneStop/Appraisal/";

        public const string VALIDATE_ZIPCODE_URL = "";

        public const string DECODEVIN_URL = "DecodevinKBB/{vin}/{mileage}/{storeId}/{inventoryType}";
    }
}
