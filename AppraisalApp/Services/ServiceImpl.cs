using System;
using System.Net.Http;

namespace ExtAppraisalApp.Services
{
    public class ServiceImpl : Service
    {

        // validate zip/dealer code
        public bool ValidateCustomerCode(string code)
        {
            bool IsCustomerCodeValid = false;
            try
            {

                HttpResponseMessage responseMessage = RestClient.doGet(Url.VALIDATE_ZIPCODE_URL);

                if (responseMessage.IsSuccessStatusCode)
                {
                    // do something
                }
                else
                {
                    // do something
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occurred :: " + exc.Message);
            }

            return IsCustomerCodeValid;
        }

        public void FetchVinScanDetails(string vincode, int mileage, int storeId, int inventoryType)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = RestClient.doGet("DecodevinKBB/" + vincode + "/" + mileage + "/" + storeId + "/" + inventoryType);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    if (null != result)
                    {
                        // do something
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Vin Scan Decode failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }

        }

        #region Singleton pattern : Object creation
        private static ServiceImpl service;

        private ServiceImpl() { }

        public static ServiceImpl getInstance()
        {
            if (null == service)
            {
                service = new ServiceImpl();
            }
            return service;
        }

        #endregion

    }
}
