using System;
namespace ExtAppraisalApp.Services
{
    public class Url
    {
        public Url() { }

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

        public const string GET_VEHICLE_DETAILS_URL = "GetVehicleDetailsKBB/";
        public const string GET_Photo = "GetPhotos/";
        public const string GET_KBB_COLORS_URL = "GetKBBColorDetails/";

        public const string GET_FACTORYOPTIONSKBB_URL = "GetFactoryOptionsKBB/";
        public const string GET_HISTORY_URL = "GetHistoryKBB/";
        public const string GET_Recon_URL = "GetReconDetailsKBB/";
        public const string FetchAppraisalLog_URL = "FetchAppraisalLog/";


        public const string GENERATE_PROSPECT_URL = "GenerateProspect/";

        public const string SAVE_VEHICLE_DETAILS_URL = "SaveVehicleDetailsKBB/";

        public const string SAVE_AfterMarketFactoryOption = "SaveAfterMarketOptions/";

   
        public const string SAVE_FACTORY_OPTIONS_URL = "SaveFactoryOptionsKBB/";

        public const string GET_AlternateFactory_OPTIONS_URL = "GetAfterMarketQuestions/";

        public const string SAVE_HISTORY_URL = "SaveHistoryKBB/";

        public const string SAVE_RECON_URL = "SaveReconDetailsKBB/";

        public const string SEARCH_NEAREST_STORES_URL = "GetStores/";
        public const string SAVE_APNS = "SavePushNotificationToken/";
        public const string SAVE_Offer = "SaveOfferResponseKBB/";
        public const string SAVE_Photo = "SavePhoto/";

        public const string CUSTOMER_APPRAISAL_LOG_URL = "FetchCustomerAppraisalLog/";
        public const string GetAPNSSummary = "GetApnsSummaryView/";
    }
}
