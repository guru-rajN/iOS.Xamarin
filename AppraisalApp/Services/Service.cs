﻿using System;
using ExtAppraisalApp.Models;

namespace ExtAppraisalApp.Services
{
    public interface Service
    {
        bool ValidateCustomerCode(string code);

        void FetchVinScanDetails(string vincode, int mileage, int storeId, int inventoryType);
        string ValidateZipDealer(int ZipDealer);
        string DecodeVin(string VIN, int Mileage, int StoreId, int InventoryType);
        AppraisalResponse CreateAppraisalKBB(CreateAppraisalRequest apprequest);
    }
}