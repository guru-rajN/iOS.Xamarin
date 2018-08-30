using System;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net;

namespace Amazon
{

    public class Aws
    {

        public void UploadFile(string filepath)
        {
            string accountname = "iossims";

            string accesskey = "AiwOGA+Uf0jNlLYTkRwUuFqLsBaKp+OrO/UV7kQhUdSSCaV75s663jgKeTwcmPTv/aufWmjasnMVGsqv/1glvg==";
            try
            {
                string keyName = Generatekeyname();
                StorageCredentials creden = new StorageCredentials(accountname, accesskey);

                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);

                CloudBlobClient client = acc.CreateCloudBlobClient();

                CloudBlobContainer container = client.GetContainerReference("simsphoto");

                container.CreateIfNotExistsAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference(keyName + ".png");

                blob.UploadFromFileAsync(filepath);
                string photoURL = String.Concat("https://iossims.blob.core.windows.net/simsphoto/" + keyName + ".jpeg");
                // Save photo api  

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR " + exc.HelpLink);
            }
        }
        public string Generatekeyname()
        {
            string key = Guid.NewGuid().ToString();
            return key;
        }

    }
}
