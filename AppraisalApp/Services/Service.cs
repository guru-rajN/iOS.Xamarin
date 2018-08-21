using System;
using System.Collections.Generic;
using AppraisalApp.Models;
using ExtAppraisalApp.Models;

namespace ExtAppraisalApp.Services
{
    public interface Service
    {
        bool ValidateCustomerCode(string code);

        void FetchVinScanDetails(string vincode, int mileage, int storeId, int inventoryType);

        string ValidateZipDealer(int ZipDealer);

        VinVehicleDetailsKBB DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType);

        AppraisalResponse CreateAppraisalKBB(CreateAppraisalRequest apprequest);

        Vehicle GetVehicleDetails(long vehicleId, short storeId, short invtrId);

        KBBColorDetails GetKBBColors(int trimId);

        List<FactoryOptionsSection> GetFactoryOptionsKBB(long vehicleId, short storeId, short invtrId, int trimId);
    }
}
