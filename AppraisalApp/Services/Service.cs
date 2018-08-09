using System;
namespace ExtAppraisalApp.Services
{
    public interface Service
    {
        bool ValidateCustomerCode(string code);

        void FetchVinScanDetails(string vincode, int mileage, int storeId, int inventoryType);
    }
}
