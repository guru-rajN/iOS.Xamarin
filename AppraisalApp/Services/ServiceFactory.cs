using System;
namespace ExtAppraisalApp.Services
{
    public class ServiceFactory
    {
        public static ServiceImpl getWebServiceHandle()
        {
            return ServiceImpl.getInstance();
        }
    }
}
