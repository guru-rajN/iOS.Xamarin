using System;
namespace ExtAppraisalApp.Services
{
    public class ServiceFactory
    {
        public static ServiceImpl getWebServiceHandle()
        {
            return ServiceImpl.getInstance();
        }
        public class ServiceHistory
        {
            public static ServiceImpl getWebServiceHandle()
            {
                return ServiceImpl.getInstance();
            }
        }
        public class ServiceRecon
        {
            public static ServiceImpl getWebServiceHandle()
            {
                return ServiceImpl.getInstance();
            }
        }
    }
}
