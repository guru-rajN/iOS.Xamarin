using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AppraisalApp.Models;
using ExtAppraisalApp.Models;
using Newtonsoft.Json;

namespace ExtAppraisalApp.Services
{
    public class ServiceImpl : Service
    {

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

        public List<AppraisalLogEntity> FetchAppraisalLog(short storeId)
        {
            HttpResponseMessage responseMessage = null;
            string result = null;
            List<AppraisalLogEntity> appraisalLogsData = new List<AppraisalLogEntity>();
            try
            {

                responseMessage = RestClient.doGet(Url.FetchAppraisalLog_URL + "/" + storeId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var appaisalresponse = JsonConvert.DeserializeObject<List<AppraisalLogEntity>>(rst.Data.ToString());

                    appraisalLogsData = appaisalresponse;

                    if (null != result)
                    {
                        //result = null;
                    }
                }
                else
                {
                    result = null;

                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }
            return appraisalLogsData;
            
        }

        #endregion


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
                        result = rst.Data.ToString();
                    }
                }
                else
                {
                    result = null;

                   // Utilities.Utility.ShowAlert("Appraisal App", "Please Enter Valid Zip/Dealer Code!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return result;
        }

        public VinVehicleDetailsKBB DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            VinVehicleDetailsKBB decodeVinDetails = new VinVehicleDetailsKBB();
            try
            {
                responseMessage = RestClient.doGet(Url.DECODEVIN_URL + VIN + "/" + Mileage + "/" + StoreId + "/" + InventoryType);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    decodeVinDetails = JsonConvert.DeserializeObject<VinVehicleDetailsKBB>(rst.Data.ToString());
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Error while Decoding!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return decodeVinDetails;
        }

        public AppraisalResponse CreateAppraisalKBB(CreateAppraisalRequest apprequest)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            AppraisalResponse response = new AppraisalResponse();
            try
            {

                string request = JsonConvert.SerializeObject(apprequest);
                responseMessage = RestClient.doPost(Url.CREATEAPPRAISAL_URL, request);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var vehicleData = JsonConvert.DeserializeObject<AppraisalResponse>(rst.Data.ToString());

                    response = vehicleData;

                    if (null != result)
                    {
                        //result = null;
                    }
                    // TO-DO : show alert message if the VIN appraisal already created
                }
                else
                {
                    result = null;

                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }

        // Get KBB Vehicle details 
        public Vehicle GetVehicleDetails(long vehicleId, short storeId, short invtrId)
        {
            string result = null;
            Vehicle vehicleresponse = new Vehicle();
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = RestClient.doGet(Url.GET_VEHICLE_DETAILS_URL + "/" + vehicleId + "/" + storeId + "/" + invtrId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var vehicleData = JsonConvert.DeserializeObject<Vehicle>(rst.Data.ToString());

                    vehicleresponse = vehicleData;

                    if (null != result)
                    {
                        //result = null;
                    }
                    // TO-DO : show alert message if the VIN appraisal already created
                }
                else
                {
                    result = null;

                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }

            return vehicleresponse;
        }

        public List<FactoryOptionsSection> GetFactoryOptionsKBB(long vehicleId, short storeId, short invtrId, int trimId)
        {
            //
            HttpResponseMessage responseMessage = null;
            string result = null;
            List<FactoryOptionsSection> FacOpt = new List<FactoryOptionsSection>();
            try
            {

                responseMessage = RestClient.doGet(Url.GET_FACTORYOPTIONSKBB_URL + "/" + vehicleId + "/" + storeId + "/" + invtrId + "/" + trimId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var facresponse = JsonConvert.DeserializeObject<List<FactoryOptionsSection>>(rst.Data.ToString());
                    
                    FacOpt = facresponse;
                    
                    if (null != result)
                    {
                        //result = null;
                    }
                    // TO-DO : show alert message if the VIN appraisal already created
                }
                else
                {
                    result = null;
                    
                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }
            return FacOpt;
        }
        public KBBColorDetails GetKBBColors(int trimId)
        {
            string result = null;
            KBBColorDetails kBBColorDetails = new KBBColorDetails();
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = RestClient.doGet(Url.GET_KBB_COLORS_URL + "/" + trimId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var kbbColordatas = JsonConvert.DeserializeObject<KBBColorDetails>(rst.Data.ToString());

                    kBBColorDetails = kbbColordatas;

                }
                else
                {
                    result = null;

                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }

            return kBBColorDetails;
        }

        public string GenerateProspectId(ProspectParams prospectParams)
        {
            string result = null;
            string prospectId = string.Empty;
            HttpResponseMessage responseMessage = null;

            try
            {
                string request = JsonConvert.SerializeObject(prospectParams);
                responseMessage = RestClient.doPost(Url.GENERATE_PROSPECT_URL, request);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    prospectId = rst.Data.ToString();

                }
                else
                {
                    prospectId = null;

                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }

            return prospectId;
        }

        public SIMSResponseData SaveVehicleDetails(Vehicle vehicleDetails)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(vehicleDetails);

                responseMessage = RestClient.doPost(Url.SAVE_VEHICLE_DETAILS_URL, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                       // Utilities.Utility.ShowAlert("Appraisal App", "Vehicle Appraisal Created", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Vehicle data save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }

        public SIMSResponseData SaveFactoryOptions(VehicleFactoryOptionsKBB vehicleFactoryOptions)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(vehicleFactoryOptions);

                responseMessage = RestClient.doPost(Url.SAVE_FACTORY_OPTIONS_URL, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                        //Utilities.Utility.ShowAlert("Appraisal App", "Factory Options Saved", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Vehicle data save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }

        public AfterMarketOptions GetAltenateFactoryOptions(long vehicleId, short storeId, short invtrId, string prospectId)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;

            AfterMarketOptions afterMarketOptions = new AfterMarketOptions();
            SIMSResponseData response = new SIMSResponseData();
            try{
                
                responseMessage = RestClient.doGet(Url.GET_AlternateFactory_OPTIONS_URL + "/" + vehicleId + "/" + storeId + "/" + invtrId + "/" + prospectId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var facresponse = JsonConvert.DeserializeObject<AfterMarketOptions>(rst.Data.ToString());
                    //facresponse.aftermarketQuestions=JsonConvert.DeserializeObject<AfterMarketOptions>(rst.Data.ToString());

                    afterMarketOptions = facresponse;

                    if (null != result)
                    {
                        //result = null;
                    }
                    // TO-DO : show alert message if the VIN appraisal already created
                }
                else
                {
                    result = null;

                    //Utilities.Utility.ShowAlert("Appraisal App", "Decode VIN Failed!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }
        return afterMarketOptions;
        }
        public SIMSResponseData SaveHistory(HistoryRequest historydata)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(historydata);

                responseMessage = RestClient.doPost(Url.SAVE_HISTORY_URL, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                        //Utilities.Utility.ShowAlert("Appraisal App", "Vehicle History saved", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "History save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }
        public SIMSResponseData SaveAPNSDeviceToken(APNSRespone aPNSRespone)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(aPNSRespone);

                responseMessage = RestClient.doPost(Url.SAVE_APNS, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                        Utilities.Utility.ShowAlert("Appraisal App", "APNS saved", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "APNS save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }
        public SIMSResponseData SaveRecondition(ReconditionKBB recondata)
        {
            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(recondata);

                responseMessage = RestClient.doPost(Url.SAVE_RECON_URL, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                        //Utilities.Utility.ShowAlert("Appraisal App", "Vehicle Recondition saved", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Recondition save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }

        public List<Stores> SearchNearestStores(string zipcode)
        {
            HttpResponseMessage responseMessage = null;
            string result = null;
            List<Stores> storesList = new List<Stores>();

            try
            {
                responseMessage = RestClient.doGet(Url.SEARCH_NEAREST_STORES_URL + "/" + zipcode);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);
                    var response = JsonConvert.DeserializeObject<List<Stores>>(rst.Data.ToString());

                    storesList = response;
                }
                else
                {
                    result = null;

                    Utilities.Utility.ShowAlert("Appraisal App", "No Stores Found!!", "OK");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Exception occured :: " + exc.Message);
            }
            return storesList;
        }

        public SIMSResponseData SaveAfterMarketFactoryOptions(VehicleAfterMarketOptions vehicleAfterMarketOptions)
        {

            string result = null;
            HttpResponseMessage responseMessage = null;
            SIMSResponseData response = new SIMSResponseData();
            try
            {

                string request = JsonConvert.SerializeObject(vehicleAfterMarketOptions);

                responseMessage = RestClient.doPost(Url.SAVE_AfterMarketFactoryOption, request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    SIMSResponseData rst = JsonConvert.DeserializeObject<SIMSResponseData>(result);

                    response = rst;

                    if (null != response)
                    {
                        //Utilities.Utility.ShowAlert("Appraisal App", "After Market Saved Successfully", "OK");
                    }
                }
                else
                {
                    Utilities.Utility.ShowAlert("Appraisal App", "Vehicle data save failed!!", "OK");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception occured :: " + exc.Message);
            }
            return response;

        }
    }
}
