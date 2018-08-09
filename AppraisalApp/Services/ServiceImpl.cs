using System;
using System.Net.Http;
using ExtAppraisalApp.Models;
using Newtonsoft.Json;

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

        public string ValidateZipDealer(int ZipDealer)
        {

            string result = null;
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = RestClient.doGet(Url.VALIDATE_ZIPCODE_URL + ZipDealer);


                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    if (null != result)
                    {
                        // result = (string)rst.Data;
                    }
                }
                else
                {
                    result = null;

                    Utilities.Utility.ShowAlert("Appraisal App", "Please Enter Valid Zip/Dealer Code!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return result;
        }

        public string DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = RestClient.doGet(Url.DECODEVIN_URL + VIN + "/" + Mileage + "/" + StoreId + "/" + InventoryType);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);




                    if (null != result)
                    {
                        //result = null;
                    }
                }
                else
                {
                    result = null;

                    Utilities.Utility.ShowAlert("Appraisal App", "Please Enter Valid Zip/Dealer Code!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return result;
        }

        public AppraisalResponse CreateAppraisalKBB(CreateAppraisalRequest apprequest)
        {
            string result = null;
            AppraisalResponse appresponse = new AppraisalResponse();
            HttpResponseMessage responseMessage = null;

            // string body = Convert.ToString(apprequest);
            try
            {
                AppraisalResponse response = new AppraisalResponse();
                string request = JsonConvert.SerializeObject(apprequest);



                responseMessage = RestClient.doPost(Url.CREATEAPPRAISAL_URL, request);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = (AppraisalResponse)rst.Data;

                    if (null != result)
                    {
                        //result = null;
                    }
                }
                else
                {
                    result = null;

                    Utilities.Utility.ShowAlert("Appraisal App", "Please Enter Valid Zip/Dealer Code!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return appresponse;

        }

        #endregion


    }
}
