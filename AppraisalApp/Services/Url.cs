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

        public const string BASE_URL = SERVER_URL + "ExternalAppraisal/AppraisalApp/";

        public const string VALIDATE_ZIPCODE_URL = "ValidateZipDealer/";

        public const string DECODEVIN_URL = "DecodevinKBB/";

        public const string CREATEAPPRAISAL_URL = "CreateAppraisalKBB/";
    }
}
