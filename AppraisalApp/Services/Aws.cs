using System;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;
using ExtAppraisalApp.Models;
using ExtAppraisalApp;
using ExtAppraisalApp.Services;

namespace Amazon
{

    public class Aws
    {

        public void UploadFile(string filepath, byte[] myByteArray)
        {

            try
            {
                //string accountname = "simsmedia";
                //string photoSide = AppDelegate.appDelegate.photoButtonClicked;
                //string accesskey = "g6wHp0pm4c+JPM9Lbt/z0qQ/Fq1LnsAUdKKkaSPIe6p/Ljh3VkMobOzoX8jpmxWaSdJpwKu3SMtgVIxp9P01AQ==";
                //string keyName = Generatekeyname();

                //StorageCredentials creden = new StorageCredentials(accountname, accesskey);

                //CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);

                //CloudBlobClient client = acc.CreateCloudBlobClient();

                //CloudBlobContainer container = client.GetContainerReference("simsuatmedia");

                //container.CreateIfNotExistsAsync();

                //CloudBlockBlob blob = container.GetBlockBlobReference(keyName + ".png");

                //blob.UploadFromFileAsync(filepath);

                //string photoURL = String.Concat("https://iossims.blob.core.windows.net/simsphoto/" + keyName + ".jpeg");
                SavePhotoAPI(myByteArray);

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR " + exc.HelpLink);
            }
        }

        private void SavePhotoAPI(byte[] myByteArray)
        {
            PhotoResponse photoResponse = new PhotoResponse();
            SIMSResponseData responseStatus;
            photoResponse.VehicleID = AppDelegate.appDelegate.vehicleID;
            photoResponse.StoreID = AppDelegate.appDelegate.storeId;
            photoResponse.InvtrID = AppDelegate.appDelegate.invtrId;
            photoResponse.PhotoGuide = AppDelegate.appDelegate.photoButtonClicked;
            photoResponse.PhotoURL = "";
            photoResponse.Photo = myByteArray;

            //string DeviceToken = AppDelegate.appDelegate.AppleDeviceToken;
            responseStatus = ServiceFactory.ServicePhotoSave.getWebServiceHandle().SavePhoto(photoResponse);
        }

        public string Generatekeyname()
        {
            string key = Guid.NewGuid().ToString();
            return key;
        }

        internal void UploadFile(string pngFilename, object myByteArray)
        {
            throw new NotImplementedException();
        }
    }
}
